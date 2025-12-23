using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Views;
using MilenialPark.Master;
using MilenialPark.UserControls;
using MilenialPark.Controller;
using MilenialPark;


namespace MilenialPark.Views.Transaction
{
    public partial class FrmMainOrder : Form
    {
        #region properties

        public Mainform parentfrm;
        public ControllerShop controllerShop = new ControllerShop();
        public Card.FrmCards frmCard;
        public Admin.FrmCardManagement frmCardManagement;
        public Transaction.FrmOrderTiket frmOrderTiket;
        public Transaction.FrmOrder frmOrder;


        #endregion

        public FrmMainOrder()
        {
            InitializeComponent();
        }

        public FrmMainOrder(Mainform parent)
        {
            InitializeComponent();
            parentfrm = parent;
        }

        private void FrmMainOrder_Load(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            // Initiate Forms
            frmCard = new Card.FrmCards(parentfrm);
            frmCard.Text = "Card";
            frmCard.TopLevel = false;
            frmCard.FormBorderStyle = FormBorderStyle.None;
            frmCard.Dock = DockStyle.Fill;

            frmCardManagement = new Admin.FrmCardManagement(parentfrm);
            frmCardManagement.Text = "Card Management";
            frmCardManagement.TopLevel = false;
            frmCardManagement.FormBorderStyle = FormBorderStyle.None;
            frmCardManagement.Dock = DockStyle.Fill;

            frmOrderTiket = new Transaction.FrmOrderTiket(parentfrm);
            frmOrderTiket.Text = "Order Tiket";
            frmOrderTiket.TopLevel = false;
            frmOrderTiket.FormBorderStyle = FormBorderStyle.None;
            frmOrderTiket.Dock = DockStyle.Fill;

            controllerShop.getShop2(ClsStaticVariable.ShopID);
            frmOrder = new Transaction.FrmOrder(parentfrm, controllerShop.objShop);
            frmOrder.Text = "Order";
            frmOrder.TopLevel = false;
            frmOrder.FormBorderStyle = FormBorderStyle.None;
            frmOrder.Dock = DockStyle.Fill;

            TPOrders.Controls.Add(frmOrderTiket);
            frmOrderTiket.Show();
            TPNEOrders.Controls.Add(frmOrder);
            frmOrder.Show();
            TPTopUpCard.Controls.Add(frmCard);
            frmCard.Show();
            TPDaftarKartu.Controls.Add(frmCardManagement);
            frmCardManagement.Show();
        }

        private void TCMainOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TCMainOrder.SelectedIndex == 0)
            {
                frmOrderTiket.btnFilter_Click(null, null);
            }
        }

        
    }
}
