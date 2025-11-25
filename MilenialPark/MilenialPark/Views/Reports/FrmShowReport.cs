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
using MilenialPark.UserControls;
using MilenialPark.Controller;
using MilenialPark.Views;
using MilenialPark.Models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;

namespace MilenialPark.Views.Reports
{
    public partial class FrmShowReport : Form
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

        public ReportDocument reportDoc = new ReportDocument();
        public DataSet ds = new DataSet();
        public ControllerReport controllerReport = new ControllerReport();

        #endregion
        public FrmShowReport()
        {
            InitializeComponent();
        }

        public FrmShowReport(ReportDocument reportDoc)
        {
            InitializeComponent();
            this.reportDoc = reportDoc;
        }

        private void FrmShowReport_Load(object sender, EventArgs e)
        {
            if (reportDoc != null)
            {
                crViewer.ReportSource = reportDoc;
            }
        }
    }
}
