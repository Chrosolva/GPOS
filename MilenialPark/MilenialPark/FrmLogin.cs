using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Views;
using MilenialPark.Master;
using MilenialPark.Models;

namespace MilenialPark
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void txtpassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserID.Focus();
                iconButton2_Click(null, null);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //ClsStaticVariable.setNewConnection("cradlesp_desktop", txtServer.Text);
            
            if (txtUserID.Text.Trim() == "" || txtUserID.Text.Trim() == null)
            {
                ClsFungsi.Pesan("UserID atau Password Kosong", "INFO");
            }
            else if (txtpassword.Text.Trim() == "" || txtpassword.Text.Trim() == null)
            {
                ClsFungsi.Pesan("UserID atau Password Kosong", "INFO");
            }
            else
            {
                try
                {
                    ClsStaticVariable.controllerUser.objUser = ClsStaticVariable.controllerUser.getOneUser(txtUserID.Text, txtpassword.Text);
                    if (ClsStaticVariable.controllerUser.objUser == null)
                    {
                        ClsFungsi.Pesan("UserID atau Password Salah", "INFO");
                    }
                    else
                    {

                        if (txtpassword.Text == new ClsCrypthography().DecryptString(ClsStaticVariable.controllerUser.objUser.Password))
                        {
                            Mainform frmMainForm = new Mainform(this);
                            frmMainForm.Show();
                        }
                        else
                        {
                            ClsFungsi.Pesan("UserID atau Password Salah", "INFO");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void setcbxCategory()
        {
            cbxCategory.Items.Clear();
            cbxCategory.DisplayMember = "Text";
            cbxCategory.ValueMember = "Value";
            int selected = 0;
            foreach (ClsCabang x in ClsStaticVariable.controllerUser.listcabang)
            {
                if (ClsStaticVariable.controllerUser.listcabang.Count != 0)
                {
                    cbxCategory.Items.Add(new { Text = (x.KodeCabang + "-" + x.NamaCabang), Value = x.KodeCabang });
                }
                cbxCategory.SelectedIndex = selected;
            }
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            ClsStaticVariable.setNewConnection("WHNPOS", txtServer.Text);
            ClsStaticVariable.controllerUser.SetCabang();

            setcbxCategory();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsStaticVariable.KodeBranch = Convert.ToString((cbxCategory.SelectedItem as dynamic).Value);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
