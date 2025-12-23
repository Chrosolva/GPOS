using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views;

namespace MilenialPark.Views.Shop
{
    public partial class FrmNEShopItem : Form
    {
        #region properties
        public string ShopID;
        public string ItemID;
        public ControllerShop controllerShop = new ControllerShop();
        public DataTable dt = new DataTable();

        #endregion

        public FrmNEShopItem()
        {
            InitializeComponent();
        }

        public FrmNEShopItem(string ShopID)
        {
            this.ShopID = ShopID;
            InitializeComponent();
            setCbxCategory();
            pbpreview.Image = Image.FromFile("C://WHNPOSPict//notfound.png");
        }

        public FrmNEShopItem(string ShopID, string ItemID)
        {
            this.ShopID = ShopID;
            this.ItemID = ItemID;
            InitializeComponent();
            setCbxCategory();
            setEditCondition();
        }

        public void setCbxCategory()
        {

            dt = controllerShop.getAllcategory();
            cbxCategory.Items.Clear();

            if (dt.Rows.Count == 0)
            {
                cbxCategory.Items.Add("Food");
                cbxCategory.SelectedIndex = 0;

            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    cbxCategory.Items.Add(row["Category"].ToString());
                    cbxCategory.SelectedIndex = 0;
                }
            }
        }

        public void setEditCondition()
        {
            controllerShop.dt = controllerShop.getOneShopItem(ShopID, ItemID);
            lblItemID.Text = controllerShop.dt.Rows[0]["ItemID"].ToString();
            txtItemName.Text = controllerShop.dt.Rows[0]["ItemName"].ToString();
            txtItemDesc.Text = controllerShop.dt.Rows[0]["ItemDesc"].ToString();
            txtImageFilePath.Text = controllerShop.dt.Rows[0]["ImageFilePath"].ToString();
            NUDprice.Value = Convert.ToDecimal(controllerShop.dt.Rows[0]["Price"]);
            pbpreview.Image = Image.FromFile(txtImageFilePath.Text);
            foreach (var item in cbxCategory.Items)
            {
                if (item.ToString() == controllerShop.dt.Rows[0]["Category"].ToString())
                {
                    cbxCategory.SelectedItem = item;
                }
            }
        }

        private void FrmNEShopItem_Load(object sender, EventArgs e)
        {
            txtItemName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog openimage = new OpenFileDialog();
            openimage.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openimage.ShowDialog() == DialogResult.OK)
            {
                pbpreview.Image = Image.FromFile(openimage.FileName);
                txtImageFilePath.Text = openimage.FileName.ToString();
            }

        }

        private void btnAddorEdit_Click(object sender, EventArgs e)
        {
            if (this.Tag.ToString() == "ADD")
            {   
                if (controllerShop.checkShopItem(txtItemName.Text.Trim(), ShopID))
                {
                    ClsFungsi.Pesan("Item Sudah ada !!! mohon diperikasa kembali", "INFO");
                }
                else
                {
                    controllerShop.autogenerateShopItemID(this.ShopID);
                    controllerShop.setShopItem3(controllerShop.ShopItemID, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text, Convert.ToDecimal(nudtopup.Value));
                    ClsFungsi.Pesan(controllerShop.InsertShopItem(controllerShop.objShopItem), "INFO");
                }

            }
            else if (this.Tag.ToString() == "EDIT")
            {
                controllerShop.setShopItem3(lblItemID.Text, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text, Convert.ToDecimal(nudtopup.Value));
                ClsFungsi.Pesan(controllerShop.UpdateShopitem(controllerShop.objShopItem), "INFO");
            }
            else if (this.Tag.ToString() == "ADD ACTIVITY")
            {
                if (controllerShop.checkShopItem(txtItemName.Text.Trim(), ShopID))
                {
                    ClsFungsi.Pesan("Item Sudah ada !!! mohon diperikasa kembali", "INFO");
                }
                else
                {
                    //controllerShop.autogenerateShopItemIDActivity(this.ShopID);
                    controllerShop.autogenerateShopItemID(this.ShopID);
                    controllerShop.setShopItem2(controllerShop.ShopItemID, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text);
                    ClsFungsi.Pesan(controllerShop.InsertShopItem(controllerShop.objShopItem), "INFO");
                }
            }
            else if (this.Tag.ToString() == "EDIT ACTIVITY")
            {
                controllerShop.setShopItem2(lblItemID.Text, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text);
                ClsFungsi.Pesan(controllerShop.UpdateShopitem(controllerShop.objShopItem), "INFO");
            }

            Close();
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openimage = new OpenFileDialog();
            openimage.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openimage.ShowDialog() == DialogResult.OK)
            {
                pbpreview.Image = Image.FromFile(openimage.FileName);
                txtImageFilePath.Text = openimage.FileName.ToString();
            }
        }
    }
}
