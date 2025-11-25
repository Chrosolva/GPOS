using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Master;
using MilenialPark.Models;
using MilenialPark.Controller;

namespace MilenialPark.UserControls
{
    public partial class UCShopList : UserControl
    {
        #region properties

        public ClsShop objShop = new ClsShop();

        #endregion 

        public UCShopList()
        {
            InitializeComponent();
        }

        public UCShopList(ClsShop shop)
        {
            InitializeComponent();
            this.objShop = shop;
            lblShopID.Text = "Shop ID: " + objShop.ShopID;
            lblShopName.Text = "Shop Name: " + objShop.ShopName;
            lblMainProduct.Text = "Main Product : " + objShop.MainProduct;
            lblAddress.Text = "Address: " + objShop.Address;
            lblUserID.Text = "User ID: " + objShop.UserID;
        }

        private void contentPanel_MouseEnter(object sender, EventArgs e)
        {
            contentPanel.BackColor = Color.FromArgb(249, 130, 68);
        }

        private void contentPanel_MouseLeave(object sender, EventArgs e)
        {
            contentPanel.BackColor = Color.White;
        }
    }
}
