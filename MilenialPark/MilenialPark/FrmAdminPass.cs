using MilenialPark.Controller;
using MilenialPark.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilenialPark
{
    public partial class FrmAdminPass : Form
    {
        public bool IsVerified { get; private set; } = false;
        public string VerifiedUserId { get; private set; } = "";
        public ControllerUser controllerUser = new ControllerUser();


        public FrmAdminPass()
        {
            InitializeComponent();
        }

        private void FrmAdminPass_Load(object sender, EventArgs e)
        {
            txtUserID.Focus();
            txtUserID.SelectAll();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string uid = (txtUserID.Text ?? "").Trim();
            string pwd = (txtpassword.Text ?? "").Trim();

            if (uid == "" || pwd == "")
            {
                MessageBox.Show("UserID/Password wajib diisi.");
                return;
            }

            // TODO: pakai fungsi login admin yang SUDAH ADA di project kamu
            // Contoh:

            bool ok = false;

            controllerUser.objUser = controllerUser.getOneUser(txtUserID.Text, txtpassword.Text);
            if (controllerUser.objUser == null)
            {
                ok = false;
            }
            else
            {
                if(controllerUser.objUser.TipeUser == "Admin")
                {
                    ok = true;
                }
            }

            // MVP: kalau kamu sudah punya current user admin login, bisa pakai ini:
            // ok = (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin" && uid == ClsStaticVariable.controllerUser.objUser.UserID);

            if (!ok)
            {
                MessageBox.Show("Akses ditolak. User bukan admin / password salah.");
                return;
            }

            IsVerified = true;
            VerifiedUserId = uid;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnVerify_Click(null, null);
            }
        }
    }
}
