using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Models;
using MilenialPark.Master;
using MilenialPark.UserControls;
//using QRCoder;
using CrystalDecisions.CrystalReports.Engine;
using MilenialPark.Views.Reports;
using MilenialPark.Reports;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmPayment : Form
    {
        #region properties

        public ControllerTransaction controllerTran = new ControllerTransaction();
        public ClsTransaction objtrans = new ClsTransaction();
        public ControllerReport controllerReport = new ControllerReport();
        public ReportDocument reportDoc = new ReportDocument();
        public ReportDocument reportQRDoc2 = new ReportDocument();
        bool Mastercard = false;
        public string CustomerName;
        public DataTable dt;
        public DataSet ds;
        public DataSet dsQR;


        #endregion
        public FrmPayment()
        {
            InitializeComponent();
        }
        public FrmPayment(ControllerTransaction trans)
        {
            InitializeComponent();
            this.controllerTran = trans;
            lblTotal.Text = controllerTran.objTransaction.totalAmount.ToString("#,##0");
            lblTransactionID.Text = controllerTran.objTransaction.TransactionID;
            cbxPaymentType.SelectedIndex = 0;
            cbxTransType.Text = controllerTran.objTransaction.TransactionType;
        }

        private void cbxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void scan()
        {
            txtCardID.Text = Convert.ToInt32(txtCardID.Text).ToString();
            controllerTran.dt = controllerTran.getCard(txtCardID.Text);
            controllerTran.SetCard(txtCardID.Text);
            CustomerName = controllerTran.objCard.CustomerName;
            // check MasterCard 
            // Decide if this card is a master card
            Mastercard = controllerTran.objCard.CustomerName.StartsWith("MASTER_CARD");
            cbxPaymentType.SelectedIndex = Mastercard ? 1 : 0;
            cbxRemarks.Enabled = Mastercard;


            if (controllerTran.dt.Rows.Count == 0)
            {
                ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
            }
            else
            {
                controllerTran.objCard = new ClsCard(controllerTran.dt.Rows[0]["CardID"].ToString(), controllerTran.dt.Rows[0]["CustomerName"].ToString(), controllerTran.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTran.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTran.dt.Rows[0]["Active"]));
                lblCustomerName.Text = controllerTran.objCard.CustomerName;
                lblCardBalance.Text = controllerTran.objCard.Saldo.ToString("#,##0");
            }
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                scan();  
            }
        }

        public void missingRFID()
        {
            // ✅ Validate: all ticket rows must have RFID before saving
            int missingCount = 0;
            List<int> missingNoUrut = new List<int>();

            foreach (DataGridViewRow r in dgvTransacTiketDet.Rows)
            {
                if (r.IsNewRow) continue;

                string rfid = Convert.ToString(r.Cells["RFID"].Value)?.Trim();
                if (string.IsNullOrEmpty(rfid))
                {
                    missingCount++;
                    // collect NoUrut for message (if column exists)
                    if (r.Cells["NoUrut"].Value != null)
                        missingNoUrut.Add(Convert.ToInt32(r.Cells["NoUrut"].Value));
                }
            }

            if (missingCount > 0)
            {
                // Focus first missing row
                var firstMissing = dgvTransacTiketDet.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => !r.IsNewRow && string.IsNullOrWhiteSpace(Convert.ToString(r.Cells["RFID"].Value)));

                if (firstMissing != null)
                {
                    dgvTransacTiketDet.CurrentCell = firstMissing.Cells["RFID"];
                    dgvTransacTiketDet.ClearSelection();
                    firstMissing.Selected = true;
                }

                string detail = (missingNoUrut.Count > 0)
                    ? " NoUrut: " + string.Join(", ", missingNoUrut.Take(10)) + (missingNoUrut.Count > 10 ? "..." : "")
                    : "";

                ClsFungsi.Pesan($"RFID belum lengkap! Masih ada {missingCount} tiket belum di-scan.{detail}", "ERROR");

                // return focus to RFID scan box (your helper)
                BeginInvoke(new Action(FocusRFIDScan));

                btnSave.Enabled = true;
                return;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            missingRFID();

            decimal totalAmount = Convert.ToDecimal(lblTotal.Text);
            decimal balance = Convert.ToDecimal(lblCardBalance.Text);

            decimal selisih = Convert.ToDecimal(lblCardBalance.Text) - Convert.ToDecimal(lblTotal.Text);
            if (cbxPaymentType.Text == "CARD" && balance < totalAmount)
            {
                ClsFungsi.Pesan("Saldo kartu tidak cukup!", "ERROR");
                btnSave.Enabled = true;
                return;
            }
            else
            {
                if (MessageBox.Show($"Simpan transaksi {lblTransactionID.Text} dengan jumlah {totalAmount} ?",
                                "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    btnSave.Enabled = true;
                    return;
                }
                scan();

                //regenerate and substitute transactionID 
                controllerTran.AutogenereateTransactionID("TICKET", controllerTran.objTransaction.ShopId);
                controllerTran.objTransaction.TransactionID = controllerTran.TransactionID;
                controllerTran.objTransaction.TransactionType = cbxTransType.Text;

                // Update transaction details (non-ticket items)
                foreach (var det in controllerTran.objTransaction.listtransdet)
                    det.TransactionID = controllerTran.TransactionID;

                // ===== 2) BUILD listtranstikdet FROM BOTH GRIDS =====
                controllerTran.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();

                int nourut = 1;

                // A) Ticket grid (RFID + waktu bermain)
                foreach (DataGridViewRow row in dgvTransacTiketDet.Rows)
                {
                    if (row.IsNewRow) continue;

                    string itemId = Convert.ToString(row.Cells["ItemID"].Value);
                    string itemName = Convert.ToString(row.Cells["ItemName"].Value);
                    decimal price = ToDecimalSafe(row.Cells["Price"].Value);
                    int qty = ToIntSafe(row.Cells["Qty"].Value);             // should be 1 per row (your requirement)
                    int waktu = ToIntSafe(row.Cells["WaktuBermain"].Value);
                    int toleransi = ToIntSafe(row.Cells["Toleransi"].Value);
                    string rfid = Convert.ToString(row.Cells["RFID"].Value); // may be null / empty
                    string keterangan = Convert.ToString(row.Cells["Keterangan"].Value); // may be null / empty

                    var det = new ClsTransactionTiketDetail(
                        controllerTran.TransactionID,
                        DateTime.Now,
                        itemId,
                        itemName,
                        price,
                        qty,
                        nourut,
                        "BOUGHT",
                        DateTime.Now,
                        DateTime.Now,
                        waktu,
                        toleransi
                    );

                    // if your constructor doesn't include RFID, set property like this:
                    det.RFID = rfid;
                    det.Keterangan = keterangan;

                    controllerTran.objTransaction.listtranstikdet.Add(det);
                    nourut++;
                }

                // B) Non-ticket grid -> STILL INSERT INTO TransaksiTiketDetail (as you want)
                // Here waktu bermain = 0, toleransi = 0, RFID = null
                foreach (DataGridViewRow row in dgvTransaksiDetail.Rows)
                {
                    if (row.IsNewRow) continue;

                    string itemId = Convert.ToString(row.Cells["dataGridViewTextBoxColumn3"].Value);  // ItemID
                    string itemName = Convert.ToString(row.Cells["dataGridViewTextBoxColumn4"].Value); // ItemName
                    decimal price = ToDecimalSafe(row.Cells["Price2"].Value); // Price
                    int qty = ToIntSafe(row.Cells["Qty2"].Value); // Qty

                    var det = new ClsTransactionTiketDetail(
                        controllerTran.TransactionID,
                        DateTime.Now,
                        itemId,
                        itemName,
                        price,
                        qty,
                        nourut,
                        "BOUGHT",
                        DateTime.Now,
                        DateTime.Now,
                        0,   // WaktuBermain
                        0    // Toleransi
                    );

                    det.RFID = null; // non-ticket has no RFID

                    controllerTran.objTransaction.listtranstikdet.Add(det);
                    nourut++;
                }

                // Populate payment fields
                controllerTran.objTransaction.CardID = txtCardID.Text;
                controllerTran.objTransaction.PaymentType = cbxPaymentType.Text;
                controllerTran.objTransaction.Remarks = txtRemarks.Text;
                controllerTran.objTransaction.InitialBalance = (cbxPaymentType.Text == "CARD") ? controllerTran.objCard.Saldo : 0;

                //Insert Transaksi
                //ClsFungsi.Pesan(, "INFO");
                // Total Amount Check 
                // Sum ticket items
                decimal sumTickets = dgvTransacTiketDet.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Sum(r => Convert.ToDecimal(r.Cells["Price"].Value) *
                              Convert.ToDecimal(r.Cells["Qty"].Value));

                // Sum non‑ticket items
                decimal sumDetails = dgvTransaksiDetail.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Sum(r => Convert.ToDecimal(r.Cells["Price2"].Value) *
                              Convert.ToDecimal(r.Cells["Qty2"].Value));

                // Check if combined total matches the transaction total
                decimal sumCheck = sumTickets + sumDetails;
                if (sumCheck != controllerTran.objTransaction.totalAmount)
                {
                    ClsFungsi.Pesan("Total tidak cocok dengan detail tiket dan detail item.", "ERROR");
                    btnSave.Enabled = true;
                    return;
                }


                // Log and insert
                controllerTran.InsertLogMessage(controllerTran.TransactionID, "PRECHECK OK");
                try
                {
                    controllerTran.InsertTransactionTicket(controllerTran.objTransaction, controllerTran.objCard);
                    ClsStaticVariable.sukses = true;
                    PrintStruck(controllerTran); // always print receipt
                }
                catch (Exception ex)
                {
                    ClsFungsi.Pesan("Error saat menyimpan transaksi: " + ex.Message, "ERROR");
                }

                btnSave.Enabled = true;
                this.Close();
            }
        }

        // ===== helpers =====
        private decimal ToDecimalSafe(object v)
        {
            if (v == null) return 0m;
            decimal d;
            return decimal.TryParse(v.ToString(), out d) ? d : 0m;
        }

        private int ToIntSafe(object v)
        {
            if (v == null) return 0;
            int i;
            return int.TryParse(v.ToString(), out i) ? i : 0;
        }

        private void FocusRFIDScan()
        {
            if (!txtRFIDScan.Enabled || !txtRFIDScan.Visible) return;

            txtRFIDScan.Focus();
            txtRFIDScan.SelectAll();   // so next scan overwrites immediately
        }


        //public void PrintQR(ControllerTransaction trans)
        //{
        //    string tmp;
        //    string tmp2;
        //    List<string> listqrcode = new List<string>();
        //    List<string> listitemname = new List<string>();
        //    // get list ticket and 
        //    dt = controllerTran.gettransactionTiketDetail(trans.objTransaction.TransactionID);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["category"].ToString() != "ACTIVITY")
        //        {
        //            tmp = "(&" + row["TransactionID"].ToString() + "&" + row["NoUrut"].ToString() + ")";
        //            tmp2 = row["ItemName"].ToString();
        //            listqrcode.Add(tmp);
        //            listitemname.Add(tmp2);
        //        }
        //    }
        //    //ClsFungsi.Pesan(listqrcode.ToString(), "INFO");
        //    // generate qrcode 
        //    List<byte[]> listQrCodes = new List<byte[]>();
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();

        //    foreach (String t in listqrcode)
        //    {
        //        QRCodeData qrCodeData = qrGenerator.CreateQrCode(t, QRCodeGenerator.ECCLevel.Q);
        //        QRCode qrCode = new QRCode(qrCodeData);
        //        Bitmap qrCodeImage = qrCode.GetGraphic(5);

        //        byte[] yourByteArray;
        //        using (var mStream = new System.IO.MemoryStream())
        //        {
        //            qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
        //            yourByteArray = mStream.ToArray();
        //            listQrCodes.Add(yourByteArray);
        //        }
        //    }

        //    dsQR = controllerTran.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
        //    // Show or Print Tiket 

        //    reportQRDoc2 = new PrintQRCode();
        //    reportQRDoc2.SetDataSource(dsQR);

        //    //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //    //DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
        //    //if (result == DialogResult.Yes)
        //    //{

        //    //}
        //    //else
        //    //{

        //    //}

        //    if (listQrCodes.Count > 0)
        //    {
        //        PrintQRCode(reportQRDoc2);
        //    }
        //    else
        //    {

        //    }
        //    //// check transaction type 
        //    //if (dgvTransTiket.CurrentRow.Cells["TransactionType"].Value.ToString() == "ONE-TIME-TICKET")
        //    //{

        //    //}
        //    //else
        //    //{
        //    //    ClsFungsi.Pesan("Tidak bisa mencetak QRCode karena tiket tersebut bukan ONE TIME TICKET, silahkan gunakan kartu untuk masuk", "INFO");
        //    //}
        //}

        public void PrintQRCode(ReportDocument reportQRDoc)
        {

            if (reportQRDoc != null)
            {
                //Reports.FrmShowReport formListItem = new Reports.FrmShowReport(reportQRDoc);
                //formListItem.ShowDialog();
                reportQRDoc.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                MessageBox.Show("Tidak ada QRCode yang akan di cetak");
            }
        }

        public void PrintStruck(ControllerTransaction trans)
        {
            ds = controllerReport.LoadTransactionReceipt2(trans.objTransaction.TransactionID, trans.objTransaction.ShopId, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
            string sub3 = trans.objTransaction.TransactionID.ToString().Substring(0, 3);
            if (sub3 == "TRK" || sub3 == "TRR")
            {
                reportDoc = new MilenialPark.Reports.PrintTopUpReceipt();
            }
            else
            {
                reportDoc = new MilenialPark.Reports.PrintTransactionReceipt();
            }
            reportDoc.SetDataSource(ds);

            //FrmShowReport frmShowReport = new FrmShowReport(reportDoc);
            //FormBlank frmBlank = new FormBlank();
            //frmBlank.Show();
            //frmShowReport.ShowDialog();
            //frmBlank.Close();

            reportDoc.PrintToPrinter(1, false, 0, 0);
        }

        private void cbxRemarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRemarks.SelectedIndex > 0)
            {
                txtRemarks.Text = cbxRemarks.Text + " : ";
            }
            else if (cbxRemarks.SelectedIndex < 0)
            {
                txtRemarks.Text = "";
            }
        }

        public void generatetransacttiketdetail(ClsTransactionTiketDetail det)
        {
            for (int i = 0; i < det.Qty; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvTransacTiketDet.Rows[0].Clone();
                row.Cells[0].Value = lblTransactionID.Text;
                row.Cells[1].Value = "";
                row.Cells[2].Value = "";
                row.Cells[3].Value = DateTime.Now;
                row.Cells[4].Value = det.ItemId;
                row.Cells[5].Value = det.ItemName;
                row.Cells[6].Value = det.Price;
                row.Cells[7].Value = 1;               // Always 1
                row.Cells[8].Value = i + 1;           // NoUrut increments
                row.Cells[9].Value = "TMP";
                row.Cells[10].Value = DateTime.Now;    // JamMasuk
                row.Cells[11].Value = DateTime.Now;    // JamKeluar
                row.Cells[12].Value = det.WaktuBermain;
                row.Cells[13].Value = det.Toleransi;
                dgvTransacTiketDet.Rows.Add(row);
            }
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            foreach (ClsTransactionTiketDetail det in controllerTran.objTransaction.listtranstikdet)
            {
                if (det.WaktuBermain > 0)
                {
                    // Always generate one row per ticket
                    generatetransacttiketdetail(det);
                }
                else
                {
                    dgvTransaksiDetail.Rows.Add(
                    controllerTran.objTransaction.TransactionID,
                    DateTime.Now,
                    det.ItemId,
                    det.ItemName,
                    det.Price,
                    det.Qty,
                    1,             // NoUrut
                    det.OrderStatus ?? "TMP",
                    DateTime.Now,
                    DateTime.Now,
                    0,  // WaktuBermain
                    0   // Toleransi
                );
                }
                    
            }

            cbxRemarks.SelectedIndex = 0;
            cbxRemarks.Enabled = false;

            DataGridViewHelper.ApplyPOSStyle(dgvTransacTiketDet, false, true);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvTransacTiketDet, 100, 420);

            DataGridViewHelper.ApplyPOSStyle(dgvTransaksiDetail);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvTransaksiDetail, 100, 420);

            // At initialization time (e.g. in FrmPayment_Load or after InitializeComponent)
            dgvTransacTiketDet.ReadOnly = false;

            // Assuming the RFID column has the name "RFID" and Keterangan is "Keterangan"
            dgvTransacTiketDet.Columns["RFID"].ReadOnly = true;
            dgvTransacTiketDet.Columns["Keterangan"].ReadOnly = false; // Make sure it's not read‑only
        }

        private void txtRFIDScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtRFIDScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;

            if (dgvTransacTiketDet.CurrentRow == null) return;

            string rfid = txtRFIDScan.Text.Trim();
            if (string.IsNullOrEmpty(rfid)) return;

            // Optional: prevent duplicate RFID
            bool exists = dgvTransacTiketDet.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow &&
                          Convert.ToString(r.Cells["RFID"].Value) == rfid);

            if (exists)
            {
                ClsFungsi.Pesan("RFID sudah digunakan!", "WARNING");
                FocusRFIDScan();
                return;
            }

            // ----- New check: ensure this RFID is not already used in a persisted transaction -----
            DateTime startDay = DateTime.Today;
            DateTime endDay = DateTime.Today.AddDays(1).AddTicks(-1);

            // Check both BOUGHT and ENTER‑IN statuses
            bool usedInDb =
                (controllerTran.GetTicketByRFID(rfid, "BOUGHT", startDay, endDay)?.Rows.Count ?? 0) > 0 ||
                (controllerTran.GetTicketByRFID(rfid, "ENTER-IN", startDay, endDay)?.Rows.Count ?? 0) > 0;

            if (usedInDb)
            {
                ClsFungsi.Pesan("RFID telah digunakan di transaksi lain!", "INFO");
                FocusRFIDScan();
                return;
            }
            // ------------------------------------------------------------------------------

            // Assign RFID to current row
            dgvTransacTiketDet.CurrentRow.Cells["RFID"].Value = rfid;

            // Auto move to next row
            int nextIndex = dgvTransacTiketDet.CurrentRow.Index + 1;
            if (nextIndex < dgvTransacTiketDet.Rows.Count)
            {
                dgvTransacTiketDet.CurrentCell =
                    dgvTransacTiketDet.Rows[nextIndex].Cells["RFID"];
            }

            txtRFIDScan.Clear();
            FocusRFIDScan();
        }


        private void dgvTransacTiketDet_SelectionChanged(object sender, EventArgs e)
        {
            // Make sure there is a valid current cell
            var cell = dgvTransacTiketDet.CurrentCell;
            if (cell == null)
            {
                return;
            }

            // Option 1: check by column name
            if (cell.OwningColumn != null && cell.OwningColumn.Name == "RFID")
            {
                BeginInvoke(new Action(FocusRFIDScan));
            }

        }

    }
}
