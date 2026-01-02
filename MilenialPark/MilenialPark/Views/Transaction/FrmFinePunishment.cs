using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Master;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmFinePunishment : Form
    {
        private readonly ControllerTransaction _trans = new ControllerTransaction();

        private string _refTrt;
        private int _refNoUrut;
        private string _refRfid;
        private DateTime _jamKeluar;
        private int _toleransi;

        public string CreatedTRS { get; private set; } = "";
        public bool IsPaid { get; private set; } = false;

        public FrmFinePunishment()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmFinePunishment(string transactionid, int nourut, string rfid, DateTime JamKeluar, int toleransi)
        {
            InitializeComponent();
            WireEvents();

            _refTrt = transactionid;
            _refNoUrut = nourut;
            _refRfid = rfid;
            _jamKeluar = JamKeluar;
            _toleransi = toleransi;

            LoadHeaderInfo();
            RecalcFine();
        }

        private void WireEvents()
        {
            this.Load += FrmFinePunishment_Load;
            btnSave.Click += btnSave_Click;
            txtCardID.KeyDown += txtCardID_KeyDown;
        }

        private void FrmFinePunishment_Load(object sender, EventArgs e)
        {
            // sedikit styling kalau mau
            txtCardID.Focus();
        }

        private void LoadHeaderInfo()
        {
            lblTransactionID.Text = _refTrt;
            lblNoUrut.Text = _refNoUrut.ToString();
            lblRFID.Text = _refRfid;

            lblJamKeluar.Text = _jamKeluar == DateTime.MinValue ? "-" : _jamKeluar.ToString("dd/MM/yyyy HH:mm:ss");
            lblToleransi.Text = _toleransi.ToString() + " menit";
        }

        private void RecalcFine()
        {
            // contoh hitung telat (menit)
            // RED = lewat jamKeluar + toleransi
            DateTime now = DateTime.Now;
            DateTime limit = _jamKeluar.AddMinutes(_toleransi);

            int telatMenit = 0;
            if (_jamKeluar != DateTime.MinValue && now > limit)
                telatMenit = (int)Math.Ceiling((now - limit).TotalMinutes);

            lblTelat.Text = telatMenit + " menit";

            // Untuk sekarang DENDA fixed 5000 (1x) sesuai item JL-UI-013
            // Kalau nanti mau per-blok menit/jam, tinggal ubah di sini.
            decimal denda = 5000m;

            // format rupiah tanpa ,00
            lblDenda.Text = denda.ToString("#,##0");
        }

        private void txtCardID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.Handled = true;
            e.SuppressKeyPress = true;

            string cardId = (txtCardID.Text ?? "").Trim();
            if (cardId.Length == 0)
            {
                ClearCardInfo();
                return;
            }

            LoadCard(cardId);
        }

        private void ClearCardInfo()
        {
            lblCustomerName.Text = "-";
            lblCardBalance.Text = "0";
        }

        private void LoadCard(string cardId)
        {
            var row = _trans.GetCardRow(cardId);

            if (row == null)
            {
                MessageBox.Show("CardID tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearCardInfo();
                return;
            }

            string cust = Convert.ToString(row["CustomerName"] ?? "-");
            decimal saldo = row["Saldo"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Saldo"]);

            lblCustomerName.Text = cust;
            lblCardBalance.Text = saldo.ToString("#,##0"); // rupiah tanpa ,00
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validasi minimum
            if (string.IsNullOrWhiteSpace(_refTrt) || string.IsNullOrWhiteSpace(_refRfid))
            {
                MessageBox.Show("Data referensi TRT/RFID tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string shopId = ClsStaticVariable.ShopID; // kamu pakai ini di sistem
            if (string.IsNullOrWhiteSpace(shopId))
            {
                MessageBox.Show("ShopID belum dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cardId = (txtCardID.Text ?? "").Trim();
            string remarksUser = (txtRemarks.Text ?? "").Trim();

            // Insert transaksi TRS (SANKSI)
            string err = _trans.InsertTransactionSanksi(
                _refTrt,
                _refNoUrut,
                _refRfid,
                shopId,
                cardId,
                remarksUser
            );

            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kalau sukses, TRS id ada di controller (TransactionID property)
            CreatedTRS = _trans.TransactionID;
            IsPaid = true;

            MessageBox.Show($"Sanksi berhasil dibuat.\nTRS: {CreatedTRS}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
