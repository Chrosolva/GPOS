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
using MilenialPark.Master;
using MilenialPark.Views;
using QRCoder;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmOrderTiket : Form
    {
        public Mainform parentfrm;
        public ControllerShop controllerShop = new ControllerShop();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public ControllerUser controllerUser = new ControllerUser();
        public BindingSource bind = new BindingSource();
        public BindingSource bind2 = new BindingSource();
        public string filepath;
        public DataTable dt2 = new DataTable();
        public DataTable dt = new DataTable();
        DateTime from;
        DateTime to;
        string SearchCard = "";

        public DataSet ds = new DataSet();
        public DataSet dsQR = new DataSet();
        public ReportDocument reportQRDoc2 = new ReportDocument();
        public ControllerReport controllerReport = new ControllerReport();

        public ReportDocument reportDoc = new ReportDocument();
        public string substring3;

        public FrmOrderTiket()
        {
            InitializeComponent();
        }

        public FrmOrderTiket(Mainform parent)
        {
            parentfrm = parent;
            InitializeComponent();
        }

        private void LoadUniversalShop()
        {
            // Ensure ShopID is set
            if (string.IsNullOrEmpty(ClsStaticVariable.ShopID))
            {
                ClsFungsi.Pesan("Maaf, belum ada shop yang dipilih!", "ERROR");
                // Disable editing and deleting if no shop
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            // Get shop info by ShopID
            controllerShop.getcashier2(ClsStaticVariable.ShopID);
            if (string.IsNullOrEmpty(controllerShop.objShop.ShopName?.Trim()))
            {
                ClsFungsi.Pesan("Maaf, shop universal tidak ditemukan!", "ERROR");
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            // Update labels in the main form
            parentfrm.lblShopID.Visible = true;
            parentfrm.lblShopName.Visible = true;
            parentfrm.lblMainProduct.Visible = true;
            parentfrm.lblAddress.Visible = true;

            parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
            parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
            parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
            parentfrm.lblAddress.Text = controllerShop.objShop.Address;

            // Enable editing and deleting tickets
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmNEOrderTiket frmNEOrderTiket = new FrmNEOrderTiket(parentfrm.lblShopID.Text);
            frmNEOrderTiket.Tag = "ADD";
            frmNEOrderTiket.lblFormTitle.Text = "Add Tiket Order";
            frmNEOrderTiket.btnAddorEdit.Image = Resource.tab;
            frmNEOrderTiket.btnAddorEdit.Text = "Create";

            //FormBlank frmBlank = new FormBlank();
            //frmBlank.Show();
            frmNEOrderTiket.ShowDialog();
            //frmBlank.Close();
            //getShop();

            btnFilter_Click(sender, e);
        }

        public void setcbxUser()
        {
            cbxUserID.Items.Clear();

            dt = controllerUser.getListUser();
            cbxUserID.DisplayMember = "Text";
            cbxUserID.ValueMember = "Value";
            cbxUserID.Items.Add(new { Text = "ALL", Value = "" });
            int selected = 0;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    cbxUserID.Items.Add(new { Text = dt.Rows[i]["UserName"].ToString(), Value = dt.Rows[i]["UserID"].ToString() });
                }
            }
            cbxUserID.SelectedIndex = selected;
        }

        private void FrmOrderTiket_Load(object sender, EventArgs e)
        {
            setcbxUser();
            from = dtpFrom.Value;
            to = dtpTo.Value;
            cbxOption.SelectedIndex = 0;
            cbxTransType.SelectedIndex = 0;
            //hasShop();
            LoadUniversalShop();
            btnFilter_Click(null, null);
        }

        public void hasShop()
        {
            if (controllerShop.checkCashier(ClsStaticVariable.controllerUser.objUser.UserID))
            {
                //btnCreate.Enabled = false;
                btnEdit.Enabled = true;
                controllerShop.getcashier(ClsStaticVariable.controllerUser.objUser.UserID);
                if (controllerShop.objShop.ShopName.Trim() != "")
                {
                    parentfrm.lblShopID.Visible = true;
                    parentfrm.lblShopName.Visible = true;
                    parentfrm.lblMainProduct.Visible = true;
                    parentfrm.lblAddress.Visible = true;

                    parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                    parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                    parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                    parentfrm.lblAddress.Text = controllerShop.objShop.Address;
                }
                btnDelete.Enabled = true;
            }
            else
            {
                //btnCreate.Enabled = true;
                btnEdit.Enabled = false;
                //btnImport.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        public void btnFilter_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text.Trim().Length == 0)
            {
                SearchCard = ""; 
            }
            else
            {
                SearchCard = txtCardID.Text;
            }

            controllerTrans.dt = controllerTrans.getTransaction2(
                           "", // ← ALL ShopID
                            new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0),
                            new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59),
                            SearchCard,
                            cbxOption.Text,
                            cbxTransType.Text,  // if this is "ALL" or "%%", function treats it as ALL
                            Convert.ToString((cbxUserID.SelectedItem as dynamic).Value)// ← ALL UserID
                        );
            //controllerTrans.dt = controllerTrans.getTransaction2(parentfrm.lblShopID.Text, new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0), new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59), SearchCard, cbxOption.Text, cbxTransType.Text.Replace("ALL", "%%"));
            if (controllerTrans.dt.Rows.Count > 0)
            {
                bind.DataSource = controllerTrans.dt;
                dgvTransTiket.DataSource = bind;

                if (dgvTransTiket.CurrentRow != null && dgvTransTiket.CurrentRow.Cells["TransactionID"].Value != null)
                {
                    dt2 = controllerTrans.gettransactionTiketDetail(dgvTransTiket.CurrentRow.Cells["TransactionID"].Value.ToString());
                    bind2.DataSource = dt2;
                    dgvTransTiketDetail.DataSource = bind2;
                }
            }

            // Disable sorting for all columns so header clicks don't change CurrentRow
            foreach (DataGridViewColumn col in dgvTransTiket.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgvTransTiket_SelectionChanged(object sender, EventArgs e)
        {
            // Bail out if there is no row selected
            if (dgvTransTiket.CurrentRow == null || dgvTransTiket.CurrentRow.IsNewRow)
            {
                return;
            }

            // Bail out if the cell value is null
            object val = dgvTransTiket.CurrentRow.Cells["TransactionID"].Value;
            if (val == null)
            {
                return;
            }

            // Safe to use the value now
            string transactionID = val.ToString();
            dt2 = controllerTrans.gettransactionTiketDetail(transactionID);
            bind2.DataSource = dt2;
            dgvTransTiketDetail.DataSource = bind2;
        }

        private void btnPrintQR_Click(object sender, EventArgs e)
        {
            if(dgvTransTiket.Rows.Count > 0)
            {
                string tmp;
                string tmp2;
                List<string> listqrcode = new List<string>();
                List<string> listitemname = new List<string>();
                // get list ticket and 
                foreach (DataGridViewRow row in dgvTransTiketDetail.Rows)
                {
                    if(row.Cells["category"].Value.ToString() != "ACTIVITY")
                    {
                        tmp = "(&" + row.Cells["TransactionID"].Value.ToString() + "&" + row.Cells["NoUrut"].Value.ToString() + ")";
                        tmp2 = row.Cells["ItemName"].Value.ToString();
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

                dsQR = controllerTrans.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
                // Show or Print Tiket 

                reportQRDoc2 = new PrintQRCode();
                reportQRDoc2.SetDataSource(dsQR);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
                if (result == DialogResult.Yes)
                {
                    if(listQrCodes.Count > 0)
                    {
                        PrintQRCode(reportQRDoc2);
                    }
                    else
                    {
                        
                    }
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

        private void btnExtendTicket_Click(object sender, EventArgs e)
        {
            if(dgvTransTiketDetail.Rows.Count > 0 && dgvTransTiketDetail.CurrentRow.Cells["OrderStatus"].Value.ToString() == "OVERTIME")
            {
                FrmChangeTicketStatus frmCTStatus = new FrmChangeTicketStatus(dgvTransTiketDetail.CurrentRow.Cells["TransactionID"].Value.ToString(), Convert.ToInt32(dgvTransTiketDetail.CurrentRow.Cells["NoUrut"].Value), parentfrm.lblShopID.Text);
                frmCTStatus.ShowDialog();

                btnFilter_Click(null, null);
            }
            else
            {
                ClsFungsi.Pesan("Maaf tidak ada baris pada tabel detail tiket atau status tiket bukan OVERTIME", "INFO");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if(dgvTransTiket.Rows.Count != 0)
                {
                    
                }
            }
            else
            {
                ClsFungsi.Pesan("Maaf Anda Bukan Admin !!!");
            }
        }

        private void btnPrintStruk_Click(object sender, EventArgs e)
        {
            if (dgvTransTiket.Rows.Count != 0)
            {
                //ClsTransaction objtrans = trans;

                DateTime from = dtpFrom.Value;
                DateTime to = dtpTo.Value;
                ds = controllerReport.LoadTransactionReceipt2(dgvTransTiket.CurrentRow.Cells["TransactionID"].Value.ToString(), parentfrm.lblShopID.Text, new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
                string sub3 = dgvTransTiket.CurrentRow.Cells["TransactionID"].Value.ToString().Substring(0, 3);
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
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(cbxOption.Text == "CardID")
                {
                    txtCardID.Text = Convert.ToInt32(txtCardID.Text).ToString();
                }
                else
                {
                    txtCardID.Text = txtCardID.Text;
                }

                btnFilter_Click(null, null);
            }

            
        }

        private void cbxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dgvTransTiket.Rows.Count > 0)
            {

                string tmp;
                string tmp2;
                List<string> listqrcode = new List<string>();
                List<string> listitemname = new List<string>();
                // get list ticket and 
                foreach (DataGridViewRow row in dgvTransTiketDetail.Rows)
                {
                    if (row.Cells["category"].Value.ToString() != "ACTIVITY")
                    {
                        tmp = "(&" + row.Cells["TransactionID"].Value.ToString() + "&" + row.Cells["NoUrut"].Value.ToString() + ")";
                        tmp2 = row.Cells["ItemName"].Value.ToString();
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

                dsQR = controllerTrans.LoadListQRCodes(listQrCodes, listqrcode, listitemname);
                // Show or Print Tiket 

                reportQRDoc2 = new PrintQRCode();
                reportQRDoc2.SetDataSource(dsQR);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Data Ticket berhasil Diload !!! \n Lanjut Cetak Ticket ?", "Print Ticket ? ", buttons);
                if (result == DialogResult.Yes)
                {
                    Reports.FrmShowReport formListItem = new Reports.FrmShowReport(reportQRDoc2);
                    formListItem.ShowDialog();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmScanQRCODE frmScan = new FrmScanQRCODE();
            frmScan.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "SuperAdmin" || ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if (dgvTransTiket.CurrentRow == null)
                {
                    MessageBox.Show("Please select a transaction to cancel.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get TransactionID from current row
                string transactionID = dgvTransTiket.CurrentRow.Cells["TransactionID"].Value?.ToString();

                if (string.IsNullOrEmpty(transactionID))
                {
                    MessageBox.Show("Invalid TransactionID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to cancel Transaction: {transactionID} ?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE WHNPOS.dbo.Transaksi " +
                                       "SET TransactionStatus = 'CANCELED' " +
                                       $"WHERE TransactionID = {ClsFungsi.C2Q(transactionID)}";

                        ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);

                        MessageBox.Show("Transaction successfully canceled.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optionally refresh grid after update
                        btnFilter_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Maaf Kamu tidak punya hak akses untuk tombol ini ");
            }
        }

    }
}
