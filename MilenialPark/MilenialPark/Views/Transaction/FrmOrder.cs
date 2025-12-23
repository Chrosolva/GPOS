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
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Models;
using MilenialPark.UserControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmOrder : Form
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
        public bool exist = false;
        PrintDialog printdialog1 = new PrintDialog();
        PrintDocument printdocument = new PrintDocument();
        public string excludecategory;

        #endregion

        public FrmOrder()
        {
            InitializeComponent();
        }

        public FrmOrder(Mainform parent, ClsShop shop)
        {
            parentfrm = parent;
            InitializeComponent();
            objShop = shop;
            imgList.Images.Add(Resource.food_app);
            imgList.Images.Add(Resource.mobile_payment);
            imgList.Images.Add(Resource.history);

            ordertabs.ImageList = imgList;
            ordertabs.TabPages[0].ImageIndex = 0;
            ordertabs.TabPages[1].ImageIndex = 2;
            //ordertabs.TabPages[2].ImageIndex = 2;

            excludecategory = "";
            if (DateTime.Now.DayOfWeek.ToString().Equals("Saturday") || DateTime.Now.DayOfWeek.ToString().Equals("Sunday"))
            {
                cbxTransType.SelectedIndex = 1;
                excludecategory = "WEEKDAY";
            }
            else
            {
                cbxTransType.SelectedIndex = 0;
                excludecategory = "WEEKEND";
            }
            controllerShop.getShopandShopItem2Union(objShop.ShopID, excludecategory);
            hasShop();
            //dtpFrom.Value = DateTime.Now.AddDays(-1);
            //dtpTo.Value = DateTime.Now;
            //dtpFrom2.Value = DateTime.Now.AddDays(-1);
            //dtpTo2.Value = DateTime.Now;
        }

        public void UserControlClick(object sender, EventArgs e, UCShopItem ucshopitem)
        {
            UCShopItem tmp = ucshopitem;
            ClsShopItem data = tmp.objShopItem;


            //FrmAddOrder frmAddOrder = new FrmAddOrder(data);
            //FormBlank frmBlank = new FormBlank();
            //frmBlank.Show();
            //frmAddOrder.ShowDialog();
            //frmBlank.Close();
            //MessageBox.Show("haha");

            // create 
            ClsTransactionDetail objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, data.ItemID, data.ItemName, data.Price, Convert.ToInt32(1), "NOTSERVED");
            ClsStaticVariable.objtransdet = objtransdet;

            ClsTransactionTiketDetail objtranstikdet = new ClsTransactionTiketDetail("ORDTMP", DateTime.Now, data.ItemID, data.ItemName, data.Price, Convert.ToInt32(1), "NOTSERVED", DateTime.Now, DateTime.Now, data.WaktuBermain, data.Toleransi);
            ClsStaticVariable.objtranstikdet = objtranstikdet;


            ClsStaticVariable.placeorder = true;
            ClsStaticVariable.WaktuBermain = data.WaktuBermain;
            ClsStaticVariable.Toleransi = data.Toleransi;

            // need to change
            //if (ClsStaticVariable.placeorder)
            //{

            //}

            bool add = true;
            if (FLNewOrder.Controls.Count != 0)
            {
                foreach (Control x in FLNewOrder.Controls)
                {
                    var uc = (UCOrderItem)x;
                    if (uc.objTransdet.ItemId == ClsStaticVariable.objtransdet.ItemId)
                    {
                        add = false;
                        uc.NUDQty.Value = uc.NUDQty.Value + ClsStaticVariable.objtransdet.Qty;
                        break;
                    }
                    else
                    {
                        add = true;
                    }
                }
            }

            if (add)
            {
                UCOrderItem ucorderItem = new UCOrderItem(ClsStaticVariable.objtransdet, ClsStaticVariable.objtranstikdet);
                //ucorderItem.index = FLNewOrder.Controls.Count;
                //ucorderItem.Name = "UC" + ucorderItem.index.ToString();
                ucorderItem.Name = "UC" + ucorderItem.objTransdet.ItemId.ToString();
                ucorderItem.btnDelete.Click += (se, ev) => this.OrderDeleteClick(sender, e, ucorderItem.Name);
                ucorderItem.NUDQty.ValueChanged += (se, ev) => this.NUDValueChanged(sender, e, ucorderItem.Name);
                ucorderItem.WaktuBermain = ClsStaticVariable.WaktuBermain;
                ucorderItem.Toleransi = ClsStaticVariable.Toleransi;
                FLNewOrder.Controls.Add(ucorderItem);
                ClsStaticVariable.placeorder = false;
                CalculateSubtotal();
            }


        }

        public void NUDValueChanged(object sender, EventArgs e, string key)
        {
            UCOrderItem tmp = (UCOrderItem)FLNewOrder.Controls[key];
            tmp.lblQty.Text = tmp.NUDQty.Value.ToString();
            tmp.objTransdet.Qty = Convert.ToInt32(tmp.NUDQty.Value);
            CalculateSubtotal();
        }

        public void OrderDeleteClick(object sender, EventArgs e, string key)
        {
            FLNewOrder.Controls.RemoveByKey(key);
            CalculateSubtotal();
        }

        public void FillFLPanel(object sender, EventArgs e)
        {
            controllerShop.getShopandShopItem2Union(objShop.ShopID, excludecategory);
            FLMenu.Controls.Clear();
            listShopItem.Clear();
            if (controllerShop.objShop.listShopitem.Count != 0)
            {
                foreach (ClsShopItem shopItem in controllerShop.objShop.listShopitem)
                {
                    UCShopItem ucShopItem = new UCShopItem(shopItem);
                    ucShopItem.outerpanel.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.contentpanel.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.pbPanel.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.pbShopItem.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.lblItemName.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.lblRP.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);
                    ucShopItem.lblItemPrice.Click += (se, ev) => this.UserControlClick(sender, e, ucShopItem);

                    listShopItem.Add(ucShopItem);
                }
            }
            if (listShopItem.Count != 0)
            {
                for (int i = 0; i < listShopItem.Count; i++)
                {
                    FLMenu.Controls.Add(listShopItem[i]);
                }
            }
        }

        public void hasShop()
        {
            // Load the shop by its ID rather than checking user ownership
            controllerShop.getShop2(objShop.ShopID);

            if (!string.IsNullOrEmpty(controllerShop.objShop.ShopName?.Trim()))
            {
                // Show the shop details on the parent form
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
                ClsFungsi.Pesan("Maaf, shop universal tidak ditemukan atau belum dibuat.", "ERROR");
            }
        }



        private void FrmOrder_Load(object sender, EventArgs e)
        {
            //FillFLPanel(sender, e);
            hasShop();
            parentfrm.btnFind.Click += this.OrderSearch;
            parentfrm.txtSearch.TextChanged += this.OrderSearch;
            parentfrm.cbxCategory.Items.Add("Item Name");
            parentfrm.cbxCategory.SelectedIndex = 0;
            parentfrm.cbxCategory.Enabled = false;
        }

        public void OrderSearch(object sender, EventArgs e)
        {
            if (parentfrm.cbxCategory.Text == "Item Name")
            {
                foreach (Control x in FLMenu.Controls)
                {
                    UCShopItem shopitem = (UCShopItem)x;
                    if (shopitem.lblItemName.Text.ToUpper().Contains(parentfrm.txtSearch.Text.ToUpper()))
                    {
                        shopitem.Visible = true;
                    }
                    else
                    {
                        shopitem.Visible = false;
                    }
                }
            }
        }

        public void CalculateSubtotal()
        {
            int subtotal = 0;
            foreach (Control x in FLNewOrder.Controls)
            {
                var tmp = (UCOrderItem)x;
                subtotal += Convert.ToInt32(tmp.NUDQty.Value * Convert.ToDecimal(tmp.objTransdet.Price));
            }
            lblSubtotal.Text = subtotal.ToString("#,##0");

            chkPPN_CheckedChanged(null, null);
            CalculateTotal();

        }

        public void CalculateTotal()
        {
            decimal total = Convert.ToDecimal(lblSubtotal.Text) + Convert.ToDecimal(lblPPN.Text);
            lblTotal.Text = total.ToString("#,##0");
        }

        private void FLNewOrder_ControlAdded(object sender, ControlEventArgs e)
        {
            CalculateSubtotal();
        }

        private void chkPPN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPPN.Checked)
            {
                decimal ppn = Convert.ToDecimal(Math.Floor((float)Convert.ToDecimal(lblSubtotal.Text) * 0.11));
                lblPPN.Text = ppn.ToString("#,##0");
            }
            else
            {
                lblPPN.Text = "0";
            }
            CalculateTotal();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            CalculateTotal();
            if (FLNewOrder.Controls.Count != 0)
            {
                controllerTrans.AutogenereateTransactionID("TICKET", parentfrm.lblShopID.Text);
                controllerTrans.objTransaction = new ClsTransaction(controllerTrans.TransactionID, DateTime.Now, Convert.ToDecimal(lblTotal.Text), "", "", parentfrm.lblShopID.Text, "", Convert.ToDecimal(lblSubtotal.Text), Convert.ToDecimal(lblPPN.Text), 0, 0, "NOTPAID");

                controllerTrans.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                controllerTrans.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();

                foreach (Control x in FLNewOrder.Controls)
                {
                    UCOrderItem tmp = (UCOrderItem)x;
                    tmp.objTransdet.TransactionID = controllerTrans.TransactionID;
                    controllerTrans.objTransaction.listtransdet.Add(tmp.objTransdet);
                    controllerTrans.objTransaction.listtransdet.Add(tmp.objTransdet);
                }

                

                FrmPayment frmPayment = new FrmPayment(controllerTrans);
                FormBlank frmBlank = new FormBlank();
                frmBlank.Show();
                frmPayment.ShowDialog();
                frmBlank.Close();

                if (ClsStaticVariable.sukses)
                {
                    ClsStaticVariable.sukses = false;
                    FLNewOrder.Controls.Clear();
                    lblSubtotal.Text = "0";
                    lblPPN.Text = "0";
                    chkPPN.Checked = false;
                    lblTotal.Text = "0";
                }
            }
            else
            {
                ClsFungsi.Pesan("Daftar Pesanan Kosong, Mohon diisi terlebih dahulu !!!", "ERROR");
            }

        }

        private void FrmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentfrm.btnFind.Click -= this.OrderSearch;
            parentfrm.txtSearch.TextChanged -= this.OrderSearch;
            parentfrm.cbxCategory.Enabled = true;
            parentfrm.cbxCategory.Items.Clear();
        }

        

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            CalculateTotal();
            if (FLNewOrder.Controls.Count != 0)
            {
                controllerTrans.AutogenereateTransactionID("TICKET", parentfrm.lblShopID.Text);
                controllerTrans.objTransaction = new ClsTransaction(controllerTrans.TransactionID, DateTime.Now, Convert.ToDecimal(lblTotal.Text), "", "", parentfrm.lblShopID.Text, "", Convert.ToDecimal(lblSubtotal.Text), Convert.ToDecimal(lblPPN.Text), 0, 0, "NOTPAID", cbxTransType.Text);

                controllerTrans.objTransaction.listtransdet = new List<ClsTransactionDetail>();
                controllerTrans.objTransaction.listtranstikdet = new List<ClsTransactionTiketDetail>();

                foreach (Control x in FLNewOrder.Controls)
                {
                    UCOrderItem tmp = (UCOrderItem)x;
                    tmp.objTransdet.TransactionID = controllerTrans.TransactionID;
                    controllerTrans.objTransaction.listtransdet.Add(tmp.objTransdet);
                    controllerTrans.objTransactionTiketDetail = new ClsTransactionTiketDetail(controllerTrans.TransactionID, DateTime.Now, tmp.objTransdet.ItemId, tmp.objTransdet.ItemName, tmp.objTransdet.Price, tmp.objTransdet.Qty, "BOUGHT", DateTime.Now, DateTime.Now, tmp.WaktuBermain , tmp.Toleransi);
                    controllerTrans.objTransaction.listtranstikdet.Add(controllerTrans.objTransactionTiketDetail);
                }

                FrmPayment frmPayment = new FrmPayment(controllerTrans);
                //FormBlank frmBlank = new FormBlank();
                //frmBlank.Show();
                frmPayment.ShowDialog();
                //frmBlank.Close();

                // Auto Print Ticket 


                if (ClsStaticVariable.sukses)
                {
                    ClsStaticVariable.sukses = false;
                    FLNewOrder.Controls.Clear();
                    lblSubtotal.Text = "0";
                    lblPPN.Text = "0";
                    chkPPN.Checked = false;
                    lblTotal.Text = "0";
                }
            }
            else
            {
                ClsFungsi.Pesan("Daftar Pesanan Kosong, Mohon diisi terlebih dahulu !!!", "ERROR");
            }
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controllerTrans.dt = controllerTrans.getCard(txtCardID.Text);
                controllerTrans.SetCard(txtCardID.Text);

                if (controllerTrans.dt.Rows.Count == 0)
                {
                    exist = false;
                    ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
                }
                else
                {
                    exist = true;
                    controllerTrans.objCard = new ClsCard(controllerTrans.dt.Rows[0]["CardID"].ToString(), controllerTrans.dt.Rows[0]["CustomerName"].ToString(), controllerTrans.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTrans.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTrans.dt.Rows[0]["Active"]));
                    lblCardID.Text = "Card ID : " + controllerTrans.objCard.CardID;
                    lblCustomerName.Text = "Name : " + controllerTrans.objCard.CustomerName;
                    lblIdentity.Text = "No (KTP/SIM) : " + controllerTrans.objCard.Noidentitas;
                    lblBalance.Text = "Balance (Saldo) : Rp. " + controllerTrans.objCard.Saldo.ToString("#,##0");

                    btnFilter2_Click(sender, e);
                }
            }
        }

        private void btnFilter2_Click(object sender, EventArgs e)
        {
            if (exist)
            {
                LoadCardList(sender, e, controllerTrans.objCard.CardID, dtpFrom.Value, dtpTo.Value);
            }
        }

        public void LoadCardList(object sender, EventArgs e, string CardID, DateTime from, DateTime to)
        {
            FLCardTransList.Controls.Clear();
            controllerCard.dt = controllerCard.getCardTransactHistoryWithShopID(parentfrm.lblShopID.Text, controllerTrans.objCard.CardID, new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
            if (controllerCard.dt.Rows.Count != 0)
            {
                int index = 0;
                foreach (DataRow row in controllerCard.dt.Rows)
                {
                    controllerTrans.objTransaction = new ClsTransaction(row["TransactionID"].ToString(), Convert.ToDateTime(row["TransactionDate"]), Convert.ToDecimal(row["TotalAmount"]), row["PaymentType"].ToString(), row["CardID"].ToString(), row["ShopID"].ToString(), row["Remarks"].ToString(), Convert.ToDecimal(row["Subtotal"]), Convert.ToDecimal(row["PPN"]), Convert.ToDecimal(row["InitialBalance"]), Convert.ToDecimal(row["FinalBalance"]), row["TransactionStatus"].ToString());
                    UCCardTransList ucCardTranList = new UCCardTransList(controllerTrans.objTransaction);
                    ucCardTranList.Name = "CH" + index.ToString();
                    index++;
                    ucCardTranList.btnDetails.Click += (se, ev) => this.DetailsClick(sender, e, ucCardTranList.objtrans);
                    ucCardTranList.btnReceipt.Click += (se, ev) => this.ReceiptClick(sender, e, ucCardTranList.objtrans);
                    ucCardTranList.btnPrint.Click += (se, ev) => this.PrintClick(sender, e, ucCardTranList.objtrans);
                    FLCardTransList.Controls.Add(ucCardTranList);
                }
            }
        }

        public void DetailsClick(object sender, EventArgs e, ClsTransaction trans)
        {
            //ClsTransaction objtrans = trans;
            //FrmTransactionDetail frmTransdet = new FrmTransactionDetail(trans);
            //FormBlank frmBlank = new FormBlank();
            //frmBlank.Show();
            //frmTransdet.ShowDialog();
            //frmBlank.Close();
        }

        public void ReceiptClick(object sender, EventArgs e, ClsTransaction trans)
        {
            ClsTransaction objtrans = trans;

            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            ds = controllerReport.LoadTransactionReceipt(objtrans.TransactionID, parentfrm.lblShopID.Text, new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
            reportDoc = new MilenialPark.Reports.PrintTransactionReceipt();
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
            if (objtrans.TransactionID.Substring(0, 3) == "TRD" || objtrans.TransactionID.Substring(0, 3) == "TRT")
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

                    reportDoc.PrintOptions.PrinterName = this.printdocument.PrinterSettings.PrinterName;

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

        private void cbxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTransType.SelectedIndex == 0)
            {
                excludecategory = "WEEKEND";
            }
            else
            {
                excludecategory = "WEEKDAY";
            }
            FillFLPanel(null, null);
        }
    }
}
