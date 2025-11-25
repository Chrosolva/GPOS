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
using QRCoder;
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
            if (CustomerName == "MASTER_CARD1")
            {
                cbxPaymentType.SelectedIndex = 1;
                Mastercard = true;
                cbxRemarks.Enabled = true;
            }
            else if (CustomerName == "MASTER_CARD2")
            {
                cbxPaymentType.SelectedIndex = 1;
                Mastercard = true;
                cbxRemarks.Enabled = true;
            }
            else
            {
                cbxPaymentType.SelectedIndex = 0;
                Mastercard = false;
                cbxRemarks.Enabled = false;
                cbxRemarks.SelectedIndex = 0;
            }


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            decimal selisih = Convert.ToDecimal(lblCardBalance.Text) - Convert.ToDecimal(lblTotal.Text);
            if (cbxPaymentType.Text =="CARD" && Convert.ToDecimal(lblCardBalance.Text) == 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda kosong , silahkan diisi terlebih dahulu !!!", "INFO");
            }
            else if (cbxPaymentType.Text == "CARD" &&  selisih < 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda tidak cukup , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menyimpan data Transaksi dengan ID  " + lblTransactionID.Text + " ? " +
                    " Dengan Jumlah Sebanyak = " + lblTotal.Text.ToString() , "Warning", MessageBoxButtons.YesNo);
                scan();

                if (dialogResult == DialogResult.Yes)
                {
                    //regenerate and substitute transactionID 
                    controllerTran.AutogenereateTransactionID("TICKET", controllerTran.objTransaction.ShopId);
                    controllerTran.objTransaction.TransactionID = controllerTran.TransactionID;
                    controllerTran.objTransaction.TransactionType = cbxTransType.Text;
                    foreach (ClsTransactionDetail det in controllerTran.objTransaction.listtransdet)
                    {
                        det.TransactionID = controllerTran.TransactionID;
                    }

                    controllerTran.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();
                    // set Detail Transaksi 

                    int index  = 0;
                    foreach (DataGridViewRow row in dgvTransacTiketDet.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            controllerTran.objTransactionTiketDetail = new ClsTransactionTiketDetail(lblTransactionID.Text, DateTime.Now, row.Cells["ItemID"].Value.ToString(), row.Cells["ItemName"].Value.ToString(), Convert.ToDecimal(row.Cells["Price"].Value), Convert.ToInt32(row.Cells["Qty"].Value), "BOUGHT", DateTime.Now, DateTime.Now, Convert.ToInt32(row.Cells["WaktuBermain"].Value), Convert.ToInt32(row.Cells["Toleransi"].Value));
                            controllerTran.objTransaction.listtranstikdet.Add(controllerTran.objTransactionTiketDetail);
                        }
                    }

                    if (cbxPaymentType.Text == "CARD")
                    {
                        controllerTran.objTransaction.CardID = txtCardID.Text;
                        controllerTran.objTransaction.Remarks = txtRemarks.Text;
                        controllerTran.objTransaction.PaymentType = cbxPaymentType.Text;
                        controllerTran.objTransaction.InitialBalance = controllerTran.objCard.Saldo;
                    }
                    else
                    {
                        controllerTran.objTransaction.CardID = txtCardID.Text;
                        controllerTran.objTransaction.Remarks = txtRemarks.Text;
                        controllerTran.objTransaction.PaymentType = cbxPaymentType.Text;
                        controllerTran.objTransaction.InitialBalance = 0;
                    }



                    //Insert Transaksi
                    //ClsFungsi.Pesan(, "INFO");
                    // Total Amount Check 
                    decimal totalchecking = 0;
                    string itemchecking = "";
                    int i = 1;
                    foreach(DataGridViewRow row in dgvTransacTiketDet.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            decimal tmp = Convert.ToDecimal(row.Cells["Price"].Value) * Convert.ToDecimal(row.Cells["Qty"].Value);
                            totalchecking += tmp;
                            itemchecking += "Item-" + i.ToString() + " :ID = " + row.Cells["ItemID"].Value.ToString() + " Name = " + row.Cells["ItemName"].Value.ToString() + " Qty = " + row.Cells["Qty"].Value.ToString() + " Price = " + row.Cells["Price"].Value.ToString() + "Subtotal = " + tmp.ToString();
                            i++;
                        }
                         
                    }

                    string logmessage = "PRECHECK!";
                    logmessage += "TOTALAMOUNT = " + totalchecking.ToString();
                    logmessage += "ITEMCHECKING = " + itemchecking;

                    if(controllerTran.objTransaction.totalAmount == totalchecking)
                    {
                        try
                        {
                            controllerTran.InsertLogMessage(controllerTran.TransactionID, logmessage);
                            controllerTran.InsertTransactionTicket(controllerTran.objTransaction, controllerTran.objCard);
                            PrintQR(controllerTran);
                            PrintStruck(controllerTran);
                        }
                        catch (Exception ex)
                        {
                            ClsFungsi.Pesan("Terjadi Error Pada Penambahan Data Transaksi", ex.Message);
                        }
                    }
                    else
                    {
                        ClsFungsi.Pesan("Terjadi Perbedaan Data antara list tiket dan total amount , silahkan di tutup window pembayaran dan di load kembali !!!");
                    }


                    this.Close();
                }
                else if (dialogResult == DialogResult.No) { }
                btnSave.Enabled = true;
            }
        }

        public void PrintQR(ControllerTransaction trans)
        {
            string tmp;
            string tmp2;
            List<string> listqrcode = new List<string>();
            List<string> listitemname = new List<string>();
            // get list ticket and 
            dt = controllerTran.gettransactionTiketDetail(trans.objTransaction.TransactionID);
            foreach (DataRow row in dt.Rows)
            {
                if (row["category"].ToString() != "ACTIVITY")
                {
                    tmp = "(&" + row["TransactionID"].ToString() + "&" + row["NoUrut"].ToString() + ")";
                    tmp2 = row["ItemName"].ToString();
                    listqrcode.Add(tmp);
                    listitemname.Add(tmp2);
                }
            }
            //ClsFungsi.Pesan(listqrcode.ToString(), "INFO");
            // generate qrcode 
            List<byte[]> listQrCodes = new List<byte[]>();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            foreach (String t in listqrcode)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(t, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);

                byte[] yourByteArray;
                using (var mStream = new System.IO.MemoryStream())
                {
                    qrCodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    yourByteArray = mStream.ToArray();
                    listQrCodes.Add(yourByteArray);
                }
            }

            dsQR = controllerTran.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
            // Show or Print Tiket 

            reportQRDoc2 = new PrintQRCode();
            reportQRDoc2.SetDataSource(dsQR);

            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
            //if (result == DialogResult.Yes)
            //{

            //}
            //else
            //{

            //}

            if (listQrCodes.Count > 0)
            {
                PrintQRCode(reportQRDoc2);
            }
            else
            {

            }
            //// check transaction type 
            //if (dgvTransTiket.CurrentRow.Cells["TransactionType"].Value.ToString() == "ONE-TIME-TICKET")
            //{

            //}
            //else
            //{
            //    ClsFungsi.Pesan("Tidak bisa mencetak QRCode karena tiket tersebut bukan ONE TIME TICKET, silahkan gunakan kartu untuk masuk", "INFO");
            //}
        }

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
                //Clstr objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value), "NOTSERVED");
                row.Cells[0].Value = lblTransactionID.Text;
                row.Cells[1].Value = DateTime.Now;
                row.Cells[2].Value = det.ItemId;
                row.Cells[3].Value = det.ItemName;
                row.Cells[4].Value = det.Price;
                row.Cells[5].Value = 1;
                row.Cells[6].Value = i + 1;
                row.Cells[7].Value = "TMP";
                row.Cells[8].Value = DateTime.Now;
                row.Cells[9].Value = DateTime.Now;
                row.Cells[10].Value = det.WaktuBermain;
                row.Cells[11].Value = det.Toleransi;
                dgvTransacTiketDet.Rows.Add(row);
            }
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            cbxRemarks.SelectedIndex = 0;
            cbxRemarks.Enabled = false;

            foreach (ClsTransactionTiketDetail det in controllerTran.objTransaction.listtranstikdet)
            {
                controllerTran.dt = controllerTran.checkCategory2(det.ItemId);
                if (controllerTran.dt.Rows.Count > 0)
                {
                    string category = controllerTran.dt.Rows[0]["category"].ToString();
                    if (category == "WEEKDAY" || category == "WEEKEND" || category == "COMPANION")
                    {
                        generatetransacttiketdetail(det);
                    }
                    else if (category != "WEEKDAY" || category != "WEEKEND" || category != "COMPANION")
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvTransacTiketDet.Rows[0].Clone();
                        //Clstr objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value), "NOTSERVED");
                        row.Cells[0].Value = lblTransactionID.Text;
                        row.Cells[1].Value = DateTime.Now;
                        row.Cells[2].Value = det.ItemId;
                        row.Cells[3].Value = det.ItemName;
                        row.Cells[4].Value = det.Price;
                        row.Cells[5].Value = det.Qty;
                        row.Cells[6].Value = 1;
                        row.Cells[7].Value = "TMP";
                        row.Cells[8].Value = DateTime.Now;
                        row.Cells[9].Value = DateTime.Now;
                        row.Cells[10].Value = det.WaktuBermain;
                        row.Cells[11].Value = det.Toleransi;
                        dgvTransacTiketDet.Rows.Add(row);
                    }
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgvTransacTiketDet.Rows[0].Clone();
                    //Clstr objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value), "NOTSERVED");
                    row.Cells[0].Value = lblTransactionID.Text;
                    row.Cells[1].Value = DateTime.Now;
                    row.Cells[2].Value = det.ItemId;
                    row.Cells[3].Value = det.ItemName;
                    row.Cells[4].Value = det.Price;
                    row.Cells[5].Value = det.Qty;
                    row.Cells[6].Value = 1;
                    row.Cells[7].Value = "TMP";
                    row.Cells[8].Value = DateTime.Now;
                    row.Cells[9].Value = DateTime.Now;
                    row.Cells[10].Value = det.WaktuBermain;
                    row.Cells[11].Value = det.Toleransi;
                    dgvTransacTiketDet.Rows.Add(row);
                }
            }
        }
    }
}
