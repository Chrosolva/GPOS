using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Models;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views.Transaction;

namespace MilenialPark.UserControls
{
    public partial class UCShopItem : UserControl
    {
        #region properties

        public ClsShopItem objShopItem = new ClsShopItem();

        #endregion
        public UCShopItem()
        {
            InitializeComponent();
        }

        public UCShopItem(ClsShopItem shopitem)
        {
            InitializeComponent();
            this.objShopItem = shopitem;
            //this.pbShopItem.Image = Image.FromFile(objShopItem.ImageFilePath);
            this.lblItemName.Text = objShopItem.ItemName;
            lblItemPrice.Text = objShopItem.Price.ToString("#,##0");
            lblCategory.Text = objShopItem.Category;
        }

        private void outerpanel_MouseEnter(object sender, EventArgs e)
        {
            outerpanel.BackColor = Color.FromArgb(249, 130, 68);
        }

        private void outerpanel_MouseLeave(object sender, EventArgs e)
        {
            outerpanel.BackColor = Color.Transparent;
        }
    }
}
