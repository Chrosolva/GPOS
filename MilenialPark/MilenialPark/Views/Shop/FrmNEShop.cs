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
using MilenialPark.Models;

namespace MilenialPark.Views.Shop
{
    public partial class FrmNEShop : Form
    {
        public ControllerShop controllerShop = new ControllerShop();
        public BindingSource bind = new BindingSource();
        public string filepath;

        public FrmNEShop()
        {
            InitializeComponent();
        }

        public FrmNEShop(ClsShop objShop)
        {
            InitializeComponent();
            this.controllerShop.objShop = objShop;
            //lblShopID2.Text = controllerShop.objShop.ShopID;
            //txtShopName.Text = controllerShop.objShop.ShopName;
            //txtAddress.Text = controllerShop.objShop.Address;
            //txtMainProduct.Text = controllerShop.objShop.MainProduct;
            //if (controllerShop.objShop.ShopStatus == "Active")
            //{
            //    TSActive.Checked = true;
            //}
            //else if (controllerShop.objShop.ShopStatus == "Inactive")
            //{
            //    TSActive.Checked = false;
            //}
            //else
            //{
            //    TSActive.Checked = false;
            //}

        }
    }
}
