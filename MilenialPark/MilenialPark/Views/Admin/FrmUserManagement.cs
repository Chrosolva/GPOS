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

namespace MilenialPark.Views.Admin
{
    public partial class FrmUserManagement : Form
    {
        #region properties

        public Mainform parentfrm;
        public BindingSource bind = new BindingSource();

        #endregion

        public FrmUserManagement()
        {
            InitializeComponent();
        }

        public FrmUserManagement(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
            IsiUserList();
        }

        public void IsiUserList()
        {
            bind.DataSource = ClsStaticVariable.controllerUser.getListUser();
            dgvUserList.DataSource = bind.DataSource;
        }

        public void UserSearch(object sender, EventArgs e)
        {
            bind.Filter = parentfrm.cbxCategory.Text + " like '%" + parentfrm.txtSearch.Text + "%'";
        }

        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            parentfrm.btnFind.Click += this.UserSearch;
            parentfrm.txtSearch.TextChanged += this.UserSearch;
            parentfrm.cbxCategory.Items.Add("UserID");
            parentfrm.cbxCategory.Items.Add("UserName");
            parentfrm.cbxCategory.Items.Add("TipeUser");
            parentfrm.cbxCategory.SelectedIndex = 0;
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserID.Text = dgvUserList.CurrentRow.Cells["UserID"].Value.ToString();
            txtUserName.Text = dgvUserList.CurrentRow.Cells["UserName"].Value.ToString();
            txtPassword.Text = new ClsCrypthography().DecryptString(dgvUserList.CurrentRow.Cells["Password"].Value.ToString());
            txtConfirmPassword.Text = new ClsCrypthography().DecryptString(dgvUserList.CurrentRow.Cells["Password"].Value.ToString());
            cbxUser.Text = dgvUserList.CurrentRow.Cells["TipeUser"].Value.ToString();
            txtUserID.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserID.Enabled = true;
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbxUser.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if (txtUserID.Text.Trim() == "")
                {
                    ClsFungsi.Pesan("User ID kosong , silahkan dipilih terlebih dahulu !!!", "ERROR");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data user ID  " + txtUserID.Text + " ? ", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string encrypt = new ClsCrypthography().EncryptString(txtPassword.Text);
                        ClsUser objUser = new ClsUser(txtUserID.Text, txtUserName.Text, encrypt, "", cbxUser.Text);
                        try
                        {
                            ClsStaticVariable.controllerUser.DeleteUser(objUser);
                            ClsFungsi.Pesan("Data User Berhasil diHapus !!!", "INFO");
                            IsiUserList();
                        }
                        catch (Exception ex)
                        {
                            ClsFungsi.Pesan("Data User gagal diHapus , pesan error = " + ex.Message, "ERROR");
                        }
                    }
                    else if (dialogResult == DialogResult.No) { }


                }
            }
            else
            {
                ClsFungsi.Pesan("Maaf Anda Bukan Admin ", "INFO");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() == "")
            {
                ClsFungsi.Pesan("User ID kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtUserName.Text.Trim() == "")
            {
                ClsFungsi.Pesan("User Name kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtPassword.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Password kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtConfirmPassword.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Konfirmasi Password kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtPassword.Text.Length != 0 && txtPassword.Text != txtConfirmPassword.Text)
            {
                ClsFungsi.Pesan("Password dan Konfirmasi Password Salah, Silahkan diperiksa kembali", "ERROR");
            }
            else if (cbxUser.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Tipe User kosong , silahkan dipilih terlebih dahulu !!!", "ERROR");
            }
            else
            {
                if (!ClsStaticVariable.controllerUser.CheckUser(txtUserID.Text))
                {
                    // add user
                    string encrypt = new ClsCrypthography().EncryptString(txtPassword.Text);
                    ClsUser objUser = new ClsUser(txtUserID.Text, txtUserName.Text, encrypt, "", cbxUser.Text);
                    try
                    {
                        ClsStaticVariable.controllerUser.InsertUser(objUser);
                        ClsFungsi.Pesan("Data User Berhasil ditambah !!!", "INFO");
                        IsiUserList();
                        btnReset_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data User gagal ditambah , pesan error = " + ex.Message, "ERROR");
                    }

                }
                else
                {
                    // edit user 
                    string encrypt = new ClsCrypthography().EncryptString(txtPassword.Text);
                    ClsUser objUser = new ClsUser(txtUserID.Text, txtUserName.Text, encrypt, "", cbxUser.Text);
                    try
                    {
                        ClsStaticVariable.controllerUser.EditUser(objUser);
                        ClsFungsi.Pesan("Data User Berhasil diUbah !!!", "INFO");
                        IsiUserList();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data User gagal diUbah , pesan error = " + ex.Message, "ERROR");
                    }

                }
            }
        }
    }
}
