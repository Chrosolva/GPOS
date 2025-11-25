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
using System.Threading;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmTransactionHistory : Form
    {
        #region properties

        public Mainform parentfrm;
        public ImageList imgList = new ImageList();
        public Image img;
        public ControllerShop controllerShop = new ControllerShop();
        public List<UCShopItem> listShopItem = new List<UCShopItem>();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public BindingSource bind = new BindingSource();
        public BindingSource bind2 = new BindingSource();

        public ControllerReport controllerReport = new ControllerReport();

        public ReportDocument reportDoc = new ReportDocument();
        public DataSet ds = new DataSet();
        public DataTable dt;
        public DataTable dt2;
        public ClsTransaction objtrans = new ClsTransaction();
        PrintDialog printdialog1 = new PrintDialog();
        PrintDocument printdocument = new PrintDocument();
        string SearchCard = "";
        string substring3 = "";

        #endregion

        public FrmTransactionHistory()
        {
            InitializeComponent();
        }

        public FrmTransactionHistory(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
            hasShop();


            //btnFilter_Click(null, null);
            //dtpFrom.Value = DateTime.Now.AddDays(-1);
            //dtpTo.Value = DateTime.Now;
        }

        public void HistorySearch(object sender, EventArgs e)
        {
            bind2.Filter = parentfrm.cbxCategory.Text + " like '%" + parentfrm.txtSearch.Text + "%'";

            //if (parentfrm.cbxCategory.Text == "CardID")
            //{
            //    foreach (Control x in FLHistory.Controls)
            //    {
            //        UCOrderHistory orderhist = (UCOrderHistory)x;
            //        if (orderhist.objtrans.CardID.ToUpper().Contains(parentfrm.txtSearch.Text.ToUpper()))
            //        {
            //            orderhist.Visible = true;
            //        }
            //        else
            //        {
            //            orderhist.Visible = false;
            //        }
            //    }
            //}
            //else if (parentfrm.cbxCategory.Text == "TransactionID")
            //{
            //    foreach (Control x in FLHistory.Controls)
            //    {
            //        UCOrderHistory orderhist = (UCOrderHistory)x;
            //        if (orderhist.objtrans.TransactionID.ToUpper().Contains(parentfrm.txtSearch.Text.ToUpper()))
            //        {
            //            orderhist.Visible = true;
            //        }
            //        else
            //        {
            //            orderhist.Visible = false;
            //        }
            //    }
            //}
        }

        public void hasShop()
        {
            if (controllerShop.checkShopV2(ClsStaticVariable.controllerUser.objUser.UserID))
            {
                controllerShop.getShopandShopItem(ClsStaticVariable.controllerUser.objUser.UserID);
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

            }
        }

        private void FrmTransactionHistory_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpFrom.Value;
            cbxTransType.SelectedIndex = 0;
            cbxOption.SelectedIndex = 0;
            hasShop();
            btnFilter_Click(null, null);    
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text.Trim().Length == 0)
            {
                SearchCard = "";
            }
            else
            {
                SearchCard = txtCardID.Text;
            }

            if(cbxTransType.Text == "ALL")
            {
                substring3 = "%%";
            }
            else if (cbxTransType.Text == "WEEKDAY" || cbxTransType.Text == "WEEKEND")
            {
                substring3 = "TRT";
            }
            else if(cbxTransType.Text == "TOP-UP")
            {
                substring3 = "TRK";
            }
            else if(cbxTransType.Text == "ACTIVITY")
            {
                substring3 = "TRD";
            }

            controllerTrans.dt = controllerTrans.getTransaction(parentfrm.lblShopID.Text, new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0), new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59), SearchCard, cbxOption.Text, cbxTransType.Text.Replace("ALL", "%%"), substring3);
            bind.DataSource = controllerTrans.dt;
            getdetail();
        }

        public void getdetail()
        {
            if (controllerTrans.dt.Rows.Count != 0)
            {
                grpHead.Text = "Header , Row Count :" + controllerTrans.dt.Rows.Count.ToString();
                bind.DataSource = controllerTrans.dt;
                dgvTransaksi.DataSource = bind;
                string tmpID = dgvTransaksi.CurrentRow.Cells["TransactionID"].Value.ToString().Substring(0, 3);
                if (tmpID == "TRD" || tmpID == "TRK")
                {
                    dt2 = controllerTrans.gettransactionDetail(dgvTransaksi.CurrentRow.Cells["TransactionID"].Value.ToString());
                }
                else
                {
                    dt2 = controllerTrans.gettransactionTiketDetail(dgvTransaksi.CurrentRow.Cells["TransactionID"].Value.ToString());
                }
                grpDetail.Text = "Detail, Row Count :" + dt2.Rows.Count.ToString();
                bind2.DataSource = dt2;
                dgvTransaksiDetail.DataSource = bind2;
            }
            else
            {
                dgvTransaksiDetail.DataSource = null;
            }
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getdetail();
        }

        private void dgvTransaksi_SelectionChanged(object sender, EventArgs e)
        {
            getdetail();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(dgvTransaksi.Rows.Count!= 0)
            {
                //ClsTransaction objtrans = trans;

                DateTime from = dtpFrom.Value;
                DateTime to = dtpTo.Value;
                ds = controllerReport.LoadTransactionReceipt2(dgvTransaksi.CurrentRow.Cells["TransactionID"].Value.ToString(), parentfrm.lblShopID.Text, new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59));
                string sub3 = dgvTransaksi.CurrentRow.Cells["TransactionID"].Value.ToString().Substring(0, 3);
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
    }
}
