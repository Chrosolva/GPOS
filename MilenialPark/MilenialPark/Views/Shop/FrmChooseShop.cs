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
using MilenialPark.Models;
using MilenialPark.UserControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;

namespace MilenialPark.Views.Shop
{
    public partial class FrmChooseShop : Form
    {
        #region properties

        public Mainform parentfrm;
        public ImageList imgList = new ImageList();
        public Image img;
        public ControllerShop controllerShop = new ControllerShop();
        public List<UCShopItem> listShopItem = new List<UCShopItem>();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public BindingSource bind = new BindingSource();

        public ControllerReport controllerReport = new ControllerReport();

        public ReportDocument reportDoc = new ReportDocument();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();

        #endregion

        public FrmChooseShop()
        {
            InitializeComponent();
        }

        public FrmChooseShop(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
        }

        private void btnAddorEdit_Click(object sender, EventArgs e)
        {
            if(dgvShopList.Rows.Count != 0)
            {
                ClsStaticVariable.ShopID = dgvShopList.CurrentRow.Cells["ShopID"].Value.ToString();
                this.Close();
            }
        }

        private void FrmChooseShop_Load(object sender, EventArgs e)
        {
            dt = controllerShop.getAllCAshier();
            dgvShopList.DataSource = dt;
        }
    }
}
