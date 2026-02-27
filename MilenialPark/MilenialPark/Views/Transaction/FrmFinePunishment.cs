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
        private bool _isInitializing = true;

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

            cbxFineType.SelectedIndexChanged += (s, e) =>
            {
                if (_isInitializing) return;          // ✅ jangan jalan sebelum form siap
                if (_fineSettings == null) return;    // ✅ safety

                _selectedDayType = (cbxFineType.Text ?? "WEEKDAY").Trim().ToUpper();

                if (!string.IsNullOrEmpty(_transactionId))
                    LoadLateTickets(_transactionId);

                RefreshQuinosSales();
            };
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
                _fineRef = GetNextFineRefForTransaction(_transactionId);

            LoadLateTickets(_transactionId);

            _isInitializing = false;
        }

        // ==========================================
        // 1) LOAD LATE TICKETS FROM WHNPOS (SQL Server)
        // ==========================================
        private void LoadLateTickets(string transactionId)
        {
            string sql = @"
SELECT
  TransactionID, NoUrut, RFID, ItemID, ItemName, Qty, Price, JamKeluar, Toleransi, OrderStatus, Keterangan,
  CASE
    WHEN JamKeluar IS NULL THEN 0
    WHEN GETDATE() <= DATEADD(minute, ISNULL(Toleransi,0), JamKeluar) THEN 0
    ELSE
      CONVERT(int, CEILING( DATEDIFF(second, DATEADD(minute, ISNULL(Toleransi,0), JamKeluar), GETDATE()) / 60.0 ))
  END AS LateMinutes
FROM WHNPOS.dbo.TransaksiTiketDetail
WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) + @"
  AND OrderStatus = 'ENTER-IN'
  AND JamKeluar IS NOT NULL
  AND GETDATE() > DATEADD(minute, ISNULL(Toleransi,0), JamKeluar)
ORDER BY NoUrut ASC;";

            _dtLateTickets = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(sql);

            if (!_dtLateTickets.Columns.Contains("FineCode")) _dtLateTickets.Columns.Add("FineCode", typeof(string));
            if (!_dtLateTickets.Columns.Contains("FineName")) _dtLateTickets.Columns.Add("FineName", typeof(string));
            if (!_dtLateTickets.Columns.Contains("FinePrice")) _dtLateTickets.Columns.Add("FinePrice", typeof(decimal));
            if (!_dtLateTickets.Columns.Contains("ExtendMinutes"))
                _dtLateTickets.Columns.Add("ExtendMinutes", typeof(int));

            decimal totalAmount = 0m;

            foreach (DataRow row in _dtLateTickets.Rows)
            {
                // ================= DETECT PENDAMPING =================
                string itemName = SafeStr(row["ItemName"]).ToUpper();

                bool isCompanion =
                    itemName.Contains("PENDAMPING") ||
                    itemName.Contains("COMPANION") ||
                    itemName.Contains("GUARDIAN");

                // ===== PENDAMPING: NO FINE BUT STILL ALARM =====
                if (isCompanion)
                {
                    row["FineCode"] = DBNull.Value;
                    row["FineName"] = "PENDAMPING (NO FINE)";
                    row["FinePrice"] = 0m;

                    // tetap ada alarm delay
                    row["ExtendMinutes"] = 15;

                    continue;
                }

                // ================= NORMAL CHILD TICKET =================
                int lateMinutes = SafeInt(row["LateMinutes"]);
                if (lateMinutes < 1) lateMinutes = 1;

                bool isOneHour = (lateMinutes <= 60);

                string fineKey = isOneHour
                    ? "SANKSI " + _selectedDayType + " 1 JAM"
                    : "SANKSI UNLIMITED " + _selectedDayType;

                fineKey = fineKey.Trim();

                var fs = _fineSettings.FirstOrDefault(f =>
                    !string.IsNullOrEmpty(f.FineName) &&
                    f.FineName.Trim().Equals(fineKey, StringComparison.OrdinalIgnoreCase));

                if (fs == null)
                {
                    row["FineCode"] = "";
                    row["FineName"] = fineKey + " (NOT FOUND)";
                    row["FinePrice"] = 0m;
                    continue;
                }

                row["FineCode"] = (fs.FineCode ?? "").Trim();
                row["FineName"] = (fs.FineName ?? "").Trim();
                row["FinePrice"] = fs.Price;

                int extendMin = GetExtendMinutesFromQuinos(row["FineCode"].ToString());
                row["ExtendMinutes"] = extendMin;

                totalAmount += fs.Price;
            }

            dgvFineDetail.DataSource = _dtLateTickets;
            lblAmount.Text = totalAmount.ToString("#,##0");
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
                //var frm = new Reports.FrmShowReport(rpt);
                //frm.ShowDialog();

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

        private int GetExtendMinutesFromQuinos(string fineCode)
        {
            if (string.IsNullOrWhiteSpace(fineCode))
                return 0;

            string sql = @"
                SELECT IFNULL(minimumtime,0) AS minimumtime
                FROM tbl_items
                WHERE code = @code
                LIMIT 1;";

            var dt = MySqlFillDataTable(sql, new[]
            {
                new MySqlParameter("@code", MySqlDbType.VarChar){ Value = fineCode.Trim()
            }
            });

            if (dt.Rows.Count == 0)
                return 0;

            return SafeInt(dt.Rows[0]["minimumtime"]);
        }

        private string BuildFineRefBase(string transactionId)
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

        private string GetNextFineRefForTransaction(string transactionId)
        {
            string baseRef = BuildFineRefBase(transactionId);   // F26000093

            // Cari max session yang sudah pernah dipakai untuk transaction ini:
            // Keterangan mengandung "FINE_REF=F26000093-01" dst
            string q = @"
SELECT ISNULL(MAX(TRY_CAST(RIGHT(x.FineRef, 2) AS INT)), 0)
FROM (
    SELECT 
      SUBSTRING(Keterangan,
        CHARINDEX('FINE_REF=" + baseRef + @"-', Keterangan) + LEN('FINE_REF=" + baseRef + @"-'),
        2
      ) AS FineRef
    FROM WHNPOS.dbo.TransaksiTiketDetail
    WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) + @"
      AND CHARINDEX('FINE_REF=" + baseRef + @"-', ISNULL(Keterangan,'')) > 0
) x
WHERE x.FineRef IS NOT NULL;
";

            int maxNo = 0;
            try
            {
                DataTable dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(q);
                if (dt != null && dt.Rows.Count > 0)
                    maxNo = SafeInt(dt.Rows[0][0]);
            }
            catch { /* kalau query gagal, fallback ke 0 */ }

            int next = maxNo + 1;
            return baseRef + "-" + next.ToString("D2"); // F26000093-01
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
            t.Columns.Add("FineName", typeof(string));   // ✅ packet fined name
            t.Columns.Add("FineCode", typeof(string));   // optional

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
                nr["FineName"] = SafeStr(r["FineName"]);   // ✅ packet fined name
                nr["FineCode"] = SafeStr(r["FineCode"]);   // optional

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
            sr["Qty"] = dtLateTickets.AsEnumerable().Count(r => !string.IsNullOrEmpty(SafeStr(r["FineCode"])));
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

            string sql = BuildQuinosFineSalesLinesSql();

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

        private string BuildQuinosFineSalesLinesSql()
        {
            return @"
SELECT
    s.id            AS sales_id,
    s.created     AS created_at,
    s.invoiceNo     AS invoice_no,
    s.cashierName   AS cashier_name,

    l.id            AS line_id,
    l.itemCode      AS itemCode,
    l.description   AS description,
    IFNULL(l.quantity,0)  AS qty,
    IFNULL(l.unitPrice,0) AS unitPrice,
    (IFNULL(l.quantity,0) * IFNULL(l.unitPrice,0)) AS lineAmount

FROM tbl_sales s
JOIN tbl_sales_lines l
    ON l.sales_id = s.id

WHERE s.created >= @from AND s.created <= @to
  AND s.id IN (
        SELECT DISTINCT ld.sales_id
        FROM tbl_sales_lines ld
        WHERE IFNULL(ld.description,'') LIKE CONCAT('%', @fineRef, '%')
  )

ORDER BY s.id DESC, l.idx ASC, l.id ASC;
";
        }

        // ==========================================
        // 4) VERIFY
        // ==========================================
        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
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
                    MessageBox.Show("Belum ada pembayaran di Quinos untuk FineRef ini.\nKlik 'Refresh' untuk update.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgvQuinosSales.CurrentRow == null)
                {
                    MessageBox.Show("Pilih salah satu baris Quinos Sales dulu.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int fineSaleId = SafeInt(dgvQuinosSales.CurrentRow.Cells["sales_id"].Value);
                if (fineSaleId <= 0)
                {
                    MessageBox.Show("sales_id tidak valid.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ================= NEED =================
                int qtyNeed = _dtLateTickets.AsEnumerable()
                                                .Count(r => !string.IsNullOrEmpty(SafeStr(r["FineCode"])));

                decimal amountNeed = 0m;

                foreach (DataRow r in _dtLateTickets.Rows)
                {
                    if (string.IsNullOrEmpty(SafeStr(r["FineCode"]))) continue;
                    amountNeed += SafeDec(r["FinePrice"]);
                }

                decimal amountNeedR = Math.Round(amountNeed, 0);

                // ================= QUINOS COLUMNS =================
                string colSalesId = _dtQuinosFineSales.Columns.Contains("sales_id") ? "sales_id" : null;
                string colDesc = _dtQuinosFineSales.Columns.Contains("description") ? "description" : null;

                string colQty = _dtQuinosFineSales.Columns.Contains("qty") ? "qty" :
                                (_dtQuinosFineSales.Columns.Contains("quantity") ? "quantity" : null);

                string colUnit = _dtQuinosFineSales.Columns.Contains("unitPrice") ? "unitPrice" : null;
                string colAmt = _dtQuinosFineSales.Columns.Contains("lineAmount") ? "lineAmount" :
                                (_dtQuinosFineSales.Columns.Contains("amount") ? "amount" : null);

                string colItem = _dtQuinosFineSales.Columns.Contains("itemCode") ? "itemCode" : null;

                if (colSalesId == null || colDesc == null || colQty == null)
                {
                    MessageBox.Show("Kolom Quinos Sales belum sesuai.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ambil lines
                List<DataRow> lines = _dtQuinosFineSales.AsEnumerable()
                    .Where(x => SafeInt(x[colSalesId]) == fineSaleId)
                    .ToList();

                // expected fine codes
                HashSet<string> expectedCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataRow r in _dtLateTickets.Rows)
                {
                    string c = Convert.ToString(r["FineCode"] ?? "").Trim();
                    if (!string.IsNullOrEmpty(c)) expectedCodes.Add(c);
                }

                // ================= FILTER FINE LINES =================
                List<DataRow> paidFineLines = new List<DataRow>();

                foreach (DataRow x in lines)
                {
                    string desc = Convert.ToString(x[colDesc] ?? "").Trim();
                    string code = (colItem == null) ? "" : Convert.ToString(x[colItem] ?? "").Trim();

                    // buang baris FineRef
                    if (!string.IsNullOrEmpty(desc) &&
                        desc.IndexOf(_fineRef, StringComparison.OrdinalIgnoreCase) >= 0)
                        continue;

                    decimal lineAmt = 0m;
                    if (colAmt != null)
                        lineAmt = SafeDec(x[colAmt]);
                    else if (colUnit != null)
                        lineAmt = SafeDec(x[colUnit]) * SafeDec(x[colQty]);

                    // skip non money
                    if (Math.Round(Math.Abs(lineAmt), 0) <= 0m)
                        continue;

                    bool byCode = !string.IsNullOrEmpty(code) && expectedCodes.Contains(code);
                    bool byDesc = !string.IsNullOrEmpty(desc) &&
                                  desc.ToUpper().Contains("SANKSI") &&
                                  desc.ToUpper().Contains(_selectedDayType.ToUpper());

                    if (byCode || byDesc)
                        paidFineLines.Add(x);
                }

                // ================= NETTING (FIX VOID BUG) =================
                int qtyPaid = 0;
                decimal amountPaid = 0m;

                var grouped = paidFineLines
                    .GroupBy(x =>
                    {
                        string code = (colItem == null) ? "" : Convert.ToString(x[colItem] ?? "").Trim();
                        string desc = Convert.ToString(x[colDesc] ?? "").Trim();

                        if (!string.IsNullOrEmpty(code))
                            return "CODE|" + code;
                        else
                            return "DESC|" + desc;
                    });

                foreach (var g in grouped)
                {
                    int netQty = 0;
                    decimal netAmt = 0m;

                    foreach (DataRow x in g)
                    {
                        int q = SafeInt(x[colQty]);
                        netQty += q;

                        if (colAmt != null)
                            netAmt += SafeDec(x[colAmt]);
                        else if (colUnit != null)
                            netAmt += SafeDec(x[colUnit]) * q;
                    }

                    qtyPaid += netQty;
                    amountPaid += netAmt;
                }

                decimal amountPaidR = Math.Round(amountPaid, 0);

                // ================= CHECK =================
                if (qtyPaid != qtyNeed || amountPaidR != amountNeedR)
                {
                    MessageBox.Show(
                        "Data pembayaran tidak cocok.\n" +
                        "Need: Qty=" + qtyNeed + " Amount=" + amountNeedR.ToString("#,##0") + "\n" +
                        "Paid: Qty=" + qtyPaid + " Amount=" + amountPaidR.ToString("#,##0"),
                        "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ================= SUCCESS =================
                ExtendJamKeluarAfterFinePaid(_transactionId, _fineRef, fineSaleId);
                InsertFineTransactionToWhnpos(_transactionId, _fineRef, fineSaleId, qtyNeed, amountNeedR);

                MessageBox.Show("Fine verified. Silahkan Keluar dari Playground.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verify error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            string append = Trunc(" | FINE_REF=" + fineRef + " | FINE_SALES_ID=" + fineSaleId, 200);

            foreach (DataRow r in _dtLateTickets.Rows)
            {
                int noUrut = SafeInt(r["NoUrut"]);
                int extendMin = SafeInt(r["ExtendMinutes"]);

                if (extendMin <= 0)
                    extendMin = 15; // safety fallback

                string sql =
                    "UPDATE WHNPOS.dbo.TransaksiTiketDetail " +
                    "SET JamKeluar = DATEADD(minute, " + extendMin + ", GETDATE()), " +
                    "    OrderStatus = 'ENTER-IN', " +
                    "    Keterangan = LEFT(ISNULL(Keterangan,'') + " + ClsFungsi.C2Q(append) + ", 200) " +
                    "WHERE TransactionID = " + ClsFungsi.C2Q(transactionId) +
                    " AND NoUrut = " + noUrut + ";";

                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(sql);
            }
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
                "SELECT i.code, i.name, i.price1 , IFNULL(i.minimumtime,0) AS minimumtime  " +
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

        private HashSet<string> GetExpectedFineCodes()
        {
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (_dtLateTickets == null) return set;

            foreach (DataRow r in _dtLateTickets.Rows)
            {
                string code = Convert.ToString(r["FineCode"] ?? "").Trim();
                if (!string.IsNullOrEmpty(code)) set.Add(code);
            }
            return set;
        }


        private decimal PickQuinosPrice(DataRow r)
        {
            // pilih kolom yang benar-benar ada dan tidak null
            if (r.Table.Columns.Contains("price") && r["price"] != DBNull.Value) return Convert.ToDecimal(r["price"]);
            if (r.Table.Columns.Contains("sellPrice") && r["sellPrice"] != DBNull.Value) return Convert.ToDecimal(r["sellPrice"]);
            if (r.Table.Columns.Contains("unitPrice") && r["unitPrice"] != DBNull.Value) return Convert.ToDecimal(r["unitPrice"]);
            return 0m;
        }

        private FineSetting FindFineSetting(int lateMinutes, string dayType)
        {
            dayType = (dayType ?? "WEEKDAY").Trim().ToUpper();
            if (lateMinutes < 1) lateMinutes = 1;

            // kamu bisa ganti label period sesuai naming kamu di TblFineSetting
            string period = (lateMinutes <= 60) ? "1 JAM" : "UNLIMITED";

            // Kandidat format nama yang mungkin ada di TblFineSetting.FineName
            var candidates = new[]
            {
        $"SANKSI {period} {dayType}",   // SANKSI 1 JAM WEEKDAY
        $"SANKSI {dayType} {period}",   // SANKSI WEEKDAY 1 JAM  ✅
        $"{period} {dayType}",          // 1 JAM WEEKDAY
        $"{dayType} {period}",          // WEEKDAY 1 JAM
        $"SANKSI {dayType}",            // kalau ada yang cuma "SANKSI WEEKDAY"
        $"SANKSI {period}",             // kalau ada yang cuma "SANKSI 1 JAM"
    };

            foreach (var key in candidates)
            {
                var fs = _fineSettings.FirstOrDefault(f =>
                    !string.IsNullOrEmpty(f?.FineName) &&
                    f.FineName.Trim().Equals(key, StringComparison.OrdinalIgnoreCase));

                if (fs != null) return fs;
            }

            return null;
        }

    }
}
