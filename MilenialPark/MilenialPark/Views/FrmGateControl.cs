using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views;
using MilenialPark.Views.Transaction;

namespace MilenialPark.Views
{
    public partial class FrmGateControl : Form
    {
        #region properties

        private bool _suppressReminderPopup = false; // dipakai saat enter/exit

        public SerialPort sp = new SerialPort();
        public ControllerShop controllerShop = new ControllerShop();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public DataTable dt = new DataTable();

        DateTime startDay => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        DateTime endDay => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        private bool _reminderGridSized = false;    

        private readonly Timer reminderTimer = new Timer();

        // optional: untuk mencegah double scan RFID yang sama dalam hitungan detik
        private string _lastRFID = "";
        private DateTime _lastScanTime = DateTime.MinValue;
        // === ADD THIS ===
        private string _lastAlertState = "";   // "", "RED", "YELLOW"

        public ControllerRFID controllerRFID = new ControllerRFID();


        private readonly int[] SupportedBaudRates =
        {
            9600, 19200, 38400, 57600, 115200
        };


        #endregion

        public FrmGateControl()
        {
            InitializeComponent();
        }

        private void FrmGateControl_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRefrs_Click(null, null);

            InitBaudRate();
            InitSerialDefaults();

            SetupReminderGrid();

            DataGridViewHelper.ApplyPOSStyle(dgvReminder);

            DataGridViewHelper.ApplyPOSStyle(dgvGateLog);

            if (!_reminderGridSized)
            {
                DataGridViewHelper.SizeCompact(dgvReminder, 100, 420);
                _reminderGridSized = true;
            }

            this.FormClosing += FrmGateControl_FormClosing;

            // Reason dropdown
            cbxReason.Items.Clear();
            cbxReason.Items.Add("Hilang");
            cbxReason.Items.Add("Rusak");
            cbxReason.SelectedIndex = 0;

            // Load Gate Log
            LoadGateLogGrid();

            RefreshReminderCore();

            if (dgvReminder.Rows.Count > 0 && dgvReminder.CurrentRow == null)
            {
                dgvReminder.Rows[0].Selected = true;
                dgvReminder.CurrentCell = dgvReminder.Rows[0].Cells["RFID"];
            }

            reminderTimer.Interval = 2 * 60 * 1000; // 1 menit (kamu tulis 5 menit tapi nilainya 1)
            reminderTimer.Tick += reminderTimer_Tick;
            reminderTimer.Start();

        }

        private void InitBaudRate()
        {
            cbxBaudRate.Items.Clear();
            foreach (int br in SupportedBaudRates)
                cbxBaudRate.Items.Add(br);

            cbxBaudRate.SelectedItem = 9600; // default RFID reader
        }

        private void InitSerialDefaults()
        {
            sp = new SerialPort();
            sp.DataReceived += serialPort_DataReceived;

            sp.Encoding = Encoding.ASCII;
            sp.ReadTimeout = 500;
            sp.WriteTimeout = 500;

            // SAFE defaults
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.None;
            sp.NewLine = "\r\n";
        }


        private void SetupReminderGrid()
        {
            dgvReminder.AutoGenerateColumns = false;
            dgvReminder.Columns.Clear();

            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "TransactionID", HeaderText = "TransactionID", DataPropertyName = "TransactionID" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "NoUrut", HeaderText = "NoUrut", DataPropertyName = "NoUrut" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "RFID", HeaderText = "RFID", DataPropertyName = "RFIDDisplay" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "TagID", HeaderText = "TagID", DataPropertyName = "TagID" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "Keterangan", HeaderText = "Katerangan", DataPropertyName = "Keterangan" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "ItemName", HeaderText = "ItemName", DataPropertyName = "ItemName" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "JamMasuk", HeaderText = "JamMasuk", DataPropertyName = "JamMasuk" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "JamKeluar", HeaderText = "JamKeluar", DataPropertyName = "JamKeluar" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "SisaMenit", HeaderText = "Sisa (Menit)", DataPropertyName = "SisaMenit" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "Urgency", HeaderText = "Urgency", DataPropertyName = "Urgency" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "Toleransi", HeaderText = "Toleransi", DataPropertyName = "Toleransi" });

            dgvReminder.ReadOnly = true;
            dgvReminder.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvReminder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvReminder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReminder.AllowUserToResizeColumns = false;
            dgvReminder.AllowUserToResizeRows = false;
        }

        private void reminderTimer_Tick(object sender, EventArgs e)
        {
            if (_isClosing) return;
            RefreshReminderWithPopup();
        }


        private void RefreshReminderCore()
        {
            dgvReminder.AutoGenerateColumns = false;

            try
            {
                dgvReminder.DataSource = null;

                var raw = controllerTrans.GetReminderEnterIn(startDay, endDay);

                if (!raw.Columns.Contains("SisaMenit")) raw.Columns.Add("SisaMenit", typeof(int));
                if (!raw.Columns.Contains("Urgency")) raw.Columns.Add("Urgency", typeof(string));

                DateTime now = DateTime.Now;

                if (!raw.Columns.Contains("RFIDDisplay")) raw.Columns.Add("RFIDDisplay", typeof(string));

                foreach (DataRow row in raw.Rows)
                {
                    string name = Convert.ToString(row["RFID"] ?? "").Trim();   // RFIDName
                    string tag = Convert.ToString(row["TagID"] ?? "").Trim();
                    row["RFIDDisplay"] = string.IsNullOrEmpty(tag) ? name : $"{name} ({tag})";

                    DateTime jamKeluarBase = row["JamKeluar"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(row["JamKeluar"]);

                    int toleransi = row["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(row["Toleransi"]);

                    if (jamKeluarBase == DateTime.MinValue)
                    {
                        row["SisaMenit"] = 9999;
                        row["Urgency"] = "GREEN";
                        continue;
                    }

                    // ✅ Effective deadline = JamKeluar + Toleransi
                    DateTime jamKeluarEffective = jamKeluarBase.AddMinutes(toleransi);

                    // ✅ show effective deadline in the grid
                    row["JamKeluar"] = jamKeluarEffective;

                    // minutes remaining to effective deadline
                    int sisaMenit = (int)Math.Floor((jamKeluarEffective - now).TotalMinutes);
                    row["SisaMenit"] = sisaMenit;

                    // ✅ Yellow threshold = 15 + toleransi minutes before effective deadline
                    int yellowThreshold = 15 + toleransi;

                    // --- RULES ---
                    if (now < jamKeluarBase)
                    {
                        // before original JamKeluar -> GREEN/YELLOW
                        row["Urgency"] = (sisaMenit <= yellowThreshold) ? "YELLOW" : "GREEN";
                    }
                    else if (now >= jamKeluarBase && now <= jamKeluarEffective)
                    {
                        // past base time but still within tolerance window -> ORANGE
                        row["Urgency"] = "ORANGE";
                    }
                    else
                    {
                        // past effective deadline -> RED
                        row["Urgency"] = "RED";
                    }
                }

                dgvReminder.DataSource = raw;

                foreach (DataGridViewRow r in dgvReminder.Rows)
                {
                    if (r.IsNewRow) continue;

                    string urg = Convert.ToString(r.Cells["Urgency"].Value);

                    if (urg == "RED")
                        r.DefaultCellStyle.BackColor = Color.Red;
                    else if (urg == "ORANGE")
                        r.DefaultCellStyle.BackColor = Color.Orange;
                    else if (urg == "YELLOW")
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        r.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                dgvReminder.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[Reminder Error] " + ex.Message;
            }

            lblRowCount.Text = dgvReminder.RowCount.ToString();
        }

        private void RefreshReminderWithPopup()
        {
            RefreshReminderCore();

            // kalau lagi suppress (misal enter/exit), stop di sini
            if (_suppressReminderPopup) return;

            try
            {
                bool hasWarning = false;
                bool hasCritical = false;

                // dgvReminder.DataSource adalah DataTable "raw"
                DataTable dt = dgvReminder.DataSource as DataTable;
                if (dt == null) return;

                foreach (DataRow row in dt.Rows)
                {
                    string urg = Convert.ToString(row["Urgency"]);
                    if (urg == "RED") hasCritical = true;
                    else if (urg == "YELLOW") hasWarning = true;
                }

                // tentukan state sekarang
                string currentState = "";
                if (hasCritical) currentState = "RED";
                else if (hasWarning) currentState = "YELLOW";

                // Pop up hanya jika status naik/berubah (biar tidak spam)
                if (currentState != "" && currentState != _lastAlertState)
                {
                    if (currentState == "RED")
                    {
                        MessageBox.Show("⚠️ ADA TIKET YANG SUDAH HABIS WAKTU!", "TIME OUT",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (currentState == "YELLOW")
                    {
                        MessageBox.Show("⏰ ADA TIKET YANG AKAN HABIS ≤ 15 MENIT!", "WARNING",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // simpan state terakhir
                _lastAlertState = currentState;
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[Reminder Popup Error] " + ex.Message;
            }
        }


        private void btnRefrs_Click(object sender, EventArgs e)
        {
            ComboPort.SelectedIndex = -1;
            ComboPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports) ComboPort.Items.Add(port);
            if (ports.Length > 0) ComboPort.SelectedIndex = 0;
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (ComboPort.SelectedIndex == -1) return;

            if (!sp.IsOpen)
            {
                sp.PortName = ComboPort.SelectedItem.ToString();
                sp.Open();
                PortStatus.Text = "Connected";
                PortStatus.BackColor = Color.FromArgb(0, 255, 0);
            }

            sp.DataReceived -= serialPort_DataReceived;
            sp.DataReceived += serialPort_DataReceived;
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                PortStatus.Text = "Disconnected";
                PortStatus.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxDataIO.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sp.IsOpen)
                {
                    MessageBox.Show("Serial Port belum connect.");
                    return;
                }

                string gateCodeText = (txtGateCode.Text ?? "").Trim().Replace("\r", "");
                if (string.IsNullOrEmpty(gateCodeText))
                {
                    MessageBox.Show("Gate code kosong.");
                    return;
                }

                // 1) Admin verify dialog
                using (var f = new FrmAdminPass())
                {
                    if (f.ShowDialog(this) != DialogResult.OK || !f.IsVerified)
                    {
                        MessageBox.Show("Aksi dibatalkan / tidak ada izin admin.");
                        return;
                    }

                    string adminUserId = f.VerifiedUserId;

                    // 2) Kirim pesan (tetap seperti sekarang)
                    string reply = "*" + gateCodeText + "#";
                    sp.WriteLine(reply);

                    // 3) Simpan GateLog
                    controllerTrans.InsertGateLog(
                        $"ADMIN OPEN GATE manual. GateCode={gateCodeText}",
                        "ADMIN_ACCESS",
                        adminUserId
                    );

                    LoadGateLogGrid();
                    MessageBox.Show("Gate command terkirim & sudah di-log.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal kirim command: " + ex.Message);
            }
        }

        public void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;
            string s = null;
            try
            {
                s = port.ReadLine(); // can timeout
            }
            catch (TimeoutException)
            {
                // normal when device sends partial line / no newline yet
                return;
            }
            catch (InvalidOperationException)
            {
                // port closed while receiving
                return;
            }
            catch (IOException)
            {
                return;
            }

            if (string.IsNullOrEmpty(s)) return;

            BeginInvoke(new Action(() =>
            {
                rtxDataIO.Text += s;

                // contoh format: "(<payload>,<gateCode>)"
                string payload;
                int gateCode;
                if (TryParseGatePacket(s, out payload, out gateCode))
                {
                    payload = NormalizeTagId(payload);   // << penting
                    // anti double-scan cepat
                    if (payload == _lastRFID && (DateTime.Now - _lastScanTime).TotalSeconds < 2)
                        return;

                    _lastRFID = payload;
                    _lastScanTime = DateTime.Now;

                    // gateCode==2 IN (sesuai code lama kamu)
                    if (gateCode == 2)
                        HandleEnter(payload, gateCode, port);
                    else
                        HandleExit(payload, gateCode, port);

                    return;
                }

                // ack OK dari device
                if (s.Contains("[") && s.Contains("]") && s.Contains("OK"))
                {
                    // optional: kalau device kamu memang kirim OK setelah buka, kamu bisa log saja
                    rtxDataIO.Text += "\n[Device OK]";
                }
            }));
        }

        // Cek apakah crew atau tidak 

        private bool IsCrewTag(DataRow rfidRow)
        {
            if (rfidRow == null) return false;

            string rfidName = Convert.ToString(rfidRow["RFIDName"] ?? "").Trim();
            return rfidName.IndexOf("CREW", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool TryHandleCrewPass(string tagId, int gateCode, SerialPort port, string direction, DataRow rfidRow)
        {
            // direction: "ENTER" / "EXIT" (buat log)
            // return true kalau ini CREW dan sudah ditangani (bypass), sehingga caller tinggal "return;"

            if (!IsCrewTag(rfidRow)) return false;

            // optional: pastikan aktif (kalau mau crew nonaktif jangan bisa lewat)
            bool isActive = rfidRow["Status"] != DBNull.Value && Convert.ToBoolean(rfidRow["Status"]);
            if (!isActive)
            {
                SendGateReply(port, gateCode, false, "RFID CREW NONAKTIF");
                return true;
            }

            string rfidName = Convert.ToString(rfidRow["RFIDName"] ?? "").Trim();
            string display = $"{rfidName} ({tagId})";

            // buka gate langsung
            SendGateReply(port, gateCode, true, $"CREW {direction}: {display}");

            // ambil user login (kalau ada)
            string userId = Convert.ToString(ClsStaticVariable.controllerUser?.objUser?.UserID ?? "").Trim();
            if (string.IsNullOrEmpty(userId)) userId = "SYSTEM";

            // log ke GateLog (Reason bisa kamu set khusus)
            controllerTrans.InsertGateLog(
                $"CREW {direction}. {display} passed gate. GateCode={gateCode}",
                "CREW_ACCESS",
                userId
            );

            // refresh UI
            LoadGateLogGrid();
            RefreshReminderCore();

            return true;
        }

        private void HandleEnter(string tagId, int gateCode, SerialPort port)
        {
            try
            {
                _suppressReminderPopup = true;

                tagId = NormalizeTagId(tagId);

                // lookup RFIDName dari master
                var r = controllerRFID.GetByTagID(tagId);
                if (r == null) { SendGateReply(port, gateCode, false, "RFID TIDAK TERDAFTAR"); return; }
                if (!(r["Status"] != DBNull.Value && Convert.ToBoolean(r["Status"])))
                { SendGateReply(port, gateCode, false, "RFID NONAKTIF"); return; }

                // ✅ CREW BYPASS
                if (TryHandleCrewPass(tagId, gateCode, port, "ENTER", r))
                    return;

                string rfidName = Convert.ToString(r["RFIDName"] ?? "").Trim();
                string display = $"{rfidName} ({tagId})";

                // 1) cari BOUGHT dulu
                dt = controllerTrans.GetTicketByTagID(tagId, "BOUGHT", startDay, endDay);

                // 2) kalau tidak ada, coba ENTER-OUT (re-entry)
                if (dt == null || dt.Rows.Count == 0)
                    dt = controllerTrans.GetTicketByTagID(tagId, "ENTER-OUT", startDay, endDay);

                if (dt == null || dt.Rows.Count != 1)
                {
                    SendGateReply(port, gateCode, false, "TIDAK ADA TIKET / SDH DIGUNAKAN");
                    return;
                }

                DataRow row = dt.Rows[0];

                string tid = Convert.ToString(row["TransactionID"] ?? "").Trim();
                if (string.IsNullOrEmpty(tid))
                {
                    SendGateReply(port, gateCode, false, "DATA TIDAK VALID");
                    return;
                }

                int noUrut = row["NoUrut"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoUrut"]);
                int waktuBermain = row.Table.Columns.Contains("WaktuBermain") && row["WaktuBermain"] != DBNull.Value
                    ? Convert.ToInt32(row["WaktuBermain"])
                    : 0;

                int toleransi = row["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(row["Toleransi"]);

                string currentStatus = Convert.ToString(row["OrderStatus"] ?? "").Trim().ToUpper();

                DateTime now = DateTime.Now;
                DateTime jamKeluar = row["JamKeluar"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["JamKeluar"]);

                // =========================
                // VALIDASI WAKTU
                // =========================

                // A) Re-entry: ENTER-OUT -> ENTER-IN wajib cek jamKeluar+toleransi
                if (currentStatus == "ENTER-OUT")
                {
                    if (jamKeluar == DateTime.MinValue)
                    {
                        SendGateReply(port, gateCode, false, "JAM KELUAR BELUM ADA");
                        return;
                    }

                    DateTime batas = jamKeluar.AddMinutes(toleransi);
                    if (now > batas)
                    {
                        SendGateReply(port, gateCode, false, "WAKTU HABIS");
                        return;
                    }
                }

                // B) First entry: BOUGHT -> ENTER-IN
                // Kalau sistem kamu sudah mengisi JamKeluar sejak beli, maka cek juga.
                // Kalau JamKeluar masih kosong, jangan cek (karena belum ada patokan expiry).
                //if (currentStatus == "BOUGHT" && jamKeluar != DateTime.MinValue)
                //{
                //    DateTime batas = jamKeluar.AddMinutes(toleransi);
                //    if (now > batas)
                //    {
                //        SendGateReply(port, gateCode, false, "WAKTU HABIS");
                //        return;
                //    }
                //}

                // =========================
                // UPDATE STATUS
                // =========================
                if (currentStatus == "BOUGHT")
                {
                    // BOUGHT: set jamMasuk/jamKeluar berdasarkan waktu bermain (logic lama)
                    controllerTrans.UpdateOrderStatusTiketandTime(tid, noUrut, waktuBermain, toleransi, "ENTER-IN");
                }
                else
                {
                    // ENTER-OUT: re-entry tanpa ubah JamKeluar
                    controllerTrans.UpdateOrderStatusOnly(tid, noUrut, "ENTER-IN");
                }

                controllerRFID.TouchLastScan(tagId);

                SendGateReply(port, gateCode, true, "WELCOME " + display);
                RefreshReminderCore();
            }
            catch (Exception ex)
            {
                rtxDataIO.AppendText("\n[ENTER Error] " + ex.ToString());
                SendGateReply(port, gateCode, false, "ERROR");
            }
            finally
            {
                _suppressReminderPopup = false;
            }
        }

        private void HandleExit(string tagId, int gateCode, SerialPort port)
        {
            _suppressReminderPopup = true;

            bool justpaid = false;

            try
            {
                tagId = NormalizeTagId(tagId);

                // (opsional tapi bagus) validasi tag ada di master & aktif
                var r = controllerRFID.GetByTagID(tagId);
                if (r == null)
                {
                    SendGateReply(port, gateCode, false, "RFID TIDAK TERDAFTAR");
                    return;
                }
                if (!(r["Status"] != DBNull.Value && Convert.ToBoolean(r["Status"])))
                {
                    SendGateReply(port, gateCode, false, "RFID NONAKTIF");
                    return;
                }

                // ✅ CREW BYPASS
                if (TryHandleCrewPass(tagId, gateCode, port, "EXIT", r))
                    return;

                string rfidName = Convert.ToString(r["RFIDName"] ?? "").Trim();
                string display = $"{rfidName} ({tagId})";

                // ✅ Ambil tiket ENTER-IN hari ini berdasarkan TagID
                dt = controllerTrans.GetTicketByTagID(tagId, "ENTER-IN", startDay, endDay);

                if (dt == null || dt.Rows.Count != 1)
                {
                    SendGateReply(port, gateCode, false, "TIKET TIDAK VALID");
                    RefreshReminderCore();
                    return;
                }

                DataRow row = dt.Rows[0];

                string tid = Convert.ToString(row["TransactionID"] ?? "").Trim();
                if (string.IsNullOrEmpty(tid))
                {
                    SendGateReply(port, gateCode, false, "DATA TIDAK VALID");
                    RefreshReminderCore();
                    return;
                }

                int noUrut = row["NoUrut"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoUrut"]);

                DateTime jamKeluar = row["JamKeluar"] == DBNull.Value
                    ? DateTime.MinValue
                    : Convert.ToDateTime(row["JamKeluar"]);

                int toleransi = row["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(row["Toleransi"]);

                DateTime now = DateTime.Now;

                if (jamKeluar == DateTime.MinValue)
                {
                    SendGateReply(port, gateCode, false, "JAM KELUAR BELUM ADA");
                    RefreshReminderCore();
                    return;
                }

                DateTime batasToleransi = jamKeluar.AddMinutes(toleransi);
                bool isRed = now > batasToleransi;


                if (isRed)
                {
                    //OLD LOGIC for late fine
                    //// kalau memang gate alarm beda channel, OK.
                    //// tapi kalau tidak, lebih aman pakai gateCode juga.
                    //SendGateReply(port, 1, true, "ALARM");

                    //using (var frm = new FrmFinePunishment(tid))
                    //{
                    //    var result = frm.ShowDialog(this);
                    //    if (result != DialogResult.OK)
                    //    {
                    //        SendGateReply(port, gateCode, false, "BAYAR DENDA DULU");
                    //        RefreshReminderCore();
                    //        return;
                    //    }
                    //}

                    //// reload setelah fine (pakai TagID juga)
                    //dt = controllerTrans.GetTicketByTagID(tagId, "ENTER-IN", startDay, endDay);
                    //if (dt == null || dt.Rows.Count != 1)
                    //{
                    //    SendGateReply(port, gateCode, false, "TIKET TIDAK VALID");
                    //    RefreshReminderCore();
                    //    return;
                    //}

                    //row = dt.Rows[0];
                    //jamKeluar = row["JamKeluar"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["JamKeluar"]);
                    //toleransi = row["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(row["Toleransi"]);
                    //batasToleransi = jamKeluar.AddMinutes(toleransi);

                    //if (now > batasToleransi)
                    //{
                    //    SendGateReply(port, gateCode, false, "BAYAR DENDA DULU");
                    //    RefreshReminderCore();
                    //    return;
                    //}

                    //justpaid = true;

                    // NEW LOGIC:
                    // Ticket sudah lewat batas toleransi.
                    // Alarm tetap bunyi, tapi customer tetap boleh keluar.
                    SendGateReply(port, 1, true, "ALARM");

                    controllerTrans.UpdateOrderStatusOnly(tid, noUrut, "LATE-TICKET");
                    SendGateReply(port, gateCode, true, "LATE TICKET - THANK YOU " + display);

                    controllerRFID.TouchLastScan(tagId);

                    rtxDataIO.AppendText("LATE-TICKET EXIT BERHASIL: " + display + Environment.NewLine);
                    RefreshReminderCore();  
                    return;
                }

                if (!justpaid)
                {
                    //controllerTrans.UpdateOrderStatusTiketOut(tid, noUrut, "ENTER-OUT");
                    controllerTrans.UpdateOrderStatusOnly(tid, noUrut, "ENTER-OUT");
                    SendGateReply(port, gateCode, true, "THANK YOU " + display);
                }
                else
                {
                    justpaid = false;
                }

                // optional: update last scan
                controllerRFID.TouchLastScan(tagId);

                //SendGateReply(port, gateCode, true, "THANK YOU " + display);
                rtxDataIO.AppendText("THANK YOU VERIFIKASI BERHASIL" + Environment.NewLine);
                RefreshReminderCore();
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[EXIT Error] " + ex.ToString();
                SendGateReply(port, gateCode, false, "ERROR");
                RefreshReminderCore();
            }
            finally
            {
                _suppressReminderPopup = false;
            }
        }

        private void SendGateReply(SerialPort port, int gateCode, bool open, string message)
        {
            if (port == null || !port.IsOpen) return;

            string cmd = open ? "buka" : "tutup";
            string reply = "*" + gateCode.ToString().Replace("\r", "") + "," + cmd + "," + message + "#";
            string reply2 = "*" + gateCode.ToString().Replace("\r", "") + "#";
            rtxDataIO.Text += "\n>> " + reply;
            if (open)
            {
                port.WriteLine(reply2);
            }
        }

        private bool TryParseGatePacket(string raw, out string payload, out int gateCode)
        {
            payload = "";
            gateCode = 0;

            //if (!raw.Contains("(") || !raw.Contains(")") || !raw.Contains(",")) return false;
            if (!raw.Contains("[") || !raw.Contains("]") || !raw.Contains(",")) return false;

            // ambil isi dalam ()
            //int i1 = raw.IndexOf("(");
            //int i2 = raw.IndexOf(")");
            int i1 = raw.IndexOf("[");
            int i2 = raw.IndexOf("]");
            if (i2 <= i1) return false;

            string inside = raw.Substring(i1 + 1, i2 - i1 - 1); // "payload,2"
            string[] parts = inside.Split(',');

            if (parts.Length < 2) return false;

            payload = (parts[0] ?? "").Trim();

            // kalau payload format lama QR: "&TRT..&NoUrut" -> ambil beda? (kita pakai RFID, jadi ignore)
            // tapi supaya aman, kalau ternyata ada & -> mungkin scan QR lama
            if (payload.Contains("&"))
            {
                // format " &TRT.xxx&NoUrut " -> ambil semuanya? atau reject
                // Kita reject agar tidak salah
                return false;
            }

            if (!int.TryParse(parts[1].Trim().Replace("\r", ""), out gateCode))
                return false;

            // RFID wajib ada
            if (string.IsNullOrWhiteSpace(payload)) return false;

            return true;
        }

        private bool _isClosing = false;

        private void FrmGateControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true;

            try
            {
                // 1. Stop timers
                if (reminderTimer != null)
                {
                    reminderTimer.Stop();
                    reminderTimer.Tick -= reminderTimer_Tick; // ✅ sekarang bisa dilepas
                }

                // Stop reminder popup
                _suppressReminderPopup = true;

                // Close SerialPort safely
                if (sp != null)
                {
                    try
                    {
                        sp.DataReceived -= serialPort_DataReceived;

                        if (sp.IsOpen)
                            sp.Close();
                    }
                    catch { }

                    try { sp.Dispose(); } catch { }
                }

                // 4. Optional logging
                rtxDataIO.AppendText("\n[INFO] GateControl closed safely");
            }
            catch (Exception ex)
            {
                // ❗ DO NOT block closing
                rtxDataIO.AppendText("\n[Close Error] " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RefreshReminderCore();
        }

        private void dgvReminder_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReminder.CurrentRow == null) return;

            string tagId = Convert.ToString(dgvReminder.CurrentRow.Cells["TagID"].Value ?? "").Trim();
            txtCurRFID.Text = tagId; // ini yang dipakai buat update
        }

        private void LoadGateLogGrid()
        {
            try
            {
                var dtLog = controllerTrans.GetGateLogTop(200);
                dgvGateLog.DataSource = dtLog;
            }
            catch (Exception ex)
            {
                rtxDataIO.AppendText("\n[GateLog Load Error] " + ex.Message);
            }
            DataGridViewHelper.SizeCompact(dgvGateLog, 100, 420);
            dgvGateLog.Columns["LogMessage"].Width = 350;
            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Basic selection validation
                if (dgvReminder.CurrentRow == null)
                {
                    MessageBox.Show("Pilih ticket dulu di list reminder.");
                    return;
                }

                // IMPORTANT:
                // Pastikan txtCurRFID isinya adalah TagID lama (RFID asli).
                // Kalau UI kamu menampilkan RFIDName, ambil oldTagId dari grid kolom "TagID" (lebih aman).
                string oldTagId = NormalizeTagId(Convert.ToString(dgvReminder.CurrentRow.Cells["TagID"]?.Value ?? ""));
                string newTagId = NormalizeTagId(txtNewRFID.Text);
                string reason = (cbxReason.Text ?? "").Trim();

                if (string.IsNullOrEmpty(oldTagId))
                {
                    MessageBox.Show("Current TagID kosong / tidak valid.");
                    return;
                }
                if (string.IsNullOrEmpty(newTagId))
                {
                    MessageBox.Show("New TagID wajib diisi (numeric).");
                    return;
                }
                if (newTagId == oldTagId)
                {
                    MessageBox.Show("New TagID tidak boleh sama dengan Current TagID.");
                    return;
                }

                // 2) Ticket key
                string tid = Convert.ToString(dgvReminder.CurrentRow.Cells["TransactionID"].Value ?? "").Trim();
                int noUrut = 0;
                int.TryParse(Convert.ToString(dgvReminder.CurrentRow.Cells["NoUrut"].Value ?? "0"), out noUrut);

                if (string.IsNullOrEmpty(tid) || noUrut <= 0)
                {
                    MessageBox.Show("Data ticket tidak valid (TransactionID/NoUrut).");
                    return;
                }

                // 3) Lookup RFIDName by TagID
                DataRow tagRow = controllerRFID.GetByTagID(newTagId);
                if (tagRow == null)
                {
                    MessageBox.Show("TagID tidak terdaftar di RFIDTags.");
                    return;
                }

                bool isActive = tagRow["Status"] != DBNull.Value && Convert.ToBoolean(tagRow["Status"]);
                if (!isActive)
                {
                    MessageBox.Show("RFIDTags.Status = 0 (tidak aktif). Tidak bisa dipakai.");
                    return;
                }

                string newRfidName = Convert.ToString(tagRow["RFIDName"] ?? "").Trim();
                if (string.IsNullOrEmpty(newRfidName))
                {
                    MessageBox.Show("RFIDName kosong di RFIDTags. Mohon lengkapi master RFID.");
                    return;
                }

                // 4) Duplicate check in current reminder list (pakai TagID)
                if (IsTagIdExistsInReminder(newTagId, tid, noUrut))
                {
                    MessageBox.Show("New TagID sudah dipakai oleh ticket lain di list reminder. Pilih RFID lain.");
                    return;
                }

                // 5) Admin verify
                using (var f = new FrmAdminPass())
                {
                    if (f.ShowDialog(this) != DialogResult.OK || !f.IsVerified)
                    {
                        MessageBox.Show("Aksi dibatalkan / tidak ada izin admin.");
                        return;
                    }

                    string adminUserId = f.VerifiedUserId;

                    // 6) Update DB (RFIDName + TagID) + append ket
                    string appendKet =
                        $"RFID_CHANGE {oldTagId}->{newTagId} ({newRfidName}) | REASON={reason} | " +
                        $"BY {ClsStaticVariable.controllerUser.objUser.UserID} | VERIFIED_BY={adminUserId}";

                    controllerTrans.UpdateTicketRfid(tid, noUrut, newTagId, newRfidName, appendKet);

                    controllerTrans.InsertGateLog(
                        $"RFID changed. TID={tid} NoUrut={noUrut} {oldTagId}->{newTagId} ({newRfidName})",
                        reason,
                        adminUserId
                    );
                }

                // 7) Refresh UI
                RefreshReminderCore();
                LoadGateLogGrid();
                txtNewRFID.Clear();

                MessageBox.Show("RFID berhasil diganti dan sudah di-log.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ganti RFID: " + ex.Message);
            }
        }

        private bool IsRfidExistsInReminder(string newRfid, string currentTid, int currentNoUrut)
        {
            newRfid = (newRfid ?? "").Trim();

            if (string.IsNullOrEmpty(newRfid)) return false;

            foreach (DataGridViewRow row in dgvReminder.Rows)
            {
                if (row == null || row.IsNewRow) continue;

                string rowTid = Convert.ToString(row.Cells["TransactionID"].Value ?? "").Trim();
                int rowNoUrut = 0;
                int.TryParse(Convert.ToString(row.Cells["NoUrut"].Value ?? "0"), out rowNoUrut);

                // skip row yang sedang kamu edit (ticket yang sama)
                if (rowTid == currentTid && rowNoUrut == currentNoUrut)
                    continue;

                string rowRfid = Convert.ToString(row.Cells["RFID"].Value ?? "").Trim();

                // compare case-insensitive biar aman
                if (string.Equals(rowRfid, newRfid, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private bool IsTagIdExistsInReminder(string newTagId, string currentTid, int currentNoUrut)
        {
            newTagId = NormalizeTagId(newTagId);
            if (string.IsNullOrEmpty(newTagId)) return false;

            foreach (DataGridViewRow row in dgvReminder.Rows)
            {
                if (row == null || row.IsNewRow) continue;

                string rowTid = Convert.ToString(row.Cells["TransactionID"].Value ?? "").Trim();
                int rowNoUrut = 0;
                int.TryParse(Convert.ToString(row.Cells["NoUrut"].Value ?? "0"), out rowNoUrut);

                if (rowTid == currentTid && rowNoUrut == currentNoUrut)
                    continue;

                string rowTagId = NormalizeTagId(Convert.ToString(row.Cells["TagID"]?.Value ?? ""));
                if (rowTagId == newTagId) return true;
            }
            return false;
        }

        private void txtNewRFID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtNewRFID.Text =  Convert.ToInt32(txtNewRFID.Text).ToString();
            }
        }

        private void txtCurRFID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtCurRFID.Text =  Convert.ToInt32(txtCurRFID.Text).ToString();
            }
        }

        private string NormalizeTagId(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "";

            // pastikan numeric
            if (!raw.All(char.IsDigit))
            {
                ClsFungsi.Pesan("RFID harus numeric!", "ERROR");
                return "";
            }

            // buang leading zero
            string cleaned = raw.TrimStart('0');

            // kalau semua nol -> 0
            return cleaned.Length == 0 ? "0" : cleaned;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            SupervisorOpenGate(2); // gate code ENTER
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SupervisorOpenGate(3); // gate code EXIT
        }

        private void SupervisorOpenGate(int gateCode)
        {
            try
            {
                // 0) Validasi serial port
                if (sp == null || !sp.IsOpen)
                {
                    MessageBox.Show("Serial Port belum connect.");
                    return;
                }

                // 1) Validasi input person
                string person = (txtPerson.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(person))
                {
                    MessageBox.Show("txtPerson masih kosong. Isi dulu nama / tujuan akses.");
                    txtPerson.Focus();
                    return;
                }

                // 2) Current user login
                string userId = Convert.ToString(ClsStaticVariable.controllerUser?.objUser?.UserID ?? "").Trim();
                if (string.IsNullOrEmpty(userId))
                    userId = "UNKNOWN";

                // 3) Kirim command gate (format kamu: *{gateCode}#)
                _suppressReminderPopup = true;

                string cmd = "*" + gateCode.ToString() + "#";
                sp.WriteLine(cmd);

                // 4) Log ke GateLog
                string logMessage = $"{userId} open the Gate for {person} (GateCode={gateCode})";
                controllerTrans.InsertGateLog(
                    logMessage,
                    "Supervisor Access",    
                    userId
                );

                // 5) Refresh grid log
                LoadGateLogGrid();

                // optional UX
                rtxDataIO.AppendText($"\n>> {cmd} [SUPERVISOR] {logMessage}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal open gate: " + ex.Message);
            }
            finally
            {
                _suppressReminderPopup = false;
            }
        }
    }
}
