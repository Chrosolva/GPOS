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

namespace MilenialPark.Views
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                string encrypt = new ClsCrypthography().EncryptString(txtPassword.Text);
                ClsUser objUser = new ClsUser(ClsStaticVariable.controllerUser.objUser.UserID, ClsStaticVariable.controllerUser.objUser.UserName, encrypt, ClsStaticVariable.controllerUser.objUser.HakAkses, ClsStaticVariable.controllerUser.objUser.TipeUser);
                try
                {
                    ClsStaticVariable.controllerUser.ChangePassword(objUser);
                    ClsFungsi.Pesan("Data User Berhasil diUbah !!!", "INFO");
                }
                catch (Exception ex)
                {
                    ClsFungsi.Pesan("Data User gagal diUbah , pesan error = " + ex.Message, "ERROR");
                }
            }
            else
            {
                ClsFungsi.Pesan("Data Password tidak sama antara password dan konfirmasi password, silahkan di input kembali");
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtPassword.Focus();
            }
            this.Close();
        }
    }
}
