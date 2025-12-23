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
    public partial class FrmCashier : Form
    {
        public Mainform parentfrm;
        public ControllerShop controllerShop = new ControllerShop();
        public BindingSource bind = new BindingSource();
        public BindingSource bind2 = new BindingSource();
        public BindingSource bind3 = new BindingSource();
        public string filepath;

        public FrmCashier()
        {
            InitializeComponent();
        }

        public FrmCashier(Mainform parent)
        {
            parentfrm = parent;
            InitializeComponent();
        }

        private void FrmCashier_Load(object sender, EventArgs e)
        {
            // If a universal shop ID is configured, load it directly; otherwise fall back to per-user logic
            if (!string.IsNullOrEmpty(ClsStaticVariable.ShopID))
            {
                LoadUniversalShop(ClsStaticVariable.ShopID);
            }
            else
            {
                hasShop();
            }

            DataGridViewHelper.ApplyPOSStyle(dgvShopItem);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvShopItem, 100, 420);

            DataGridViewHelper.ApplyPOSStyle(dgvShopItemTiket);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvShopItemTiket, 100, 420);

            DataGridViewHelper.ApplyPOSStyle(dgvActivity);

            // For your POS “compact list” feel:
            DataGridViewHelper.SizeCompact(dgvActivity, 100, 420);
        }

        private void LoadUniversalShop(string shopId)
        {
            // Load the shop information by ShopID
            controllerShop.getcashier2(shopId);
            if (!string.IsNullOrEmpty(controllerShop.objShop.ShopName?.Trim()))
            {
                // Populate labels and text boxes
                parentfrm.lblShopID.Visible = true;
                parentfrm.lblShopName.Visible = true;
                parentfrm.lblMainProduct.Visible = true;
                parentfrm.lblAddress.Visible = true;

                parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                parentfrm.lblAddress.Text = controllerShop.objShop.Address;

                lblShopID2.Text = controllerShop.objShop.ShopID;
                txtShopName.Text = controllerShop.objShop.ShopName;
                txtMainProduct.Text = controllerShop.objShop.MainProduct;
                txtAddress.Text = controllerShop.objShop.Address;

                // Load items for the shop
                getShop();

                // Enable relevant buttons
                btnEdit.Enabled = true;
                btnCreateShopItem.Enabled = true;
                btnEditShopItem.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                // If no shop data found, disable item management
                btnEdit.Enabled = false;
                btnCreateShopItem.Enabled = false;
                btnEditShopItem.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // Original per-user shop check (optional if you still support separate cashier shops)
        public void hasShop()
        {
            if (controllerShop.checkCashier(ClsStaticVariable.controllerUser.objUser.UserID))
            {
                btnEdit.Enabled = true;
                controllerShop.getcashier(ClsStaticVariable.controllerUser.objUser.UserID);
                if (!string.IsNullOrEmpty(controllerShop.objShop.ShopName?.Trim()))
                {
                    parentfrm.lblShopID.Visible = true;
                    parentfrm.lblShopName.Visible = true;
                    parentfrm.lblMainProduct.Visible = true;
                    parentfrm.lblAddress.Visible = true;

                    parentfrm.lblShopID.Text = controllerShop.objShop.ShopID;
                    parentfrm.lblShopName.Text = controllerShop.objShop.ShopName;
                    parentfrm.lblMainProduct.Text = controllerShop.objShop.MainProduct;
                    parentfrm.lblAddress.Text = controllerShop.objShop.Address;

                    lblShopID2.Text = controllerShop.objShop.ShopID;
                    txtShopName.Text = controllerShop.objShop.ShopName;
                    txtMainProduct.Text = controllerShop.objShop.MainProduct;
                    txtAddress.Text = controllerShop.objShop.Address;
                    getShop();
                }
                btnCreateShopItem.Enabled = true;
                btnEditShopItem.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnCreateShopItem.Enabled = false;
                btnEditShopItem.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        public void getShop()
        {
            bind.DataSource = controllerShop.getShopItem(lblShopID2.Text);
            bind2.DataSource = controllerShop.getShopItemTiket(lblShopID2.Text);
            bind3.DataSource = controllerShop.getShopItemActivity(lblShopID2.Text);
            dgvShopItem.DataSource = bind;
            dgvShopItemTiket.DataSource = bind2;
            dgvActivity.DataSource = bind3;
        }

        private void btnCreateShopItem_Click(object sender, EventArgs e)
        {
            FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID2.Text);
            frmNEShopItem.Tag = "ADD";
            frmNEShopItem.lblFormTitle.Text = "Add Shop Item";
            frmNEShopItem.btnAddorEdit.Image = Resource.tab;
            frmNEShopItem.btnAddorEdit.Text = "Create";

            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmNEShopItem.ShowDialog();
            frmBlank.Close();
            getShop();
        }

        private void btnEditShopItem_Click(object sender, EventArgs e)
        {
            if (dgvShopItem.Rows.Count != 0)
            {
                FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID2.Text, dgvShopItem.CurrentRow.Cells["ItemID"].Value.ToString());
                frmNEShopItem.Tag = "EDIT";
                frmNEShopItem.lblFormTitle.Text = "Edit Supervisor";
                frmNEShopItem.btnAddorEdit.Image = Resource.edit;
                frmNEShopItem.btnAddorEdit.Text = "Edit";

                FormBlank frmBlank = new FormBlank();
                frmBlank.Show();
                frmNEShopItem.ShowDialog();
                frmBlank.Close();
                getShop();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShopName.Text))
            {
                ClsFungsi.Pesan("Nama Supervisor kosong!!!, mohon di isi terlebih dahulu", "INFO");
                return;
            }

            // Preserve the original shop UserID from objShop
            string originalUserId = controllerShop.objShop.UserID;

            controllerShop.setShop(lblShopID2.Text, txtShopName.Text, txtMainProduct.Text, txtAddress.Text, originalUserId);
            ClsFungsi.Pesan(controllerShop.UpdateShop(controllerShop.objShop), "INFO");

            LoadUniversalShop(lblShopID2.Text); // Refresh data after update
        }

        private void btnCreateShopItemTiket_Click(object sender, EventArgs e)
        {
            FrmNEShopItemTiket frmNEShopItemT = new FrmNEShopItemTiket(lblShopID2.Text);
            frmNEShopItemT.Tag = "ADD";
            frmNEShopItemT.lblFormTitle.Text = "Add Shop Item";
            frmNEShopItemT.btnAddorEdit.Image = Resource.tab;
            frmNEShopItemT.btnAddorEdit.Text = "Create";

            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmNEShopItemT.ShowDialog();
            frmBlank.Close();
            getShop();
        }

        private void btnEditShopItemTiket_Click(object sender, EventArgs e)
        {
            if (dgvShopItemTiket.Rows.Count != 0)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
                {
                    FrmNEShopItemTiket frmNEShopItemT = new FrmNEShopItemTiket(lblShopID2.Text, dgvShopItemTiket.CurrentRow.Cells["ItemID"].Value.ToString());
                    frmNEShopItemT.Tag = "EDIT";
                    frmNEShopItemT.lblFormTitle.Text = "Edit Supervisor";
                    frmNEShopItemT.btnAddorEdit.Image = Resource.edit;
                    frmNEShopItemT.btnAddorEdit.Text = "Edit";

                    FormBlank frmBlank = new FormBlank();
                    frmBlank.Show();
                    frmNEShopItemT.ShowDialog();
                    frmBlank.Close();
                    getShop();
                }
                else
                {
                    MessageBox.Show("Maaf Anda Bukan Admin");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID2.Text);
            frmNEShopItem.Tag = "ADD ACTIVITY";
            frmNEShopItem.lblFormTitle.Text = "Add Shop Item";
            frmNEShopItem.btnAddorEdit.Image = Resource.tab;
            frmNEShopItem.btnAddorEdit.Text = "Create";

            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmNEShopItem.ShowDialog();
            frmBlank.Close();
            getShop();
        }

        private void btnEditActivity_Click(object sender, EventArgs e)
        {
            if (dgvActivity.Rows.Count != 0)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
                {
                    FrmNEShopItem frmNEShopItem = new FrmNEShopItem(lblShopID2.Text, dgvActivity.CurrentRow.Cells["ItemID"].Value.ToString());
                    frmNEShopItem.Tag = "EDIT ACTIVITY";
                    frmNEShopItem.lblFormTitle.Text = "Edit Supervisor";
                    frmNEShopItem.btnAddorEdit.Image = Resource.edit;
                    frmNEShopItem.btnAddorEdit.Text = "Edit";

                    FormBlank frmBlank = new FormBlank();
                    frmBlank.Show();
                    frmNEShopItem.ShowDialog();
                    frmBlank.Close();
                    getShop();
                }
                else
                {
                    MessageBox.Show("Maaf Anda Bukan Admin");
                }
            }
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            if (dgvActivity.Rows.Count > 0)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
                {
                    DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Item Ticket  " +
                        dgvActivity.CurrentRow.Cells["ItemName"].Value.ToString() + " ? ", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClsFungsi.Pesan(controllerShop.DeleteShopActivity(dgvActivity.CurrentRow.Cells["ItemID"].Value.ToString()), "INFO");
                    }
                }
                else
                {
                    MessageBox.Show("Maaf Anda Bukan Admin");
                }

                getShop();
            }
            else
            {
                ClsFungsi.Pesan("Toko / Stand masih belum memiliki item");
            }
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            if (dgvShopItemTiket.Rows.Count > 0)
            {
                if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
                {
                    DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Transaksi Item  " +
                        dgvShopItemTiket.CurrentRow.Cells["ItemName"].Value.ToString() + " ? ", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClsFungsi.Pesan(controllerShop.DeleteShopItemTiket(
                            dgvShopItemTiket.CurrentRow.Cells["ItemID"].Value.ToString()), "INFO");
                    }
                }
                else
                {
                    MessageBox.Show("Maaf Anda Bukan Admin");
                }

                getShop();
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
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Item  " +
                    dgvShopItem.CurrentRow.Cells["ItemName"].Value.ToString() + " ? ", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ClsFungsi.Pesan(controllerShop.DeleteShopItem(
                        dgvShopItem.CurrentRow.Cells["ItemID"].Value.ToString()), "INFO");
                }
                getShop();
            }
            else
            {
                ClsFungsi.Pesan("Toko / Stand masih belum memiliki item");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Browse button is hidden in this version; no action needed
        }

        private void dgvShopItemTiket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No special action on cell click
        }
    }
}
