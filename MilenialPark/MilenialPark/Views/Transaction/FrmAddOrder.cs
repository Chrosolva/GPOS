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

namespace MilenialPark.Views.Transaction
{
    public partial class FrmAddOrder : Form
    {
        #region properties

        public ClsShopItem objShopItem = new ClsShopItem();

        #endregion
        public FrmAddOrder()
        {
            InitializeComponent();
        }

        public FrmAddOrder(ClsShopItem shopItem)
        {
            InitializeComponent();
            this.objShopItem = shopItem;
            lblItemID.Text = objShopItem.ItemID;
            lblItemName2.Text = objShopItem.ItemName;
            lblItemDesc.Text = objShopItem.ItemDesc;
            pbfoodImage.Image = Image.FromFile(objShopItem.ImageFilePath);
            lblPrice.Text = objShopItem.Price.ToString("#,##0");
            lblTopUpAmount.Text = objShopItem.TopUpAmount.ToString("#,##0");
            lblCategory.Text = objShopItem.Category;
            lblWaktuBermain.Text = objShopItem.WaktuBermain.ToString();
            lblToleransi.Text = objShopItem.Toleransi.ToString();
        }

        private void FrmAddOrder_Load(object sender, EventArgs e)
        {
            NUDQty.Focus();
        }

        private void btnPalceOrder_Click(object sender, EventArgs e)
        {
            ClsTransactionDetail objtransdet = new ClsTransactionDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value), "NOTSERVED");
            ClsStaticVariable.objtransdet = objtransdet;

            ClsTransactionTiketDetail objtranstikdet = new ClsTransactionTiketDetail("ORDTMP", DateTime.Now, objShopItem.ItemID, objShopItem.ItemName, objShopItem.Price, Convert.ToInt32(NUDQty.Value),"NOTSERVED", DateTime.Now, DateTime.Now, objShopItem.WaktuBermain, objShopItem.Toleransi);
            ClsStaticVariable.objtranstikdet = objtranstikdet;


            ClsStaticVariable.placeorder = true;
            ClsStaticVariable.WaktuBermain = objShopItem.WaktuBermain;
            ClsStaticVariable.Toleransi = objShopItem.Toleransi;
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
