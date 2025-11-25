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

namespace MilenialPark.Views.Shop
{
    public partial class FrmNEShopItemTiket : Form
    {
        #region properties
        public string ShopID;
        public string ItemID;
        public ControllerShop controllerShop = new ControllerShop();
        public DataTable dt = new DataTable();

        #endregion

        public FrmNEShopItemTiket()
        {
            InitializeComponent();
        }

        public FrmNEShopItemTiket(string ShopID)
        {
            this.ShopID = ShopID;
            InitializeComponent();
            setCbxCategory();   
            pbpreview.Image = Image.FromFile("C://WHNPOSPict//notfound.png");
        }

        public FrmNEShopItemTiket(string ShopID, string ItemID)
        {
            this.ShopID = ShopID;
            this.ItemID = ItemID;
            InitializeComponent();
            setCbxCategory();
            setEditCondition();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setCbxCategory()
        {

            //dt = controllerShop.getAllcategoryTicket();
            //cbxCategory.Items.Clear();

            ////if (dt.Rows.Count == 0)
            ////{
            ////    cbxCategory.Items.Add("TICKET");
            ////    cbxCategory.SelectedIndex = 0;

            ////}
            ////else
            ////{
            ////    foreach (DataRow row in dt.Rows)
            ////    {
            ////        cbxCategory.Items.Add(row["Category"].ToString());
            ////        cbxCategory.SelectedIndex = 0;
            ////    }
            ////}

            //cbxCategory.Items.Add("TICKET"); 
            //cbxCategory.Items.Add("ONE-TIME-TICKET");
            //cbxCategory.Items.Add("EXTEND-TICKET");
        }

        public void setEditCondition()
        {
            controllerShop.dt2 = controllerShop.getOneShopItemTiket(ShopID, ItemID);
            lblItemID.Text = controllerShop.dt2.Rows[0]["ItemID"].ToString();
            txtItemName.Text = controllerShop.dt2.Rows[0]["ItemName"].ToString();
            txtItemDesc.Text = controllerShop.dt2.Rows[0]["ItemDesc"].ToString();
            txtImageFilePath.Text = controllerShop.dt2.Rows[0]["ImageFilePath"].ToString();
            NUDprice.Value = Convert.ToDecimal(controllerShop.dt2.Rows[0]["Price"]);
            pbpreview.Image = Image.FromFile(txtImageFilePath.Text);
            NUDWaktuBermain.Value = Convert.ToInt32(controllerShop.dt2.Rows[0]["WaktuBermain"]);
            NUDToleransi.Value = Convert.ToInt32(controllerShop.dt2.Rows[0]["Toleransi"]);

            foreach (var item in cbxCategory.Items)
            {
                if (item.ToString() == controllerShop.dt2.Rows[0]["Category"].ToString())
                {
                    cbxCategory.SelectedItem = item;
                }
            }
        }

        private void FrmNEShopItemTiket_Load(object sender, EventArgs e)
        {
            txtItemName.Focus();
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
                    ClsFungsi.Pesan("Item Sudah ada !!! mohon diperiksa kembali", "INFO");
                }
                else
                {
                    controllerShop.autogenerateShopItemTiketID(this.ShopID);
                    controllerShop.setShopItemTiket2(controllerShop.ShopItemID, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text, Convert.ToInt32(NUDWaktuBermain.Value), Convert.ToInt32(NUDToleransi.Value));
                    ClsFungsi.Pesan(controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket), "INFO");

                }

            }
            else if (this.Tag.ToString() == "EDIT")
            {
                controllerShop.setShopItemTiket2(lblItemID.Text, ShopID, txtItemName.Text, Convert.ToDecimal(NUDprice.Value), txtItemDesc.Text, txtImageFilePath.Text, cbxCategory.Text, Convert.ToInt32(NUDWaktuBermain.Value), Convert.ToInt32(NUDToleransi.Value));
                ClsFungsi.Pesan(controllerShop.UpdateShopitemTiket  (controllerShop.objShopItemTiket), "INFO");
            }

            Close();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxCategory.Text == "ONE-TIME-TICKET")
            {
                NUDWaktuBermain.Enabled = false;
                NUDToleransi.Enabled = false;
            }
            else
            {
                NUDWaktuBermain.Enabled = true;
                NUDToleransi.Enabled = true;
            }
        }
    }
}
