using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
using MilenialPark.Views.Shop;

namespace MilenialPark.Views.Card
{
    public partial class FrmCards : Form
    {
        #region properties

        public Mainform parentfrm;
        public ControllerTransaction controllerTran = new ControllerTransaction();
        public ControllerCard controllerCard = new ControllerCard();
        public ControllerShop controllerShop = new ControllerShop();
        bool exist = false;
        bool close = false;
        public BindingSource bind = new BindingSource();
        public decimal finalbalance = 0;
        public ControllerReport controllerReport = new ControllerReport();

        public ReportDocument reportDoc = new ReportDocument();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        PrintDialog printdialog1 = new PrintDialog();
        PrintDocument printdocument = new PrintDocument();
        int CardID = 0;

        #endregion

        public FrmCards()
        {
            InitializeComponent();
        }

        public FrmCards(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
        }

        public void HistorySearch(object sender, EventArgs e)
        {
            if (parentfrm.cbxCategory.Text == "TransactionID")
            {
                foreach (Control x in FLCardTransList.Controls)
                {
                    UCCardTransList cardhist = (UCCardTransList)x;
                    if (cardhist.objtrans.TransactionID.ToUpper().Contains(parentfrm.txtSearch.Text.ToUpper()))
                    {
                        cardhist.Visible = true;
                    }
                    else
                    {
                        cardhist.Visible = false;
                    }
                }
            }
        }

        public void hasShop()
        {
            if (controllerShop.checkCashier(ClsStaticVariable.controllerUser.objUser.UserID))
            {
                controllerShop.getShopandShopItemTopUp(ClsStaticVariable.controllerUser.objUser.UserID);
                parentfrm.lblShopID.Visible = true;
                parentfrm.lblShopName.Visible = true;
                parentfrm.lblMainProduct.Visible = true;
                parentfrm.lblAddress.Visible = true;

                parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                parentfrm.lblAddress.Text = controllerShop.objShop.Address;
            }
            else
            {
                ClsFungsi.Pesan("Maaf, akun anda belum memiliki data Toko / Shop !!! silahkan dibuat terlebih dahulu ", "ERROR");
                close = true;
            }
        }

        public void hasShop2(string UserID)
        {
            if (controllerShop.checkCashier2(UserID))
            {
                controllerShop.getShopandShopItemTopUp(ClsStaticVariable.controllerUser.objUser.UserID);
                parentfrm.lblShopID.Visible = true;
                parentfrm.lblShopName.Visible = true;
                parentfrm.lblMainProduct.Visible = true;
                parentfrm.lblAddress.Visible = true;

                parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                parentfrm.lblAddress.Text = controllerShop.objShop.Address;
            }
            else
            {
                ClsFungsi.Pesan("Maaf, akun anda belum memiliki data Toko / Shop !!! silahkan dibuat terlebih dahulu ", "ERROR");
                close = true;
            }
        }

        public void setcbxJenisTopUp()
        {
            cbxJenisTopUp.Items.Clear();
            dt = controllerShop.getShopItem(controllerShop.objShop.ShopID);
            cbxJenisTopUp.DisplayMember = "Text";
            cbxJenisTopUp.ValueMember = "Value";
            int selected = 0;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    cbxJenisTopUp.Items.Add(new { Text = dt.Rows[i]["ItemName"].ToString(), Value = dt.Rows[i]["ItemID"].ToString() });
                }
            }
            cbxJenisTopUp.SelectedIndex = selected;
        }

        private void FrmCards_Load(object sender, EventArgs e)
        {
            hasShop();
            setcbxJenisTopUp();
            txtCardID.Focus();

            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Supervisor" || ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin" || ClsStaticVariable.controllerUser.objUser.TipeUser == "SuperAdmin")
            {
                //btnRefund.Visible = true; 
            }
            else
            {
                btnRefund.Visible = false;
            }

            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Staf")
            {
                btnTopUp.Visible = false;
                btnRefund.Visible = false;
                TopUpPanel.Visible = false;
            }

            parentfrm.btnFind.Click += this.HistorySearch;
            parentfrm.txtSearch.TextChanged += this.HistorySearch;
            parentfrm.cbxCategory.Items.Add("TransactionID");
            parentfrm.cbxCategory.SelectedIndex = 0;
            cmbPaymentType.SelectedIndex = 0;
        }

        public void scan()
        {
            txtCardID.Text = CardID.ToString();
            controllerTran.dt = controllerTran.getCard(CardID.ToString());
            controllerTran.SetCard(txtCardID.Text);

            if (controllerTran.dt.Rows.Count == 0)
            {
                exist = false;
                ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
            }
            else
            {
                exist = true;
                controllerTran.objCard = new ClsCard(controllerTran.dt.Rows[0]["CardID"].ToString(), controllerTran.dt.Rows[0]["CustomerName"].ToString(), controllerTran.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTran.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTran.dt.Rows[0]["Active"]));
                lblCardID.Text = "Card ID : " + controllerTran.objCard.CardID;
                lblCardID2.Text = "Card ID : " + controllerTran.objCard.CardID;
                lblCustomerName.Text = "Name : " + controllerTran.objCard.CustomerName;
                lblIdentity.Text = "No (KTP/SIM) : " + controllerTran.objCard.Noidentitas;
                lblBalance.Text = "Balance (Saldo) : Rp. " + controllerTran.objCard.Saldo.ToString("#,##0");
                lblBalance2.Text = "Balance (Saldo) : Rp. " + controllerTran.objCard.Saldo.ToString("#,##0");

                btnFilter_Click(null, null);
                lblFinal.Text = "0";
            }
        }

        public void scan2()
        {
            txtCardID.Text = CardID.ToString();
            controllerTran.dt = controllerTran.getCard(CardID.ToString());
            controllerTran.SetCard(txtCardID.Text);

            if (controllerTran.dt.Rows.Count == 0)
            {
                exist = false;
                ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
            }
            else
            {
                exist = true;
                controllerTran.objCard = new ClsCard(controllerTran.dt.Rows[0]["CardID"].ToString(), controllerTran.dt.Rows[0]["CustomerName"].ToString(), controllerTran.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTran.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTran.dt.Rows[0]["Active"]));
                lblCardID.Text = "Card ID : " + controllerTran.objCard.CardID;
                lblCardID2.Text = "Card ID : " + controllerTran.objCard.CardID;
                lblCustomerName.Text = "Name : " + controllerTran.objCard.CustomerName;
                lblIdentity.Text = "No (KTP/SIM) : " + controllerTran.objCard.Noidentitas;
                lblBalance.Text = "Balance (Saldo) : Rp. " + controllerTran.objCard.Saldo.ToString("#,##0");
                lblBalance2.Text = "Balance (Saldo) : Rp. " + controllerTran.objCard.Saldo.ToString("#,##0");

                lblFinal.Text = "0";
            }
            calculatefinalbalance();
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (!close)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CardID = Convert.ToInt32(txtCardID.Text);
                    scan();
                    calculatefinalbalance();
                    txtCardID.Focus(); 
                }
            }
        }

        public void LoadCardList(object sender, EventArgs e, string CardID, DateTime from, DateTime to)
        {
            FLCardTransList.Controls.Clear();
            controllerCard.dt = controllerCard.getCardTransactHistory(controllerTran.objCard.CardID, new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
            if (controllerCard.dt.Rows.Count != 0)
            {
                UCCardTransList[] listucCardTranslist = new UCCardTransList[controllerCard.dt.Rows.Count];
                int index = 0;
                foreach (DataRow row in controllerCard.dt.Rows)
                {
                    controllerTran.objTransaction = new ClsTransaction(row["TransactionID"].ToString(), Convert.ToDateTime(row["TransactionDate"]), Convert.ToDecimal(row["TotalAmount"]), row["PaymentType"].ToString(), row["CardID"].ToString(), row["ShopID"].ToString(), row["Remarks"].ToString(), Convert.ToDecimal(row["Subtotal"]), Convert.ToDecimal(row["PPN"]), Convert.ToDecimal(row["InitialBalance"]), Convert.ToDecimal(row["FinalBalance"]));
                    UCCardTransList ucCardTranList = new UCCardTransList(controllerTran.objTransaction);
                    ucCardTranList.Name = "CH" + index.ToString();

                    ucCardTranList.btnDetails.Click += (se, ev) => this.DetailsClick(sender, e, ucCardTranList.objtrans);
                    ucCardTranList.btnReceipt.Click += (se, ev) => this.ReceiptClick(sender, e, ucCardTranList.objtrans);
                    ucCardTranList.btnPrint.Click += (se, ev) => this.PrintClick(sender, e, ucCardTranList.objtrans);
                    listucCardTranslist[index] = ucCardTranList;
                    index++;
                }

                FLCardTransList.Controls.AddRange(listucCardTranslist);
            }
        }

        public void DetailsClick(object sender, EventArgs e, ClsTransaction trans)
        {
            string type = trans.TransactionID.Substring(0, 3);
            if (type == "TRK")
            {
                lblInitialBalance.ForeColor = Color.FromArgb(33, 119, 86);
                lblfinalbalance.ForeColor = Color.FromArgb(33, 119, 86);
                imgincrease.Visible = true;
                imgdecrease.Visible = false;
                bind.DataSource = controllerTran.gettransactionDetail(trans.TransactionID);
            }
            else if (type == "TRD")
            {
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
                bind.DataSource = controllerTran.gettransactionDetail(trans.TransactionID);
            }
            else if (type == "TRT")
            {
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
                bind.DataSource = controllerTran.gettransactionTiketDetail(trans.TransactionID);
            }
            else if (type == "EX-")
            {
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
                bind.DataSource = controllerTran.gettransactionTiketDetail(trans.TransactionID);
            }
            else if (type == "TRR")
            {
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
                bind.DataSource = controllerTran.gettransactionDetail(trans.TransactionID);
            }
            
            dgvTransacDetail.DataSource = bind;
            lblTransactionID.Text = "ID : " + trans.TransactionID;
            lblTransactionDate.Text = "DATE : " + trans.TransactionDate.ToString("dd/M/yyyy HH:mm:ss tt");
            lblPaymentType.Text = "Payment Type : " + trans.PaymentType;
            dgvTransacDetail.Text = "Customer : " + controllerCard.objCard.getCustomerName(trans.CardID);
            lblTranCardID.Text = "Card ID : " + trans.CardID;
            lblShopID.Text = "Shop ID : " + trans.ShopId;
            lblSubTotal.Text = "Subtotal : " + trans.Subtotal.ToString("#,##0");
            lblPPN.Text = "PPN : " + trans.PPN.ToString("#,##0");
            lblTotalAmount.Text = "Total : Rp. " + trans.totalAmount.ToString("#,##0");
            lblRemarks.Text = "Remarks : " + trans.Remarks;
            lblInitialBalance.Text = trans.InitialBalance.ToString("#,##0");
            lblfinalbalance.Text = trans.finalBalance.ToString("#,##0");
            


            dgvTransacDetail.Columns["Price"].DefaultCellStyle.Format = "#,##0";
        }

        public void ReceiptClick(object sender, EventArgs e, ClsTransaction trans)
        {
            ds = controllerReport.LoadTransactionReceipt2(trans.TransactionID);
            if (trans.TransactionID.Substring(0, 3) == "TRD")
            {
                reportDoc = new MilenialPark.Reports.PrintTransactionReceipt();
            }
            else
            {
                reportDoc = new MilenialPark.Reports.PrintTopUpReceipt();
            }
            reportDoc.SetDataSource(ds);

            FrmShowReport frmShowReport = new FrmShowReport(reportDoc);
            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmShowReport.ShowDialog();
            frmBlank.Close();
        }

        public void PrintClick(object sender, EventArgs e, ClsTransaction trans)
        {
            ClsTransaction objtrans = trans;

            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            ds = controllerReport.LoadTransactionReceipt2(objtrans.TransactionID);
            if (objtrans.TransactionID.Substring(0, 3) == "TRD")
            {
                reportDoc = new MilenialPark.Reports.PrintTransactionReceipt();
            }
            else
            {
                reportDoc = new MilenialPark.Reports.PrintTopUpReceipt();
            }
            reportDoc.SetDataSource(ds);

            this.printdialog1.Document = printdocument;
            DialogResult dr = this.printdialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printdocument.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printdocument.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printdocument.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = this.printdocument.PrinterSettings.PrinterName;

                try
                {
                    //Set the printer name to print the report to. By default the sample
                    //report does not have a default printer specified. This will tell the
                    //engine to use the specified printer to print the report. Print out 
                    //a test page (from Printer properties) to get the correct value.

                    reportDoc.PrintOptions.PrinterName = PrinterName;

                    //Start the printing process. Provide details of the print job
                    //using the arguments.
                    reportDoc.PrintToPrinter(nCopy, false, sPage, ePage);

                    //Let the user know that the print job is completed
                    MessageBox.Show("Report finished printing!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (exist)
            {
                LoadCardList(sender, e, controllerTran.objCard.CardID, dtpFrom.Value, dtpTo.Value);
            }
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            if (!close)
            {
                if (txtCardID.Text.Length == 0)
                {
                    ClsFungsi.Pesan("Silahkan Scan Card / Kartu Terlebih Dahulu !!!");
                }
                else if (!controllerCard.CheckCard2(CardID.ToString()))
                {
                    ClsFungsi.Pesan("Card / Kartu yang di scan tidak terdaftar pada sistem atau sudah di blokir !!!");
                }
                else if (controllerCard.CheckCard2(CardID.ToString()))
                {
                    scan2();
                    //get shop and shopItem top Up 
                    controllerShop.getShopandShopItemTopUp2(ClsStaticVariable.controllerUser.objUser.UserID, Convert.ToString((cbxJenisTopUp.SelectedItem as dynamic).Value));

                    // set transaction Details
                    ClsTransactionDetail objtransdet = new ClsTransactionDetail("TOPUPTMP", DateTime.Now, controllerShop.objShop.listShopitem[0].ItemID, controllerShop.objShop.listShopitem[0].ItemName, controllerShop.objShop.listShopitem[0].Price, 1, "COMPLETE");

                    // set Transaction
                    controllerTran.AutogenereateTransactionID("KREDIT", parentfrm.lblShopID.Text);
                    controllerTran.objTransaction = new ClsTransaction(controllerTran.TransactionID, DateTime.Now, NUDTotalAmount.Value, cmbPaymentType.Text, controllerTran.objCard.CardID, parentfrm.lblShopID.Text, ("TOP UP " + NUDTotalAmount.Value.ToString("#,##0") + " to " + controllerTran.objCard.CardID + " By " + cmbPaymentType.Text), Convert.ToDecimal(lblPaymentValue.Text), 0, controllerTran.objCard.Saldo, finalbalance, "COMPLETE", "TOP-UP");

                    controllerTran.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                    objtransdet.TransactionID = controllerTran.objTransaction.TransactionID;
                    objtransdet.Price = Convert.ToDecimal(lblPaymentValue.Text);
                    controllerTran.objTransaction.listtransdet.Add(objtransdet);

                    //Insert 
                    //Insert Transaksi
                    ClsFungsi.Pesan(controllerTran.InsertTopUp(controllerTran.objTransaction, controllerTran.objCard), "INFO");
                    cbxJenisTopUp.SelectedIndex = 0;
                    txtCardID.Focus();
                    scan();

                }
            }
        }

        private void NUDQty_ValueChanged(object sender, EventArgs e)
        {
            finalbalance = NUDTotalAmount.Value + controllerTran.objCard.Saldo;
            lblFinal.Text = finalbalance.ToString("#,##0");
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (!close)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin" || ClsStaticVariable.controllerUser.objUser.TipeUser == "SuperAdmin")
                {
                    if (txtCardID.Text.Length == 0)
                    {
                        ClsFungsi.Pesan("Silahkan Scan Card / Kartu Terlebih Dahulu !!!");
                    }
                    else if (!controllerCard.CheckCard2(txtCardID.Text))
                    {
                        ClsFungsi.Pesan("Card / Kartu yang di scan tidak terdaftar pada sistem atau sudah di blokir!!!");
                    }
                    // check if Sisa Saldo != 0 , NUD value <= Saldo
                    else if (controllerTran.objCard.Saldo == 0)
                    {
                        ClsFungsi.Pesan("Saldo Kartu Kosong tidak bisa di refund !!!");
                    }
                    else if (controllerCard.CheckCard2(txtCardID.Text))
                    {


                        //get shop and shopItem top Up 
                        controllerShop.getShopandShopItemRefund(ClsStaticVariable.controllerUser.objUser.UserID);

                        if (controllerShop.checkcanrefund(controllerShop.objShop.ShopID))
                        {
                            // set transaction Details
                            ClsTransactionDetail objtransdet = new ClsTransactionDetail("REFUNDTMP", DateTime.Now, controllerShop.objShop.listShopitem[0].ItemID, controllerShop.objShop.listShopitem[0].ItemName, controllerShop.objShop.listShopitem[0].Price, 1, "COMPLETE");

                            // set Transaction
                            controllerTran.AutogenereateTransactionID("REFUND", parentfrm.lblShopID.Text);
                            controllerTran.objTransaction = new ClsTransaction(controllerTran.TransactionID, DateTime.Now, NUDTotalAmount.Value, "REFUND", controllerTran.objCard.CardID, parentfrm.lblShopID.Text, ("REFUND " + NUDTotalAmount.Value.ToString("#,##0") + " From " + controllerTran.objCard.CardID), 0, 0, controllerTran.objCard.Saldo, finalbalance, "COMPLETE", "REFUND");

                            controllerTran.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                            objtransdet.TransactionID = controllerTran.objTransaction.TransactionID;
                            controllerTran.objTransaction.listtransdet.Add(objtransdet);

                            //Insert 
                            //Insert Transaksi
                            ClsFungsi.Pesan(controllerTran.InsertRefund(controllerTran.objTransaction, controllerTran.objCard), "INFO");
                            NUDTotalAmount.Value = 0;
                            txtCardID.Focus();
                            scan();
                        }
                        else
                        {
                            ClsFungsi.Pesan("Maaf Supervisor ini tidak melayani layanan Refund!!! Silahkan hubungi admin atau coba di Supervisor yang lain");
                        }

                    }
                }
                else
                {
                    ClsFungsi.Pesan("Maaf Anda tidak memiliki hak akses untuk melakukan fungsi ini !!! hubungi developer");
                }
            }
        }

        private void FrmCards_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentfrm.btnFind.Click -= this.HistorySearch;
            parentfrm.txtSearch.TextChanged -= this.HistorySearch;
            parentfrm.cbxCategory.Enabled = true;
            parentfrm.cbxCategory.Items.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //FrmCardList frmSearch = new FrmCardList();
            //FormBlank frmBlank = new FormBlank();
            //frmBlank.Show();
            //frmSearch.ShowDialog();
            //frmBlank.Close();
            //if (ClsStaticVariable.CardID != "")
            //{
            //    txtCardID.Text = ClsStaticVariable.CardID;
            //    txtCardID.Focus();
            //    SendKeys.SendWait("{ENTER}");
            //}

            FrmChooseShop frmChooseShop = new FrmChooseShop();
            frmChooseShop.ShowDialog();

            if (ClsStaticVariable.ShopID.Trim().Length > 0)
            {
                controllerShop.getcashier2(ClsStaticVariable.ShopID);
                if (controllerShop.objShop.ShopName.Trim().Length > 0)
                {
                    parentfrm.lblShopID.Visible = true;
                    parentfrm.lblShopName.Visible = true;
                    parentfrm.lblMainProduct.Visible = true;
                    parentfrm.lblAddress.Visible = true;

                    parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                    parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                    parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                    parentfrm.lblAddress.Text = controllerShop.objShop.Address;
                    
                    //btnImport.Enabled = true;
                }
            }
            hasShop2(controllerShop.objShop.ShopID);
            setcbxJenisTopUp(); 

        }

        public void calculatefinalbalance()
        {
            finalbalance = NUDTotalAmount.Value + controllerTran.objCard.Saldo;
            lblFinal.Text = finalbalance.ToString("#,##0");
        }

        private void NUDQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                finalbalance = NUDTotalAmount.Value + controllerTran.objCard.Saldo;
                lblFinal.Text = finalbalance.ToString("#,##0");
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            Admin.FrmCardManagement frmCardManagement = new Admin.FrmCardManagement(this.parentfrm);
            frmCardManagement.Text = "Card Management";
            this.parentfrm.OpenChildForm(frmCardManagement);
        }

        private void btnBlokir_Click(object sender, EventArgs e)
        {
            if (!close)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Supervisor" || ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin" || ClsStaticVariable.controllerUser.objUser.TipeUser == "SuperAdmin")
                {
                    if (txtCardID.Text.Length == 0)
                    {
                        ClsFungsi.Pesan("Silahkan Scan Card / Kartu Terlebih Dahulu !!!");
                    }
                    else if (!controllerCard.CheckCard2(txtCardID.Text))
                    {
                        ClsFungsi.Pesan("Card / Kartu yang di scan tidak terdaftar pada sistem atau sudah di blokir!!!");
                    }
                    // check if Sisa Saldo != 0 , NUD value <= Saldo
                    else if (controllerTran.objCard.Saldo == 0)
                    {
                        ClsFungsi.Pesan("Saldo Kartu Kosong tidak bisa di refund !!!");
                    }
                    else if (controllerCard.CheckCard2(txtCardID.Text))
                    {


                        //get shop and shopItem top Up 
                        controllerShop.getShopandShopItemRefund(ClsStaticVariable.controllerUser.objUser.UserID);

                        if (controllerShop.checkcanrefund(controllerShop.objShop.ShopID))
                        {
                            // set transaction Details
                            ClsTransactionDetail objtransdet = new ClsTransactionDetail("REFUNDTMP", DateTime.Now, controllerShop.objShop.listShopitem[0].ItemID, controllerShop.objShop.listShopitem[0].ItemName, controllerShop.objShop.listShopitem[0].Price, 1, "COMPLETE");

                            // set Transaction
                            controllerTran.AutogenereateTransactionID("REFUND", parentfrm.lblShopID.Text);
                            controllerTran.objTransaction = new ClsTransaction(controllerTran.TransactionID, DateTime.Now, controllerTran.objCard.Saldo, "REFUND", controllerTran.objCard.CardID, parentfrm.lblShopID.Text, ("BLOCK CARD, REFUND " + controllerTran.objCard.Saldo.ToString("#,##0") + " From " + controllerTran.objCard.CardID), 0, 0, controllerTran.objCard.Saldo, finalbalance, "COMPLETE");

                            controllerTran.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                            objtransdet.TransactionID = controllerTran.objTransaction.TransactionID;
                            controllerTran.objTransaction.listtransdet.Add(objtransdet);

                            //Insert 
                            //Insert Transaksi
                            ClsFungsi.Pesan(controllerTran.InsertRefundandBlockCard(controllerTran.objTransaction, controllerTran.objCard), "INFO");
                            NUDTotalAmount.Value = 0;
                            txtCardID.Focus();
                            scan();
                        }
                        else
                        {
                            ClsFungsi.Pesan("Maaf Supervisor ini tidak melayani layanan Refund!!! Silahkan hubungi admin atau coba di Supervisor yang lain");
                        }

                    }
                }
                else
                {
                    ClsFungsi.Pesan("Maaf Anda tidak memiliki hak akses untuk melakukan fungsi ini !!! hubungi developer");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxJenisTopUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = controllerShop.getOneShopItem(controllerShop.objShop.ShopID, Convert.ToString((cbxJenisTopUp.SelectedItem as dynamic).Value));
            NUDTotalAmount.Value = Convert.ToDecimal(dt.Rows[0]["TopUpAmount"]);
            lblPaymentValue.Text = Convert.ToDecimal(dt.Rows[0]["Price"]).ToString("#,##0");
            calculatefinalbalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!close)
            {
                if (txtCardID.Text.Length == 0)
                {
                    ClsFungsi.Pesan("Silahkan Scan Card / Kartu Terlebih Dahulu !!!");
                }
                else if (!controllerCard.CheckCard2(CardID.ToString()))
                {
                    ClsFungsi.Pesan("Card / Kartu yang di scan tidak terdaftar pada sistem atau sudah di blokir !!!");
                }
                else if(ClsStaticVariable.controllerUser.objUser.TipeUser != "Admin")
                {
                    ClsFungsi.Pesan("Maaf Anda Bukan Admin !!!");
                }
                else if (controllerCard.CheckCard2(CardID.ToString()))
                {
                    scan2();

                    //get shop and shopItem top Up 
                    controllerShop.getShopandShopItemTopUp2(ClsStaticVariable.controllerUser.objUser.UserID, Convert.ToString((cbxJenisTopUp.SelectedItem as dynamic).Value));

                    // set transaction Details
                    ClsTransactionDetail objtransdet = new ClsTransactionDetail("TOPUPTMP", DateTime.Now, controllerShop.objShop.listShopitem[0].ItemID, controllerShop.objShop.listShopitem[0].ItemName, controllerShop.objShop.listShopitem[0].Price, 1, "COMPLETE");

                    // set Transaction
                    controllerTran.AutogenereateTransactionID("DEBIT", parentfrm.lblShopID.Text);
                    controllerTran.objTransaction = new ClsTransaction(controllerTran.TransactionID, DateTime.Now, NUDTotalAmount.Value, cmbPaymentType.Text, controllerTran.objCard.CardID, parentfrm.lblShopID.Text, ("REFUND " + NUDTotalAmount.Value.ToString("#,##0") + " to " + controllerTran.objCard.CardID + " By " + cmbPaymentType.Text), Convert.ToDecimal(lblPaymentValue.Text), 0, controllerTran.objCard.Saldo, finalbalance, "COMPLETE", "TOP-UP");

                    controllerTran.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                    objtransdet.TransactionID = controllerTran.objTransaction.TransactionID;
                    objtransdet.Price = Convert.ToDecimal(lblPaymentValue.Text);
                    controllerTran.objTransaction.listtransdet.Add(objtransdet);

                    //Insert 
                    //Insert Transaksi
                    ClsFungsi.Pesan(controllerTran.InsertTopUpMinus(controllerTran.objTransaction, controllerTran.objCard), "INFO");
                    cbxJenisTopUp.SelectedIndex = 0;
                    txtCardID.Focus();
                    scan();

                }
            }
        }
    }
}
