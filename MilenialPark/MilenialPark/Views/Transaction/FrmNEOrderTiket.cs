using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Master;
using MilenialPark.Models;
using MilenialPark.Controller;
using MilenialPark.UserControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;
using System.Drawing.Printing;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmNEOrderTiket : Form
    {
        #region properties

        public Mainform parentfrm;
        public ImageList imgList = new ImageList();
        public Image img;
        public ControllerShop controllerShop = new ControllerShop();
        public List<UCShopItem> listShopItem = new List<UCShopItem>();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public ControllerCard controllerCard = new ControllerCard();
        public ControllerReport controllerReport = new ControllerReport();
        public ClsShop objShop = new ClsShop();

        public ReportDocument reportDoc = new ReportDocument();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public bool exist = false;
        PrintDialog printdialog1 = new PrintDialog();
        PrintDocument printdocument = new PrintDocument();
        decimal balance = 0;
        decimal subtotal;
        decimal PPN;
        decimal totalamount;
        decimal finaltotalamount;
        decimal finalqty;
        string CardID;
        string CustomerName;
        bool overtimeexist = false;
        bool Mastercard = false;

        #endregion

        public FrmNEOrderTiket()
        {
            InitializeComponent();
        }

        public FrmNEOrderTiket(string ShopID)
        {
            controllerShop.ShopID = ShopID;
            InitializeComponent();
            lblShopID.Text = ShopID;

        }

        private void FrmNEOrderTiket_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (DateTime.Now.DayOfWeek.ToString().Equals("Saturday") || DateTime.Now.DayOfWeek.ToString().Equals("Sunday"))
            {
                cbxTransType.SelectedIndex = 1;
            }
            else
            {
                cbxTransType.SelectedIndex = 0;
            }

            cbxRemarks.SelectedIndex = 0;
            cbxRemarks.Enabled = false;
                
            //setCbxCategory(controllerShop.ShopID, cbxTransType.Text);
            controllerTrans.AutogenereateTransactionID("TICKET", lblShopID.Text);
            lblTransactionID.Text = controllerTrans.TransactionID;
            cbxPaymentType.SelectedIndex = 0;
            dgvTransacTiketDet.Rows.Clear();
        }

        public void setCbxCategory(string ShopID, string category)
        {
            dt = controllerShop.getShopItemTiket(ShopID, category);
            cbxCategory.Items.Clear();
            cbxCategory.DisplayMember = "Text";
            cbxCategory.ValueMember = "Value";
            int selected = 0;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    cbxCategory.Items.Add(new { Text = dt.Rows[i]["ItemName"].ToString(), Value = dt.Rows[i]["ItemID"].ToString() });
                }
            }
            cbxCategory.SelectedIndex = selected;
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxCategory.Items.Count != 0)
            {
                dt = controllerShop.getOneShopItemTiket(controllerShop.ShopID, Convert.ToString((cbxCategory.SelectedItem as dynamic).Value));
                lblItemID.Text = dt.Rows[0]["ItemID"].ToString();
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                txtItemDesc.Text = dt.Rows[0]["ItemDesc"].ToString();
                NUDprice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);    
                NUDWaktuBermain.Value = Convert.ToInt32(dt.Rows[0]["WaktuBermain"]);
                NUDToleransi.Value = Convert.ToInt32(dt.Rows[0]["Toleransi"]);
            }
        }

        public void calculateamount ()
        {
            subtotal = Convert.ToInt32(NUDQty.Value) * NUDprice.Value;
            PPN = (subtotal * NUDPPN.Value / 100);
            totalamount = (subtotal) + (PPN); 
            NUDTotalAmount.Value = totalamount;
        }

        public void calculatetotalamount()
        {
            if(dgvTransacTiketDet.Rows.Count > 1)
            {
                finaltotalamount = 0; 
                foreach(DataGridViewRow row in dgvTransacTiketDet.Rows)
                {
                    decimal tmp = Convert.ToDecimal(row.Cells[4].Value) * Convert.ToDecimal(row.Cells[5].Value);
                    finaltotalamount += tmp;
                }

                //Final Total Amount : 
                lblFinalTotalAmount.Text = "Final Total Amount : " + finaltotalamount.ToString("#,##0.00");
            }
        }

        public void generatetransacttiketdetail()
        {
            controllerTrans.objTransaction.listtransdet = new List<ClsTransactionDetail>();
            
            for (int i =0; i < Convert.ToInt32(NUDQty.Value); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvTransacTiketDet.Rows[0].Clone();
                //Clstr objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value), "NOTSERVED");
                row.Cells[0].Value = lblTransactionID.Text;
                row.Cells[1].Value = DateTime.Now;
                row.Cells[2].Value = lblItemID.Text;
                row.Cells[3].Value = txtItemName.Text;
                row.Cells[4].Value = NUDprice.Value;
                row.Cells[5].Value = 1;
                row.Cells[6].Value = i+1;
                row.Cells[7].Value = "TMP";
                row.Cells[8].Value = DateTime.Now;
                row.Cells[9].Value = DateTime.Now;
                row.Cells[10].Value = NUDWaktuBermain.Value;
                row.Cells[11].Value = NUDToleransi.Value;
                dgvTransacTiketDet.Rows.Add(row);
            }

            finalqty = (dgvTransacTiketDet.Rows.Count - 1);
            lblRowCount.Text = "Total Tiket : " + (dgvTransacTiketDet.Rows.Count - 1).ToString();

            // Calculate Total Amount 
            calculatetotalamount();
        }

        private void NUDQty_KeyUp(object sender, KeyEventArgs e)
        {
            // calculate total amount 
            calculateamount();
        }

        public void scan()
        {
            txtCardID.Text = Convert.ToInt32(txtCardID.Text).ToString();
            controllerTrans.dt = controllerTrans.getCard(txtCardID.Text);
            controllerTrans.SetCard(txtCardID.Text);

            if (controllerTrans.dt.Rows.Count == 0)
            {
                ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
            }
            else
            {
                controllerTrans.objCard = new ClsCard(controllerTrans.dt.Rows[0]["CardID"].ToString(), controllerTrans.dt.Rows[0]["CustomerName"].ToString(), controllerTrans.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTrans.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTrans.dt.Rows[0]["Active"]));
                lblCustomerName.Text = controllerTrans.objCard.CustomerName;
                CustomerName = controllerTrans.objCard.CustomerName;
                lblBalance.Text = "Balance (Saldo) : Rp. " + controllerTrans.objCard.Saldo.ToString("#,##0");
                balance = controllerTrans.objCard.Saldo;
                lblCardID.Text = "Card ID : " + controllerTrans.objCard.CardID;
                CardID = controllerTrans.objCard.CardID;
                lblIdentity.Text = "No (KTP/SIM) : " + controllerTrans.objCard.Noidentitas;
            }

            // check overtime today 
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            //dt = controllerTrans.checkOvertimetoday(txtCardID.Text, start, end);
            //if(dt.Rows.Count == 0)
            //{
            //    overtimeexist = false;
            //}
            //else
            //{
            //    overtimeexist = true;
            //}

            //if(overtimeexist)
            //{
            //    lblNote.Text = "Note : Kartu memiliki paket yang sudah overtime hari ini sehingga tidak bisa melakukan penambahan tiket, mohon di selesaikan dulu paket yang berjalan";
            //    ClsFungsi.Pesan(lblNote.Text , "INFO");
            //}

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
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                scan();  
            }
        }

        private void btnAddorEdit_Click(object sender, EventArgs e)
        {
            decimal selisih = balance - NUDTotalAmount.Value;
            // validasi simpan 
            if (lblTransactionID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Data tidak bisa disimpan karena tidak ada ID Transaksi");
            }
            else if (dgvTransacTiketDet.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak bisa disimpan karena tidak ada tiket untuk disimpan !");
            }
            else if (lblCardID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Data Kartu tidak ada , Silahkan Scan dulu kartu customer!");
            }
            else if (!Mastercard && balance == 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda kosong , silahkan diisi terlebih dahulu !!!", "INFO");
            }
            else if (!Mastercard && selisih < 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda tidak cukup , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menyimpan data Transaksi Pembelian Tiket dengan ID  " + lblTransactionID.Text + " ? " + 
                    " Dengan Jumlah tiket Sebanyak = " + finalqty.ToString() + " , Untuk Customer dengan CardID = " + CardID + " dan total biaya transaksi = " + finaltotalamount.ToString()  , "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    scan();
                    // set Transaksi 
                    controllerTrans.AutogenereateTransactionID("TICKET", controllerTrans.objTransaction.ShopId);

                    controllerTrans.objTransaction = new ClsTransaction(lblTransactionID.Text, DateTime.Now, finaltotalamount, cbxPaymentType.Text, txtCardID.Text, lblShopID.Text, txtRemarks.Text, finaltotalamount, PPN, balance, balance - totalamount, "BOUGHT", cbxTransType.Text);

                    controllerTrans.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();
                    // set Detail Transaksi 
                    foreach(DataGridViewRow row in dgvTransacTiketDet.Rows)
                    {
                        if(!row.IsNewRow)
                        {
                            controllerTrans.objTransactionTiketDetail = new ClsTransactionTiketDetail(lblTransactionID.Text, DateTime.Now, row.Cells["ItemID"].Value.ToString(), row.Cells["ItemName"].Value.ToString(), Convert.ToDecimal(row.Cells["Price"].Value), Convert.ToInt32(row.Cells["Qty"].Value), "BOUGHT", DateTime.Now, DateTime.Now, Convert.ToInt32(row.Cells["WaktuBermain"].Value), Convert.ToInt32(row.Cells["Toleransi"].Value));
                            controllerTrans.objTransaction.listtranstikdet.Add(controllerTrans.objTransactionTiketDetail);
                        }
                    }
                    try
                    {
                        ClsFungsi.Pesan(controllerTrans.InsertTransactionTicket(controllerTrans.objTransaction, controllerTrans.objCard), "INFO");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Terjadi Error Pada Penambahan Data Tiket !!! error message = " + ex.Message);
                    }
                    this.Close();

                }
                else if (dialogResult == DialogResult.No) { }
                
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // generate transaction detail 
            generatetransacttiketdetail();
        }

        private void dgvTransacTiketDet_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculatetotalamount();
        }

        private void cbxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCbxCategory(controllerShop.ShopID, cbxTransType.Text);
            dgvTransacTiketDet.Rows.Clear();
            txtCardID.Focus();
        }

        private void cbxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbxTransType.Text == "TICKET")
            //{
            //    txtCardID.Enabled = true;
            //    txtCardID.Text = "";
            //    lblCardID.Text = "CardID  : -";
            //    lblCustomerName.Text = "Name : -";
            //    lblIdentity.Text = "No (KTP/SIM) : - ";
            //    lblBalance.Text = "Balance (Saldo)  : Rp. -";
            //    txtCardID.Focus();
            //}
            //else if(cbxTransType.Text == "ONE-TIME-TICKET")
            //{
            //    txtCardID.Enabled = false;
            //    txtCardID.Text = "";
            //    lblCardID.Text = "CardID  : -";
            //    lblCustomerName.Text = "Name : -";
            //    lblIdentity.Text = "No (KTP/SIM) : - ";
            //    lblBalance.Text = "Balance (Saldo)  : Rp. -";
            //}
            //txtCardID.Focus();

        }

        private void cbxRemarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxRemarks.SelectedIndex > 0)
            {
                txtRemarks.Text = cbxRemarks.Text + " : ";
            }
            else if(cbxRemarks.SelectedIndex < 0)
            {
                txtRemarks.Text = "";
            }
        }
    }
}
