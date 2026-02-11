using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.UserControls;

// Crystal
using CrystalDecisions.CrystalReports.Engine;
using MilenialPark.Reports;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmFinePunishment : Form
    {
        public class FineSetting
        {
            public string FineCode;
            public string FineName;
            public decimal Price;
        }

        private List<FineSetting> _fineSettings;
        private string _selectedDayType = "WEEKDAY";    // default day type

        // =========================
        // CONFIG (MVP)
        // =========================
        private const string FINE_ITEM_CODE = "PG0004";   // Quinos itemCode for fine
        private const decimal FINE_PER_TICKET = 20000m;   // fixed fine per ticket
        private const int AUTO_REFRESH_SECONDS = 5;       // refresh quinos sales after print

        private readonly ControllerTransaction _trans = new ControllerTransaction();

        private string _transactionId = "";

        private string _fineRef = "";
        private DateTime _printedAt = DateTime.MinValue;

        private DataTable _dtLateTickets;
        private DataTable _dtQuinosFineSales;
        private FineSetting _fine;

        private Timer _timer;

        public FrmFinePunishment()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmFinePunishment(string transactionId)
        {
            InitializeComponent();
            WireEvents();

            _transactionId = transactionId;
            lblTransactionID.Text = transactionId;

            cbxFineType.SelectedIndex = 0;
            _selectedDayType = cbxFineType.Text;
        }

        private void WireEvents()
        {
            this.Load += FrmFinePunishment_Load;

            btnPrintStruk.Click += btnPrintStruk_Click;
            

            // manual refresh via click label "Quinos Sales"
            label1.Click += label1_Click;

            _timer = new Timer();
            _timer.Interval = AUTO_REFRESH_SECONDS * 1000;
            _timer.Tick += timer_Tick;
        }

        private List<FineSetting> LoadFineSettingsFromSql()
        {
            var sql = "SELECT FineCode, FineName, Price FROM dbo.TblFineSetting WHERE FineCode IS NOT NULL;";
            var dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(sql);
            var list = new List<FineSetting>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FineSetting
                {
                    FineCode = Convert.ToString(row["FineCode"] ?? "").Trim(),
                    FineName = Convert.ToString(row["FineName"] ?? "").Trim(),
                    Price = row["Price"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Price"]),
                });
            }
            return list;
        }

        private void FrmFinePunishment_Load(object sender, EventArgs e)
        {
            _fineSettings = LoadFineSettingsFromSql();
            if (_fineSettings == null || _fineSettings.Count == 0)
            {
                MessageBox.Show("TblFineSetting belum ada data.", "Info");
                return;
            }

            // optional: show selected type title on UI
            _selectedDayType = (cbxFineType.Text ?? "WEEKDAY").Trim().ToUpper();

            // style grids (optional)
            try
            {
                DataGridViewHelper.ApplyPOSStyle(dgvFineDetail);
                DataGridViewHelper.SizeCompact(dgvFineDetail, 150, 420);

                DataGridViewHelper.ApplyPOSStyle(dgvQuinosSales);
                DataGridViewHelper.SizeCompact(dgvQuinosSales, 150, 420);
            }
            catch { /* ignore styling errors */ }

            dgvFineDetail.ReadOnly = true;
            dgvFineDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFineDetail.MultiSelect = false;
            dgvFineDetail.AllowUserToAddRows = false;
            dgvFineDetail.AllowUserToDeleteRows = false;

            dgvQuinosSales.ReadOnly = true;
            dgvQuinosSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuinosSales.MultiSelect = false;
            dgvQuinosSales.AllowUserToAddRows = false;
            dgvQuinosSales.AllowUserToDeleteRows = false;

            if (string.IsNullOrWhiteSpace(lblTransactionID.Text) || lblTransactionID.Text == "-")
            {
                MessageBox.Show("Transaction ID belum terisi.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _transactionId = lblTransactionID.Text.Trim();

            // FineRef should be stable & easy for cashier to type/search
            if (string.IsNullOrEmpty(_fineRef))
                _fineRef = BuildFineRef(_transactionId);

            LoadLateTickets(_transactionId);
        }

        // ==========================================
        // 1) LOAD LATE TICKETS FROM WHNPOS (SQL Server)
        // ==========================================
        private void LoadLateTickets(string transactionId)
        {
            string sql =
                    "SELECT ... LateMinutes ... " +
                    "FROM WHNPOS.dbo.TransaksiTiketDetail " +
                    "WHERE TransactionID = ... AND OrderStatus='ENTER-IN' ...";

            _dtLateTickets = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(sql);

            // Add columns for fine information if needed
            if (!_dtLateTickets.Columns.Contains("FineCode")) _dtLateTickets.Columns.Add("FineCode", typeof(string));
            if (!_dtLateTickets.Columns.Contains("FineName")) _dtLateTickets.Columns.Add("FineName", typeof(string));
            if (!_dtLateTickets.Columns.Contains("FinePrice")) _dtLateTickets.Columns.Add("FinePrice", typeof(decimal));

            decimal totalAmount = 0m;

            foreach (DataRow row in _dtLateTickets.Rows)
            {
                var lateMinutes = Convert.ToInt32(row["LateMinutes"]);
                // Determine fine key: <=60 minutes uses “SANKSI 1 JAM”, otherwise “SANKSI UNLIMITED”
                var period = lateMinutes <= 60 ? "SANKSI 1 JAM" : "SANKSI UNLIMITED";
                var fineKey = $"{period} {_selectedDayType}";

                // Find the fine setting for this combination
                var fs = _fineSettings.FirstOrDefault(f =>
                             f.FineName.Equals(fineKey, StringComparison.OrdinalIgnoreCase));
                if (fs == null)
                {
                    // handle missing fine (fallback or throw)
                    continue;
                }
                row["FineCode"] = fs.FineCode;
                row["FineName"] = fs.FineName;
                row["FinePrice"] = fs.Price;

                totalAmount += fs.Price;
            }

            dgvFineDetail.DataSource = _dtLateTickets;
            lblAmount.Text = totalAmount.ToString("#,##0");  // show total fine
            if (_dtLateTickets.Rows.Count == 0)
                MessageBox.Show("Tidak ada ticket yang late untuk transaksi ini.", "Info",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // 2) PRINT FINE SLIP (Crystal)
        // ==========================================
        private void btnPrintStruk_Click(object sender, EventArgs e)
        {
            if (_dtLateTickets == null || _dtLateTickets.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data fine untuk dicetak.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // build dataset for Crystal
            DataSet ds = BuildFineReportDataSet(_dtLateTickets, _transactionId, _fineRef);

            try
            {
                ReportDocument rpt = new LaporanDenda();
                rpt.SetDataSource(ds);

                // preview if you want
                var frm = new Reports.FrmShowReport(rpt);
                frm.ShowDialog();

                rpt.PrintToPrinter(1, false, 0, 0);

                _printedAt = DateTime.Now;

                // refresh immediately + start timer
                RefreshQuinosSales();
                _timer.Start();

                MessageBox.Show(
                    "Fine details sudah dicetak.\n" +
                    "Minta cashier Quinos input FineRef ke Remark:\n" + _fineRef,
                    "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildFineRef(string transactionId)
        {
            // target: F26000009
            // from: TRT.JOYLAND-26-000009

            if (string.IsNullOrEmpty(transactionId))
                return "F" + DateTime.Now.ToString("yyHHmmss");

            // ambil 2 digit tahun sekarang
            string yy = DateTime.Now.ToString("yy");

            // ambil semua digit dari transactionId
            string digits = new string(transactionId.Where(char.IsDigit).ToArray());

            if (digits.Length >= 6)
            {
                // ambil 6 digit terakhir → running number
                string tail = digits.Substring(digits.Length - 6);
                return "F" + yy + tail;
            }

            // fallback kalau format aneh
            return "F" + yy + digits;
        }


        private DataSet BuildFineReportDataSet(DataTable dtLateTickets, string transactionId, string fineRef)
        {
            DataSet ds = new DataSet("FineDS");

            DataTable t = new DataTable("FineDetail");
            t.Columns.Add("FineRef", typeof(string));
            t.Columns.Add("TransactionID", typeof(string));
            t.Columns.Add("NoUrut", typeof(int));
            t.Columns.Add("RFID", typeof(string));
            t.Columns.Add("ItemName", typeof(string));
            t.Columns.Add("LateMinutes", typeof(int));
            t.Columns.Add("FinePerTicket", typeof(decimal));
            t.Columns.Add("Amount", typeof(decimal));

            for (int i = 0; i < dtLateTickets.Rows.Count; i++)
            {
                DataRow r = dtLateTickets.Rows[i];

                DataRow nr = t.NewRow();
                nr["FineRef"] = fineRef;
                nr["TransactionID"] = transactionId;
                nr["NoUrut"] = SafeInt(r["NoUrut"]);
                nr["RFID"] = SafeStr(r["RFID"]);
                nr["ItemName"] = SafeStr(r["ItemName"]);
                nr["LateMinutes"] = SafeInt(r["LateMinutes"]);
                nr["FinePerTicket"] = SafeDec(r["FinePrice"]);
                nr["Amount"] = SafeDec(r["FinePrice"]);

                t.Rows.Add(nr);
            }

            ds.Tables.Add(t);

            DataTable s = new DataTable("FineSummary");
            s.Columns.Add("FineRef", typeof(string));
            s.Columns.Add("TransactionID", typeof(string));
            s.Columns.Add("Qty", typeof(int));
            s.Columns.Add("TotalAmount", typeof(decimal));

            DataRow sr = s.NewRow();
            sr["FineRef"] = fineRef;
            sr["TransactionID"] = transactionId;
            sr["Qty"] = dtLateTickets.Rows.Count;
            //sr["TotalAmount"] = dtLateTickets.Rows.Count * FINE_PER_TICKET;
            decimal total = 0m;
            foreach (DataRow r in dtLateTickets.Rows)
                total += SafeDec(r["FinePrice"]);

            sr["TotalAmount"] = total;
            s.Rows.Add(sr);

            ds.Tables.Add(s);

            return ds;
        }

        // ==========================================
        // 3) QUIÑOS SALES REFRESH
        // ==========================================
        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshQuinosSales();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            RefreshQuinosSales();
        }

        private void RefreshQuinosSales()
        {
            if (string.IsNullOrEmpty(_fineRef)) return;

            DateTime from = (_printedAt == DateTime.MinValue) ? DateTime.Now.AddHours(-2) : _printedAt.AddHours(-2);
            DateTime to = DateTime.Now;

            // pick codes for selected day type
            var fineCodes = _fineSettings
                .Where(fs => fs.FineName.EndsWith(_selectedDayType, StringComparison.OrdinalIgnoreCase))
                .Select(fs => fs.FineCode)
                .Distinct()
                .ToList();

            if (fineCodes.Count == 0)
            {
                MessageBox.Show("Fine codes tidak ditemukan untuk: " + _selectedDayType);
                return;
            }

            // build IN clause as @c0,@c1,...
            string inClause = string.Join(",", fineCodes.Select((c, i) => "@c" + i));

            string sql = BuildQuinosFineSalesSql(inClause);

            var pars = new List<MySqlParameter>
    {
        new MySqlParameter("@from", MySqlDbType.DateTime){ Value = from },
        new MySqlParameter("@to", MySqlDbType.DateTime){ Value = to },
        new MySqlParameter("@fineRef", MySqlDbType.VarChar){ Value = _fineRef },
    };

            for (int i = 0; i < fineCodes.Count; i++)
                pars.Add(new MySqlParameter("@c" + i, MySqlDbType.VarChar) { Value = fineCodes[i] });

            _dtQuinosFineSales = MySqlFillDataTable(sql, pars.ToArray());
            dgvQuinosSales.DataSource = _dtQuinosFineSales;
        }

        private string BuildQuinosFineSalesSql(string inClause)
        {
            // ld = row that contains FineRef in description
            // l  = rows that contain fine items (codes inside IN clause)
            return
                "SELECT " +
                "  s.id AS sales_id, " +
                "  s.createdAt AS created_at, " +
                "  s.invoiceNo AS invoice_no, " +
                "  s.cashierName AS cashier_name, " +
                "  SUM(CASE WHEN l.itemCode IN (" + inClause + ") THEN IFNULL(l.quantity,0) ELSE 0 END) AS qty, " +
                "  SUM(CASE WHEN l.itemCode IN (" + inClause + ") THEN IFNULL(l.unitPrice,0)*IFNULL(l.quantity,0) ELSE 0 END) AS amount, " +
                "  MAX(ld.description) AS remark " +
                "FROM tbl_sales s " +
                "JOIN tbl_sales_lines ld ON ld.sales_id = s.id AND IFNULL(ld.description,'') LIKE CONCAT('%', @fineRef, '%') " +
                "JOIN tbl_sales_lines l  ON l.sales_id = s.id " +
                "WHERE s.created >= @from AND s.created <= @to " +
                "GROUP BY s.id, s.createdAt, s.invoiceNo, s.cashierName " +
                "ORDER BY s.id DESC;";
        }

        // ==========================================
        // 4) VERIFY
        // ==========================================
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fineRef))
            {
                MessageBox.Show("Silakan PRINT FINE DETAILS dulu agar FineRef dibuat.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_dtLateTickets == null || _dtLateTickets.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada fine detail.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_dtQuinosFineSales == null || _dtQuinosFineSales.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada pembayaran di Quinos untuk FineRef ini.\nKlik 'Quinos Sales' untuk refresh.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ Use CURRENT selected row in dgvQuinosSales
            if (dgvQuinosSales.CurrentRow == null)
            {
                MessageBox.Show("Pilih 1 baris pembayaran di Quinos Sales dulu.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fineSaleId = SafeInt(dgvQuinosSales.CurrentRow.Cells["sales_id"].Value);
            int qtyPaid = SafeInt(dgvQuinosSales.CurrentRow.Cells["qty"].Value);
            decimal amountPaid = SafeDec(dgvQuinosSales.CurrentRow.Cells["amount"].Value);

            int qtyNeed = _dtLateTickets.Rows.Count;
            //decimal amountNeed = qtyNeed * FINE_PER_TICKET;
            decimal amountNeed = 0m;
            foreach (DataRow r in _dtLateTickets.Rows)
                amountNeed += SafeDec(r["FinePrice"]);

            decimal amountPaidR = Math.Round(amountPaid, 0);
            decimal amountNeedR = Math.Round(amountNeed, 0);

            if (qtyPaid != qtyNeed || amountPaidR != amountNeedR)
            {
                MessageBox.Show(
                    "Data pembayaran tidak cocok.\n" +
                    "Need: Qty=" + qtyNeed + " Amount=" + amountNeedR.ToString("#,##0") + "\n" +
                    "Paid: Qty=" + qtyPaid + " Amount=" + amountPaidR.ToString("#,##0"),
                    "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // reuse protections
            List<int> nourutList = new List<int>();
            for (int i = 0; i < _dtLateTickets.Rows.Count; i++)
                nourutList.Add(SafeInt(_dtLateTickets.Rows[i]["NoUrut"]));

            if (IsFineRefAlreadyUsed(_transactionId, nourutList, _fineRef))
            {
                MessageBox.Show("FineRef ini sudah pernah dipakai untuk tiket yang sedang diproses.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsFineSaleAlreadyUsed(fineSaleId))
            {
                MessageBox.Show("Quinos Sales ID ini sudah pernah dipakai untuk verifikasi denda.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                "Verifikasi pembayaran fine?\nFineRef: " + _fineRef + "\nSalesID: " + fineSaleId,
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            ExtendJamKeluarAfterFinePaid(_transactionId, _fineRef, fineSaleId);

            // 2) Insert fine transaction (MVP)
            InsertFineTransactionToWhnpos(_transactionId, _fineRef, fineSaleId, qtyNeed, amountNeed);

            if (_timer != null) _timer.Stop();

            MessageBox.Show("Fine verified. Silahkan Keluar dari Playground.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsFineSaleAlreadyUsed(int fineSaleId)
        {
            string mark = "FINE_SALES_ID=" + fineSaleId;

            string q =
                "SELECT TOP 1 1 " +
                "FROM WHNPOS.dbo.TransaksiTiketDetail " +
                "WHERE ISNULL(Keterangan,'') LIKE " + ClsFungsi.C2Q("%" + mark + "%");

            DataTable dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(q);
            return (dt != null && dt.Rows.Count > 0);
        }

        private bool IsFineRefAlreadyUsed(string transactionId, List<int> noUrutList, string fineRef)
        {
            if (string.IsNullOrEmpty(transactionId)) return false;
            if (string.IsNullOrEmpty(fineRef)) return false;
            if (noUrutList == null || noUrutList.Count == 0) return false;

            string mark = "FINE_REF=" + fineRef;

            // build IN list: 1,2,3
            string inList = string.Join(",", noUrutList.Select(x => x.ToString()).ToArray());

            string q =
                "SELECT TOP 1 1 " +
                "FROM WHNPOS.dbo.TransaksiTiketDetail " +
                "WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) + " " +
                "  AND NoUrut IN (" + inList + ") " +
                "  AND ISNULL(Keterangan,'') LIKE " + ClsFungsi.C2Q("%" + mark + "%");

            DataTable dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(q);
            return (dt != null && dt.Rows.Count > 0);
        }


        private void UpdateTicketsToFined(string transactionId, string fineRef, int fineSaleId)
        {
            if (_dtLateTickets == null || _dtLateTickets.Rows.Count == 0) return;

            List<int> nourutList = new List<int>();
            for (int i = 0; i < _dtLateTickets.Rows.Count; i++)
                nourutList.Add(SafeInt(_dtLateTickets.Rows[i]["NoUrut"]));

            if (nourutList.Count == 0) return;

            string inList = string.Join(",", nourutList.Select(x => x.ToString()).ToArray());

            string append = " | FINE_REF=" + fineRef + " | FINE_SALES_ID=" + fineSaleId;

            string sql =
                "UPDATE WHNPOS.dbo.TransaksiTiketDetail " +
                "SET OrderStatus = 'FINED', " +
                "    Keterangan = ISNULL(Keterangan,'') + " + ClsFungsi.C2Q(append) + " " +
                "WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) + " " +
                "  AND NoUrut IN (" + inList + ");";

            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql);
        }

        // ==========================================
        // 5) INSERT FINE TRANSACTION INTO WHNPOS (MVP)
        // ==========================================
        private void InsertFineTransactionToWhnpos(string originalTransactionId, string fineRef, int fineSaleId, int qty, decimal amount)
        {
            string shopId = ClsStaticVariable.ShopID;
            if (string.IsNullOrEmpty(shopId)) shopId = "SHOP";

            string newTrxId = "TRS." + DateTime.Now.ToString("yyMMddHHmmss") +
                              originalTransactionId.Substring(originalTransactionId.Length - 6, 6);

            // KEEP SHORT to avoid truncation
            string remarks = "FINE_REF=" + fineRef + "|SALE=" + fineSaleId + "|ORG=" + originalTransactionId;
            remarks = Trunc(remarks, 80);

            // 1) insert header Transaksi (kolom minimal)
            string sql1 =
                "INSERT INTO WHNPOS.dbo.Transaksi " +
                "(TransactionID, TransactionDate, TotalAmount, ShopId, Remarks, TransactionStatus, TransactionType, PaymentType, CardID, KodeCabang, UserID, Subtotal) " +
                "VALUES (" +
                ClsFungsi.C2Q(newTrxId) + ", GETDATE(), " +
                amount.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " +
                ClsFungsi.C2Q(shopId) + ", " +
                ClsFungsi.C2Q(remarks) + ", " +
                ClsFungsi.C2Q("PAID") + ", " +
                ClsFungsi.C2Q("SANKSI") + ", " +
                ClsFungsi.C2Q("MASTER_CARD") + ", " +
                ClsFungsi.C2Q("777") + ", " +
                ClsFungsi.C2Q(ClsStaticVariable.KodeBranch) + ", " +
                ClsFungsi.C2Q(ClsStaticVariable.controllerUser.objUser.UserID) + ", " +
                amount.ToString(System.Globalization.CultureInfo.InvariantCulture) +
                ");";

            // execute header first
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql1);

            // 2) insert detail TransaksiTiketDetail (multiple rows grouped by FineCode)
            string ket = "DENDA|" + remarks;
            ket = Trunc(ket, 120);

            var grouped = _dtLateTickets.AsEnumerable()
                .GroupBy(r => new {
                    Code = Convert.ToString(r["FineCode"] ?? "").Trim(),
                    Name = Convert.ToString(r["FineName"] ?? "").Trim(),
                    Price = SafeDec(r["FinePrice"])
                });

            int noUrutLine = 1;

            foreach (var g in grouped)
            {
                int qtyLine = g.Count();          // ✅ renamed
                decimal priceLine = g.Key.Price;

                if (string.IsNullOrEmpty(g.Key.Code)) continue; // safety

                string sql2 =
                    "INSERT INTO WHNPOS.dbo.TransaksiTiketDetail " +
                    "(TransactionID, RFID, Keterangan, TransactionDate, ItemID, ItemName, Price, Qty, NoUrut, OrderStatus, JamMasuk, JamKeluar, WaktuBermain, Toleransi) " +
                    "VALUES (" +
                    ClsFungsi.C2Q(newTrxId) + ", NULL, " +
                    ClsFungsi.C2Q(ket) + ", GETDATE(), " +
                    ClsFungsi.C2Q(g.Key.Code) + ", " +
                    ClsFungsi.C2Q(g.Key.Name) + ", " +
                    priceLine.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " +
                    qtyLine.ToString() + ", " +
                    noUrutLine.ToString() + ", " +
                    ClsFungsi.C2Q("BOUGHT") + ", GETDATE(), GETDATE(), 0, 0" +
                    ");";

                // ✅ execute inside the loop
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql2);

                noUrutLine++;
            }
        }


        // ==========================================
        // MYSQL ACCESS
        // ==========================================
        private DataTable MySqlFillDataTable(string sql, MySqlParameter[] parameters)
        {
            string connStr = ClsStaticVariable.objConnection.connectionstring2;

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

        // ==========================================
        // SAFE PARSE
        // ==========================================
        private int SafeInt(object v)
        {
            if (v == null || v == DBNull.Value) return 0;
            int i;
            return int.TryParse(v.ToString(), out i) ? i : 0;
        }

        private decimal SafeDec(object v)
        {
            if (v == null || v == DBNull.Value) return 0m;
            decimal d;
            return decimal.TryParse(v.ToString(), out d) ? d : 0m;
        }

        private string SafeStr(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            return v.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void btnRefreshQuinosSales_Click(object sender, EventArgs e)
        {
            RefreshQuinosSales();
        }

        private void ExtendJamKeluarAfterFinePaid(string transactionId, string fineRef, int fineSaleId)
        {
            if (_dtLateTickets == null || _dtLateTickets.Rows.Count == 0) return;

            // nourut list yang late saja
            List<int> nourutList = new List<int>();
            for (int i = 0; i < _dtLateTickets.Rows.Count; i++)
                nourutList.Add(SafeInt(_dtLateTickets.Rows[i]["NoUrut"]));

            if (nourutList.Count == 0) return;

            string inList = string.Join(",", nourutList.Select(x => x.ToString()).ToArray());

            // marker yang disimpan sebagai bukti "fine sudah dibayar"
            string append = " | FINE_REF=" + fineRef + " | FINE_SALES_ID=" + fineSaleId;

            // ⚠️ cegah truncation (angka ini kamu sesuaikan kalau sudah tahu panjang kolom)
            // asumsi aman 200 char
            append = Trunc(append, 200);

            string sql =
                "UPDATE WHNPOS.dbo.TransaksiTiketDetail " +
                "SET " +
                // extend jam keluar 15 menit dari sekarang
                "    JamKeluar = DATEADD(minute, 15, GETDATE()), " +
                // tetap ENTER-IN (tidak diubah)
                "    OrderStatus = 'ENTER-IN', " +
                // append keterangan (truncated)
                "    Keterangan = LEFT(ISNULL(Keterangan,'') + " + ClsFungsi.C2Q(append) + ", 200) " +
                "WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) + " " +
                "  AND NoUrut IN (" + inList + ");";

            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql);
        }


        private string Trunc(string s, int maxLen)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                string fineCode = (txtFineCode.Text ?? "").Trim().ToUpper();
                if (fineCode.Length == 0)
                {
                    MessageBox.Show("Fine Code belum diisi.");
                    return;
                }

                // 1) Ambil data item dari Quinos (MySQL)
                DataRow item = GetQuinosItemByCode(fineCode);
                if (item == null)
                {
                    MessageBox.Show("Item Quinos tidak ditemukan untuk code: " + fineCode);
                    return;
                }

                string itemCode = Convert.ToString(item["code"] ?? "");
                string itemName = Convert.ToString(item["name"] ?? "");
                decimal price = ToDecimalSafe(item["price1"]);

                if (string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("Item name kosong di Quinos untuk code: " + fineCode);
                    return;
                }

                // 2) Upsert ke SQL Server TblFineSetting
                UpsertFineSettingSqlServer(fineCode, itemName, price);

                // 3) Update UI
                txtFineCode.Text = itemCode;
                lblName.Text = itemName;
                lblprice.Text = price.ToString("#,##0");

                MessageBox.Show("Fine setting berhasil disimpan:\n" + fineCode + " - " + itemName + " - " + price.ToString("#,##0"),
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSet Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataRow GetQuinosItemByCode(string itemCode)
        {
            // Sesuaikan nama kolom kalau berbeda:
            // tbl_items: code, name, price (atau unitPrice)
            string sql =
                "SELECT i.code, i.name, i.price1 " +
                "FROM tbl_items i " +
                "WHERE i.code = @code " +
                "LIMIT 1;";

            DataTable dt = new DataTable();

            string connStr = ClsStaticVariable.objConnection.connectionstring2; // MySQL connstring kamu
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", itemCode);

                    using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }

        private void UpsertFineSettingSqlServer(string fineCode, string fineName, decimal price)
        {
            // Pastikan nama table sesuai punyamu:
            // TblFineSetting(FineCode, FineName, Price)
            string sql =
                "IF EXISTS (SELECT 1 FROM dbo.TblFineSetting WHERE FineCode = " + ClsFungsi.C2Q(fineCode) + ") " +
                "BEGIN " +
                "   UPDATE dbo.TblFineSetting " +
                "   SET FineName = " + ClsFungsi.C2Q(fineName) + ", " +
                "       Price = " + price.ToString(System.Globalization.CultureInfo.InvariantCulture) + " " +
                "   WHERE FineCode = " + ClsFungsi.C2Q(fineCode) + "; " +
                "END ";

            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql);
        }

        private decimal ToDecimalSafe(object v)
        {
            if (v == null || v == DBNull.Value) return 0m;
            decimal d;
            return decimal.TryParse(v.ToString(), out d) ? d : 0m;
        }




        private decimal PickQuinosPrice(DataRow r)
        {
            // pilih kolom yang benar-benar ada dan tidak null
            if (r.Table.Columns.Contains("price") && r["price"] != DBNull.Value) return Convert.ToDecimal(r["price"]);
            if (r.Table.Columns.Contains("sellPrice") && r["sellPrice"] != DBNull.Value) return Convert.ToDecimal(r["sellPrice"]);
            if (r.Table.Columns.Contains("unitPrice") && r["unitPrice"] != DBNull.Value) return Convert.ToDecimal(r["unitPrice"]);
            return 0m;
        }

    }
}
