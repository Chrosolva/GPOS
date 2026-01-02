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

        private readonly Timer reminderTimer = new Timer();

        // optional: untuk mencegah double scan RFID yang sama dalam hitungan detik
        private string _lastRFID = "";
        private DateTime _lastScanTime = DateTime.MinValue;
        // === ADD THIS ===
        private string _lastAlertState = "";   // "", "RED", "YELLOW"


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
            btnRefrs_Click(null, null);

            InitBaudRate();
            InitSerialDefaults();

            SetupReminderGrid();
            RefreshReminderCore();

            reminderTimer.Interval = 1 * 60 * 1000; // 1 menit (kamu tulis 5 menit tapi nilainya 1)
            reminderTimer.Tick += reminderTimer_Tick;
            reminderTimer.Start();


            DataGridViewHelper.ApplyPOSStyle(dgvReminder);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvReminder, 100, 420);

            this.FormClosing += FrmGateControl_FormClosing;
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
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "RFID", HeaderText = "RFID", DataPropertyName = "RFID" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "ItemName", HeaderText = "ItemName", DataPropertyName = "ItemName" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "JamMasuk", HeaderText = "JamMasuk", DataPropertyName = "JamMasuk" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "JamKeluar", HeaderText = "JamKeluar", DataPropertyName = "JamKeluar" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "SisaMenit", HeaderText = "Sisa (Menit)", DataPropertyName = "SisaMenit" });
            dgvReminder.Columns.Add(new DataGridViewTextBoxColumn { Name = "Urgency", HeaderText = "Urgency", DataPropertyName = "Urgency" });

            dgvReminder.ReadOnly = true;
            dgvReminder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

                foreach (DataRow row in raw.Rows)
                {
                    DateTime jamKeluar = row["JamKeluar"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(row["JamKeluar"]);

                    int toleransi = row["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(row["Toleransi"]);

                    if (jamKeluar == DateTime.MinValue)
                    {
                        row["SisaMenit"] = 9999;
                        row["Urgency"] = "GREEN";
                        continue;
                    }

                    // batas toleransi
                    DateTime batasToleransi = jamKeluar.AddMinutes(toleransi);

                    int sisaMenit = (int)Math.Floor((jamKeluar - now).TotalMinutes);
                    row["SisaMenit"] = sisaMenit;

                    // --- RULES ---
                    if (now < jamKeluar)
                    {
                        // sebelum jam keluar
                        row["Urgency"] = (sisaMenit <= 15) ? "YELLOW" : "GREEN";
                    }
                    else if (now >= jamKeluar && now <= batasToleransi)
                    {
                        // sudah lewat jam keluar tapi masih dalam toleransi
                        row["Urgency"] = "ORANGE";
                    }
                    else
                    {
                        // lewat batas toleransi
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
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[Reminder Error] " + ex.Message;
            }
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
                        MessageBox.Show("⚠️ ADA TIKET SUDAH HABIS WAKTU!", "TIME OUT",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (currentState == "YELLOW")
                    {
                        MessageBox.Show("⏰ ADA TIKET AKAN HABIS ≤ 15 MENIT!", "WARNING",
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
            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if (sp.IsOpen)
                {
                    //string reply = "*" + txtGateCode.Text.Replace("\r", "") + "," + "buka" + "," + "ADMIN ACCESS" + "#";
                    string reply = "*" + txtGateCode.Text.Replace("\r", "") + "#";
                    sp.WriteLine(reply);
                }
            }
            else
            {
                MessageBox.Show("Maaf anda tidak memiliki akses untuk menggunakan fitur ini , hubungi admin anda !!!");
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

        private void HandleEnter(string rfid, int gateCode, SerialPort port)
        {
            try
            {
                _suppressReminderPopup = true;
                // Cari tiket yang masih BOUGHT untuk hari ini berdasarkan RFID
                dt = controllerTrans.GetTicketByRFID(rfid, "BOUGHT", startDay, endDay);

                if (dt.Rows.Count == 1)
                {
                    string tid = dt.Rows[0]["TransactionID"].ToString();
                    int noUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    int waktuBermain = dt.Rows[0]["WaktuBermain"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["WaktuBermain"]);
                    int toleransi = dt.Rows[0]["Toleransi"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["Toleransi"]);

                    // Update JamMasuk & JamKeluar (expected end) + status ENTER-IN
                    controllerTrans.UpdateOrderStatusTiketandTime(tid, noUrut, waktuBermain, toleransi, "ENTER-IN");

                    // Buka gate
                    SendGateReply(port, gateCode, true, "SELAMAT DATANG");

                    RefreshReminderCore();
                }
                else
                {
                    SendGateReply(port, gateCode, false, "TIDAK ADA TIKET / SDH DIGUNAKAN");
                }
                _suppressReminderPopup = false;
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[ENTER Error] " + ex.Message;
                SendGateReply(port, gateCode, false, "ERROR");
                _suppressReminderPopup = false;
            }

        }

        private void HandleExit(string rfid, int gateCode, SerialPort port)
        {
            _suppressReminderPopup = true;

            try
            {
                // 1) Ambil tiket yang sedang ENTER-IN hari ini
                dt = controllerTrans.GetTicketByRFID(rfid, "ENTER-IN", startDay, endDay);

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

                // 2) Kalau jamKeluar belum ada (harusnya sudah ada saat ENTER-IN)
                if (jamKeluar == DateTime.MinValue)
                {
                    // pilih behavior: tolak keluar atau izinkan keluar
                    // aku sarankan tolak karena tidak ada patokan waktu
                    SendGateReply(port, gateCode, false, "JAM KELUAR BELUM ADA");
                    RefreshReminderCore();
                    return;
                }

                // 3) Hitung RED: lewat jamKeluar + toleransi
                DateTime batasToleransi = jamKeluar.AddMinutes(toleransi);
                bool isRed = now > batasToleransi;

                // 4) Jika RED => wajib bayar denda dulu
                if (isRed)
                {
                    using (var frm = new FrmFinePunishment(tid, noUrut, rfid, jamKeluar, toleransi))
                    {
                        var result = frm.ShowDialog(this);

                        if (result != DialogResult.OK)
                        {
                            // tidak bayar => gate tutup & status tidak berubah
                            SendGateReply(port, gateCode, false, "BAYAR DENDA DULU");
                            RefreshReminderCore();
                            return;
                        }

                        // Optional: kalau kamu expose properti IsPaid / CreatedTRS di form, bisa dicek:
                        // if (!frm.IsPaid) { ... return; }
                    }
                }

                // 5) Boleh keluar (non-RED atau sudah bayar denda)
                controllerTrans.UpdateOrderStatusTiketOut(tid, noUrut, "ENTER-OUT");

                SendGateReply(port, gateCode, true, "TERIMA KASIH");
                RefreshReminderCore();
            }
            catch (Exception ex)
            {
                rtxDataIO.Text += "\n[EXIT Error] " + ex.Message;
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
            port.WriteLine(reply2);
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
    }
}
