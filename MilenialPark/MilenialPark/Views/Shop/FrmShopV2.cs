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
using MilenialPark.Views;
using MilenialPark.Controller;
using MilenialPark.Models;
using MilenialPark.UserControls;

namespace MilenialPark.Views.Shop
{
    public partial class FrmShopV2 : Form
    {
        #region properties

        public Mainform parentfrm;
        public ControllerShop controllerShop = new ControllerShop();
        public BindingSource bind = new BindingSource();
        public BindingSource bind2 = new BindingSource();
        public ControllerTransaction controllerTrans = new ControllerTransaction();

        #endregion

        public FrmShopV2()
        {
            InitializeComponent();
        }
        public FrmShopV2(Mainform main)
        {
            InitializeComponent();
            this.parentfrm = main;
        }

        public void getShopList(object sender, EventArgs e)
        {
            FLShopList.Controls.Clear();
            controllerShop.dt = controllerShop.getAllShopV2(ClsStaticVariable.ShopID);
            if (controllerShop.dt.Rows.Count != 0)
            {
                foreach (DataRow row in controllerShop.dt.Rows)
                {
                    ClsShop shop = new ClsShop(row["ShopID"].ToString(), row["ShopName"].ToString(), row["MainProduct"].ToString(), row["Address"].ToString(), row["UserID"].ToString(), row["ShopStatus"].ToString());
                    UCShopList shopList = new UCShopList(shop);
                    controllerShop.objShop = shop;
                    shopList.btnDetails.Click += (se, ev) => this.DetailsClick(sender, e, shopList);
                    FLShopList.Controls.Add(shopList);
                }
            }
        }

        public void DetailsClick(object sender, EventArgs e, UCShopList shopList)
        {
            getShopItem(shopList.objShop.ShopID);
            lblShopID.Text = shopList.objShop.ShopID;
        }

        public void ItemSearch(object sender, EventArgs e)
        {
            bind.Filter = parentfrm.cbxCategory.Text + " like '%" + parentfrm.txtSearch.Text + "%'";
        }

        public void getShopItem(string ShopID)
        {
            bind.DataSource = controllerShop.getShopItem(ShopID);
            dgvShopItem.DataSource = bind;
            lblrowcount.Text = "Row Count: " + bind.Count.ToString();

            dgvShopItem.Columns["ItemID"].FillWeight = 80;
            dgvShopItem.Columns["ItemName"].FillWeight = 220;
            dgvShopItem.Columns["Price"].FillWeight = 90;
            dgvShopItem.Columns["Category"].FillWeight = 100;

            dgvShopItem.Columns["ItemID"].MinimumWidth = 90;
            dgvShopItem.Columns["ItemName"].MinimumWidth = 220;
            dgvShopItem.Columns["Price"].MinimumWidth = 90;
            dgvShopItem.Columns["Category"].MinimumWidth = 120;
        }

        private void FrmShopV2_Load(object sender, EventArgs e)
        {
            getShopList(sender, e);
            parentfrm.btnFind.Click += this.ItemSearch;
            parentfrm.txtSearch.TextChanged += this.ItemSearch;
            parentfrm.cbxCategory.Items.Add("ItemName");
            parentfrm.cbxCategory.Items.Add("ItemDesc");
            parentfrm.cbxCategory.SelectedIndex = 0;

            DataGridViewHelper.ApplyPOSStyle(dgvShopItem);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvShopItem, 80, 420);

            // Optional: mark some columns readonly look
            DataGridViewHelper.MarkReadOnlyColumns(dgvShopItem, "ItemID", "ShopID");
            dgvShopItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmNEShop frmNEShop = new FrmNEShop();
            //frmNEShop.btnCreateorEdit.Text = "Create";
            //frmNEShop.btnCreateorEdit.Tag = "Create";
            //frmNEShop.lblFormTitle.Text = "Create Shop / Stand";
            //frmNEShop.TSActive.Enabled = false;

            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmNEShop.ShowDialog();
            frmBlank.Close();

            getShopList(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblShopID.Text.Trim() == "-")
            {
                ClsFungsi.Pesan("Anda masih belum memilih toko / stand untuk di edit, silahkan tekan tombol details pada toko / stand !!!");
            }
            else
            {
                controllerShop.getShopandShopItem2(lblShopID.Text);
                FrmNEShop frmNEShop = new FrmNEShop(controllerShop.objShop);
                //frmNEShop.btnCreateorEdit.Text = "Edit";
                //frmNEShop.btnCreateorEdit.Tag = "Edit";
                //frmNEShop.lblFormTitle.Text = "Edit Shop / Stand";
                //frmNEShop.btnCreateorEdit.Image = Resource.edit;

                FormBlank frmBlank = new FormBlank();
                frmBlank.Show();
                frmNEShop.ShowDialog();
                frmBlank.Close();

                getShopList(sender, e);
            }
        }

        private void btnCreateShopItem_Click(object sender, EventArgs e)
        {
            if (lblShopID.Text.Trim() == "-")
            {
                ClsFungsi.Pesan("Anda masih belum memilih toko / stand untuk di edit, silahkan tekan tombol details pada toko / stand !!!");
            }
            else
            {
                FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID.Text);
                frmNEShopItem.Tag = "ADD";
                //frmNEShopItem.lblFormTitle.Text = "Add Shop Item";
                //frmNEShopItem.btnAddorEdit.Image = Resource.tab;
                //frmNEShopItem.btnAddorEdit.Text = "Create";

                FormBlank frmBlank = new FormBlank();
                frmBlank.Show();
                frmNEShopItem.ShowDialog();
                frmBlank.Close();
                getShopItem(lblShopID.Text);
            }
        }

        private void btnEditShopItem_Click(object sender, EventArgs e)
        {
            if (dgvShopItem.Rows.Count > 0)
            {

                FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID.Text, dgvShopItem.CurrentRow.Cells["ItemID"].Value.ToString());
                frmNEShopItem.Tag = "EDIT";
                //frmNEShopItem.lblFormTitle.Text = "Edit Shop Item";
                //frmNEShopItem.btnAddorEdit.Image = Resource.edit;
                //frmNEShopItem.btnAddorEdit.Text = "Edit";

                FormBlank frmBlank = new FormBlank();
                frmBlank.Show();
                frmNEShopItem.ShowDialog();
                frmBlank.Close();
                getShopItem(lblShopID.Text);
            }
            else
            {
                ClsFungsi.Pesan("Toko / Stand masih belum memiliki item");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShopItem.Rows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Shop Item  " + dgvShopItem.CurrentRow.Cells["ItemName"].Value.ToString() + " ? ", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ClsFungsi.Pesan(controllerShop.DeleteShopItem(dgvShopItem.CurrentRow.Cells["ItemID"].Value.ToString()), "INFO");
                }
                else if (dialogResult == DialogResult.No) { }
                getShopItem(lblShopID.Text);
            }
            else
            {
                ClsFungsi.Pesan("Toko / Stand masih belum memiliki item");
            }
        }
    }
}
