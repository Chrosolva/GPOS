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
using MilenialPark.Models;
using MilenialPark.UserControls;
using MilenialPark.Controller;

namespace MilenialPark.Views.Admin
{
    public partial class FrmCardManagement : Form
    {
        #region properties

        public Mainform parentfrm;
        public BindingSource bind = new BindingSource();
        public ControllerCard controllerCard = new ControllerCard();


        #endregion
        public FrmCardManagement()
        {
            InitializeComponent();
        }

        public FrmCardManagement(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
            IsiCardList();
        }

        public void IsiCardList()
        {
            bind.DataSource = controllerCard.getCardList();
            dgvCardList.DataSource = bind.DataSource;
            lblRowCount.Text = "Row Count: " + bind.Count.ToString();
            dgvCardList.Columns["Saldo"].DefaultCellStyle.Format = "#,##0";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCardID.Text = "";
            txtCardID.Enabled = true;
            txtCustomerName.Text = "";
            txtIdentityNo.Text = "";
            NUDQty.Value = 0;
        }

        private void dgvCardList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCardID.Text = dgvCardList.CurrentRow.Cells["CardID"].Value.ToString();
            txtCustomerName.Text = dgvCardList.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtIdentityNo.Text = dgvCardList.CurrentRow.Cells["NoIdentitas"].Value.ToString();
            NUDQty.Value = Convert.ToDecimal(dgvCardList.CurrentRow.Cells["Saldo"].Value);
            txtCardID.Enabled = false;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Card ID kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtCustomerName.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Customer Name kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else
            {
                if (!controllerCard.CheckCard(txtCardID.Text))
                {
                    // add Card

                    ClsCard objCard = new ClsCard(txtCardID.Text, txtCustomerName.Text, txtIdentityNo.Text ?? "", Convert.ToDecimal(NUDQty.Value), Convert.ToBoolean(chkActive.Checked));
                    try
                    {
                        controllerCard.InsertCard(objCard);
                        ClsFungsi.Pesan("Data Kartu Berhasil ditambah !!!", "INFO");
                        IsiCardList();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data Kartu gagal ditambah , pesan error = " + ex.Message, "ERROR");
                    }

                }
                else
                {
                    // edit user 
                    ClsCard objCard = new ClsCard(txtCardID.Text, txtCustomerName.Text, txtIdentityNo.Text ?? "", Convert.ToDecimal(NUDQty.Value), chkActive.Checked);
                    try
                    {
                        controllerCard.UpdateCard(objCard);
                        ClsFungsi.Pesan("Data Kartu Berhasil diUbah !!!", "INFO");
                        IsiCardList();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data Kartu gagal diUbah , pesan error = " + ex.Message, "ERROR");
                    }

                }
            }
        }

        public void CardSearch(object sender, EventArgs e)
        {
            bind.Filter = parentfrm.cbxCategory.Text + " like '%" + parentfrm.txtSearch.Text + "%'";
        }

        private void FrmCardManagement_Load(object sender, EventArgs e)
        {
            txtCardID.Focus();
            parentfrm.btnFind.Click += this.CardSearch;
            parentfrm.txtSearch.KeyUp += this.CardSearch;
            parentfrm.cbxCategory.Items.Add("CardID");
            parentfrm.cbxCategory.Items.Add("CustomerName");
            parentfrm.cbxCategory.Items.Add("NoIdentitas");
            parentfrm.cbxCategory.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Card ID kosong , silahkan dipilih terlebih dahulu !!!", "ERROR");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Card ID  " + txtCardID.Text + " ? ", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        controllerCard.DeleteCard(txtCardID.Text);
                        ClsFungsi.Pesan("Data Card Berhasil diHapus !!!", "INFO");
                        IsiCardList();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data Card gagal diHapus , pesan error = " + ex.Message, "ERROR");
                    }
                }
                else if (dialogResult == DialogResult.No) { }


            }
        }

        private void txtCardID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtCardID.Text.Trim().Length > 0)
                {
                    txtCardID.Text = Convert.ToInt32(txtCardID.Text).ToString();
                }
                else
                {
                    txtCardID.Text = "";
                }
                bind.Filter = "CardID like '%" + txtCardID.Text + "%'";
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtSearch.Text.Trim().Length > 0)
                {
                    txtSearch.Text = Convert.ToInt32(txtSearch.Text).ToString();
                }
                else
                {
                    txtSearch.Text = "";
                }
                bind.Filter =  "CardID like '%" + txtSearch.Text + "%'";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
