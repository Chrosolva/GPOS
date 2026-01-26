using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Models;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmGetQuinosSales : Form
    {
        // Controllers
        private ControllerTransaction _controllerTran;

        // cache detail (biar tidak query berkali-kali)
        private DataTable _dtHeader;
        private DataTable _dtDetail;

        // === CONFIG ===
        // category_id Quinos untuk "PLAYTIME"
        private const int QUINOS_PLAYTIME_CATEGORY_ID = 9;

        // remark pattern untuk cek sudah diimport
        private const string REMARK_PREFIX = "QUINOS SALES_ID=";

        public FrmGetQuinosSales()
        {
            InitializeComponent();

            _controllerTran = new ControllerTransaction();

            // events
            this.Load += FrmGetQuinosSales_Load;
            btnFilter.Click += btnFilter_Click;
            btnSelect.Click += btnSelect_Click;
            dgvSalesHeader.SelectionChanged += dgvSalesHeader_SelectionChanged;
        }

        private void FrmGetQuinosSales_Load(object sender, EventArgs e)
        {
            // default range: hari ini
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            SetupGridHeader();
            SetupGridDetail();

            // auto load pertama kali
            LoadSalesHeader();
        }

        #region GRID SETUP

        private void SetupGridHeader()
        {
            dgvSalesHeader.AutoGenerateColumns = true;
            dgvSalesHeader.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesHeader.MultiSelect = false;
            dgvSalesHeader.ReadOnly = true;
            dgvSalesHeader.AllowUserToAddRows = false;
            dgvSalesHeader.AllowUserToDeleteRows = false;
        }

        private void SetupGridDetail()
        {
            dgvSalesDetail.AutoGenerateColumns = true;
            dgvSalesDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesDetail.MultiSelect = false;
            dgvSalesDetail.ReadOnly = true;
            dgvSalesDetail.AllowUserToAddRows = false;
            dgvSalesDetail.AllowUserToDeleteRows = false;
        }

        #endregion

        #region MYSQL QUERIES (HEADER/DETAIL)

        // Header: kolom minimum (tidak terlalu banyak)
        private string BuildHeaderSql()
        {
            // NOTE:
            // - dateIndex di sample kamu format "202601" (bulan), jadi kurang cocok untuk range detail jam.
            // - lebih aman pakai "date" atau "createdAt" (yang tipe datetime).
            // Aku pakai: s.date (di sample ada) atau s.createdAt, pilih salah satu yang valid di DB kamu.
            //
            // Kalau di DB mu `date` string/angka, ganti ke createdAt.
            //
            // Filter keyword aku pakai invoiceNo, cashierName, customerName, notes.

            return @"
SELECT
    s.id           AS sales_id,
    s.createdAt    AS created_at,
    s.invoiceNo    AS invoice_no,
    s.cashierName  AS cashier_name,
    s.customerName AS customer_name,
    s.mode         AS mode,
    s.subtotal     AS subtotal,
    s.tax1Amount   AS tax_amount,
    s.serviceChargeAmount AS service_charge,
    s.total        AS total,
    s.status       AS status
FROM tbl_sales s
WHERE s.created >= @from
  AND s.created <= @to
  AND (
        @kw = '' OR
        s.invoiceNo LIKE CONCAT('%', @kw, '%') OR
        s.cashierName LIKE CONCAT('%', @kw, '%') OR
        s.customerName LIKE CONCAT('%', @kw, '%') OR
        s.notes LIKE CONCAT('%', @kw, '%')
      )
ORDER BY s.id DESC;";
        }

        // Detail: kolom minimum + kebutuhan mapping tiket
        private string BuildDetailSql()
        {
            // Penting:
            // - tbl_sales_lines ada baris payment (contoh: "CASH") yang type=3 dan item_id NULL.
            // - baris "remark" (gak pake cabe) bisa jadi item_id=8 atau semacam catatan.
            // Filter:
            // - hanya lines yang item_id not null
            // - type = 1 (umumnya item line)
            // Kalau di DB kamu type item line berbeda, ubah sesuai.

            return @"
SELECT
    l.sales_id,
    l.id          AS line_id,
    l.item_id,
    l.itemCode    AS item_code,
    l.description    AS item_name,
    l.quantity    AS qty,
    l.unitPrice   AS price,
    l.remark      AS remark,
    i.duration    AS duration,
    i.tolerance   AS tolerance,
    c.id          AS category_id,
    c.name        AS category_name
FROM tbl_sales_lines l
LEFT JOIN tbl_items i       ON i.id = l.item_id
LEFT JOIN tbl_categories c  ON c.id = i.category_id
WHERE l.sales_id = @sales_id
  AND l.item_id IS NOT NULL
  AND (l.type = 1 OR l.type IS NULL)
ORDER BY l.idx ASC, l.id ASC;";
        }

        #endregion

        #region LOAD DATA

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadSalesHeader();
        }

        private void LoadSalesHeader()
        {
            try
            {
                string sql = BuildHeaderSql();

                MySqlParameter[] p = new MySqlParameter[]
                {
                    new MySqlParameter("@from", MySqlDbType.DateTime) { Value = dtpFrom.Value },
                    new MySqlParameter("@to",   MySqlDbType.DateTime) { Value = dtpTo.Value },
                    new MySqlParameter("@kw",   MySqlDbType.VarChar)  { Value = (txtKeyWord.Text ?? "").Trim() } // (txtCardID kamu dipakai sebagai keyword)
                };

                _dtHeader = MySqlFillDataTable(sql, p);
                dgvSalesHeader.DataSource = _dtHeader;

                lblrow.Text = "Row Count : " + (_dtHeader != null ? _dtHeader.Rows.Count.ToString() : "0");

                // auto load detail untuk row pertama
                if (_dtHeader != null && _dtHeader.Rows.Count > 0)
                {
                    dgvSalesHeader.ClearSelection();
                    dgvSalesHeader.Rows[0].Selected = true;
                    LoadSalesDetailFromSelectedHeader();
                }
                else
                {
                    dgvSalesDetail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSalesHeader Error: " + ex.Message);
            }
        }

        private void dgvSalesHeader_SelectionChanged(object sender, EventArgs e)
        {
            LoadSalesDetailFromSelectedHeader();
        }

        private void LoadSalesDetailFromSelectedHeader()
        {
            if (dgvSalesHeader.CurrentRow == null) return;
            if (dgvSalesHeader.CurrentRow.DataBoundItem == null) return;

            object v = dgvSalesHeader.CurrentRow.Cells["sales_id"].Value;
            if (v == null) return;

            int salesId;
            if (!int.TryParse(v.ToString(), out salesId)) return;

            LoadSalesDetail(salesId);
        }

        private void LoadSalesDetail(int salesId)
        {
            try
            {
                string sql = BuildDetailSql();

                MySqlParameter[] p = new MySqlParameter[]
                {
                    new MySqlParameter("@sales_id", MySqlDbType.Int32) { Value = salesId }
                };

                _dtDetail = MySqlFillDataTable(sql, p);
                dgvSalesDetail.DataSource = _dtDetail;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSalesDetail Error: " + ex.Message);
            }
        }

        #endregion

        #region SELECT -> OPEN PAYMENT

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesHeader.CurrentRow == null)
                {
                    MessageBox.Show("Pilih 1 Sales Header terlebih dahulu.");
                    return;
                }

                object v = dgvSalesHeader.CurrentRow.Cells["sales_id"].Value;
                if (v == null)
                {
                    MessageBox.Show("Sales ID tidak valid.");
                    return;
                }

                int salesId;
                if (!int.TryParse(v.ToString(), out salesId))
                {
                    MessageBox.Show("Sales ID tidak valid.");
                    return;
                }

                // pastikan detail sudah ada
                if (_dtDetail == null || _dtDetail.Rows.Count == 0)
                {
                    LoadSalesDetail(salesId);
                }

                if (_dtDetail == null || _dtDetail.Rows.Count == 0)
                {
                    MessageBox.Show("Detail kosong / tidak ditemukan.");
                    return;
                }

                // 1) cek ada PLAYTIME (category_id=9)
                if (_dtDetail == null || _dtDetail.Rows.Count == 0)
                {
                    MessageBox.Show("Sales ini tidak punya item PLAYTIME (category_id=9).");
                    return;
                }


                // 2) cek sudah pernah diimport ke WHNPOS
                if (AlreadyImportedToWhnpos(salesId))
                {
                    MessageBox.Show("Sales ini sudah pernah di-import ke WHNPOS.\nCek transaksi dengan Remarks: " + REMARK_PREFIX + salesId);
                    return;
                }

                // 3) bangun ControllerTransaction + open FrmPayment
                ControllerTransaction tran = BuildControllerTransactionFromQuinos(salesId);

                // isi remarks agar tahu sumber
                tran.objTransaction.Remarks = REMARK_PREFIX + salesId;

                // buka payment (biar user scan RFID & input keterangan)
                FrmPayment frm = new FrmPayment(tran);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSelect_Click Error: " + ex.Message);
            }
        }

        private ControllerTransaction BuildControllerTransactionFromQuinos(int salesId)
        {
            ControllerTransaction tran = new ControllerTransaction();

            // Ambil total dari header yang kepilih (lebih “matching” dengan Quinos)
            decimal total = 0m;
            decimal subtotal = 0m;
            decimal tax = 0m;

            if (dgvSalesHeader.CurrentRow != null)
            {
                subtotal = ToDecimalSafe(dgvSalesHeader.CurrentRow.Cells["subtotal"].Value);
                tax = ToDecimalSafe(dgvSalesHeader.CurrentRow.Cells["tax_amount"].Value);
                total = ToDecimalSafe(dgvSalesHeader.CurrentRow.Cells["total"].Value);

                if (total == 0m)
                {
                    // fallback: sum detail
                    total = SumDetailTotal(_dtDetail);
                }
            }

            // buat transaction dummy (akan diganti TransactionID di FrmPayment saat save)
            // PaymentType biarkan kosong karena nanti kamu pilih di FrmPayment.
            tran.objTransaction = new ClsTransaction(
                "QUINOS_TMP",
                DateTime.Now,
                total,
                "",
                "",
                ClsStaticVariable.ShopID,
                REMARK_PREFIX + salesId,
                subtotal,
                tax,
                0,
                0,
                "PAID",
                "QUINOS"
            );

            // isi listtranstikdet
            tran.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();

            int noUrut = 1;

            // GROUP item yang non-ticket (category != 9) berdasarkan item_code+price
            // Ticket (category=9) boleh per-row (Qty biasanya 1) atau tetap per item.
            foreach (DataRow r in _dtDetail.Rows)
            {
                int categoryId = ToIntSafe(r["category_id"]);
                string itemCode = SafeStr(r["item_code"]);
                string itemName = SafeStr(r["item_name"]);
                int qty = ToIntSafe(r["qty"]);
                decimal price = ToDecimalSafe(r["price"]);
                string remark = SafeStr(r["remark"]);

                // mapping waktu bermain & toleransi dari tbl_items
                int duration = ToIntSafe(r["duration"]);
                int tolerance = ToIntSafe(r["tolerance"]);

                // catatan:
                // - kalau itemCode kosong, fallback ke item_id
                if (string.IsNullOrEmpty(itemCode))
                {
                    itemCode = SafeStr(r["item_id"]);
                }

                // Ticket items (category 9) -> WaktuBermain > 0 agar masuk ke grid tiket
                if (categoryId == QUINOS_PLAYTIME_CATEGORY_ID)
                {
                    // buat 1 det, qty sesuai quinos
                    ClsTransactionTiketDetail det = new ClsTransactionTiketDetail(
                        "QUINOS_TMP",
                        DateTime.Now,
                        itemCode,
                        itemName,
                        price,
                        qty,
                        noUrut,
                        "BOUGHT",
                        DateTime.Now,
                        DateTime.Now,
                        duration,
                        tolerance,
                        "",
                        remark
                    );

                    // Keterangan dari remark sales_lines
                    det.Keterangan = remark;

                    // RFID null (akan diisi di FrmPayment)
                    det.RFID = null;

                    tran.objTransaction.listtranstikdet.Add(det);
                    noUrut++;
                }
                else
                {
                    // Non-ticket -> WaktuBermain=0 agar masuk ke dgvTransaksiDetail
                    ClsTransactionTiketDetail det = new ClsTransactionTiketDetail(
                        "QUINOS_TMP",
                        DateTime.Now,
                        itemCode,
                        itemName,
                        price,
                        qty,
                        noUrut,
                        "BOUGHT",
                        DateTime.Now,
                        DateTime.Now,
                        0,
                        0
                    );

                    det.Keterangan = remark;
                    det.RFID = null;

                    tran.objTransaction.listtranstikdet.Add(det);
                    noUrut++;
                }
            }

            return tran;
        }

        private bool AlreadyImportedToWhnpos(int salesId)
        {
            // cek di SQL Server: Transaksi.Remarks mengandung "QUINOS SALES_ID=<id>"
            // NOTE: Sesuaikan nama table/kolom jika berbeda.
            string q = "SELECT TOP 1 TransactionID FROM WHNPOS.dbo.Transaksi WHERE Remarks LIKE " +
                       ClsFungsi.C2Q("%" + REMARK_PREFIX + salesId + "%");

            DataTable dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(q);
            return (dt != null && dt.Rows.Count > 0);
        }

        private decimal SumDetailTotal(DataTable dtDetail)
        {
            if (dtDetail == null || dtDetail.Rows.Count == 0) return 0m;

            decimal sum = 0m;
            foreach (DataRow r in dtDetail.Rows)
            {
                decimal price = ToDecimalSafe(r["price"]);
                int qty = ToIntSafe(r["qty"]);
                sum += (price * qty);
            }
            return sum;
        }

        #endregion

        #region HELPERS (SAFE PARSE)

        private static string SafeStr(object v)
        {
            return v == null ? "" : v.ToString();
        }

        private static int ToIntSafe(object v)
        {
            if (v == null) return 0;
            int i;
            return int.TryParse(v.ToString(), out i) ? i : 0;
        }

        private static decimal ToDecimalSafe(object v)
        {
            if (v == null) return 0m;
            decimal d;
            return decimal.TryParse(v.ToString(), out d) ? d : 0m;
        }

        #endregion

        #region MYSQL DATA ACCESS (PAKAI CONNECTION DARI ClsStaticVariable)

        private DataTable MySqlFillDataTable(string sql, MySqlParameter[] parameters)
        {
            // === PILIH SALAH SATU SESUAI PROJECT KAMU ===
            //
            // OPSI A (Paling aman): simpan connection string MySQL di ClsStaticVariable.MySqlConnStr
            // string connStr = ClsStaticVariable.MySqlConnStr;
            //
            // OPSI B: kamu punya connection instance di ClsStaticVariable.objConnection.objmysqlconnection (custom)
            // -> kalau kamu memang punya wrapper, ganti isi method ini pakai wrapper itu.

            // --- OPSI A: langsung MySqlConnection ---
            string connStr = ClsStaticVariable.objConnection.connectionstring2; // <-- pastikan field ini ada

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                            cmd.Parameters.Add(parameters[i]);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }


        #endregion

        private void FrmGetQuinosSales_Load_1(object sender, EventArgs e)
        {
            DataGridViewHelper.ApplyPOSStyle(dgvSalesHeader);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvSalesHeader, 100, 420);

            DataGridViewHelper.ApplyPOSStyle(dgvSalesDetail);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvSalesDetail, 100, 420);
        }
    }
}
