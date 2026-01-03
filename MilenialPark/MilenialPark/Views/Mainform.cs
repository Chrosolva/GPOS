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
using MilenialPark.UserControls;
using MilenialPark.Controller;
using MilenialPark;

namespace MilenialPark.Views
{
    public partial class Mainform : Form
    {
        #region properties

        public FormLogin frmLogin;
        private Form currentChildForm;
        FrmGateControl frmGatectrl = new FrmGateControl();
        public ControllerShop controllerShop = new ControllerShop();

        #endregion

        #region function

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only a single form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        #endregion

        public Mainform()
        {
            InitializeComponent();
        }

        public Mainform(FormLogin login)
        {
            this.frmLogin = login;
            this.frmLogin.Hide();
            InitializeComponent();
            lblUserName.Text = ClsStaticVariable.controllerUser.objUser.UserName;
            BranchCode.Text = ClsStaticVariable.KodeBranch;

            if (ClsStaticVariable.controllerUser.objUser.TipeUser != "SuperAdmin" && ClsStaticVariable.controllerUser.objUser.TipeUser != "Admin")
            {
                btnadminManagement.Visible = false;
            }
            else
            {
                btnadminManagement.Visible = true;
            }

            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Supervisor")
            {
                btnShop.Visible = false;
                btnOrders.Visible = false;
                btnHistory.Visible = false;
            }
            else if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Cashier")
            {

            }

            //hasShop();
            setHakAkses();
        }

        //SET HAK AKSES
        public void setHakAkses()
        {
            string TipeUser = ClsStaticVariable.controllerUser.objUser.TipeUser;
            if (TipeUser == "SuperAdmin" || TipeUser == "Admin")
            {
                foreach (Control x in sideMenuPanel.Controls)
                {
                    x.Visible = true;
                }
            }
            else
            {
                if (TipeUser == "Cashier")
                {
                    btnShop.Visible = true;
                    btnOrders.Visible = true;
                    btnHistory.Visible = true;
                    btnReports.Visible = true;
                }

                if (TipeUser == "Supervisor")
                {
                    btnCashier.Visible = true;
                    btnCards.Visible = true;
                    btnHistory.Visible = true;
                    btnReports.Visible = true;
                    btnOrders.Visible = true;
                }
                if (TipeUser == "Staf")
                {
                    btnHistory.Visible = true;
                    btnCards.Visible = true;
                    btnReports.Visible = true;
                    btnUserManagement.Visible = true;
                    btnCardManagement.Visible = true;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //BackUp 
            FrmBackUPDB frmBackUp = new FrmBackUPDB();
            frmBackUp.Show();
            this.Focus();
            frmBackUp.btnBackUp_Click(null, null);
            frmBackUp.Hide();
            frmBackUp.Close();

            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(btnMaximize.Tag.ToString() =="Normal")
            {
                btnMaximize.Tag = "Maximized";
                WindowState = FormWindowState.Maximized;
                btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            }
            else
            {
                btnMaximize.Tag = "Normal";
                WindowState = FormWindowState.Normal;
                btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btngear_Click(object sender, EventArgs e)
        {
            if (btngear.Tag.ToString() == "Show")
            {
                btngear.Tag = "Hide";
                //rightPanel.Visible = false;
                rightPanel.Width = 250;
                grpHeader.Width -= 240;
                MainPanel.Width -= 240;
                //guna2Transition1.ShowSync(rightPanel);
                //this.Width = 1371;
            }
            else if (btngear.Tag.ToString() == "Hide")
            {
                btngear.Tag = "Show";
                //rightPanel.Visible = false;
                rightPanel.Width = 10;
                grpHeader.Width += 240;
                MainPanel.Width += 240;
                //guna2Transition1.ShowSync(rightPanel);
                //this.Width = 1371;

            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOutG_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            //try
            //{
            //    frmGatectrl.Show();
            //    frmGatectrl.Close();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            frmLogin.txtUserID.Text = "";
            frmLogin.txtpassword.Text = "";
            frmLogin.txtUserID.Focus();
            frmLogin.Show(); 
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            Shop.FrmShopV2 frmShop = new Shop.FrmShopV2(this);
            frmShop.Text = "Shop";
            this.OpenChildForm(frmShop);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            //Shop.FrmChooseShop frmchooseshop = new Shop.FrmChooseShop(this);
            //frmchooseshop.Text = "Choose Shop";
            //this.OpenChildForm(frmchooseshop);
            controllerShop.getShop(ClsStaticVariable.controllerUser.objUser.UserID);
            Transaction.FrmOrder frmOrder = new Transaction.FrmOrder(this, controllerShop.objShop);
            frmOrder.Text = "Order";
            this.OpenChildForm(frmOrder);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Transaction.FrmTransactionHistory frmHistory = new Transaction.FrmTransactionHistory(this);
            frmHistory.Text = "Transaction History";
            this.OpenChildForm(frmHistory);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                //ResetHeader();
                //open only a single form
                lblTitleChildForm.Text = "Home";
                currentChildForm.Close();
            }
        }

        public void ResetHeader()
        {
            lblShopID.Visible = false;
            lblShopName.Visible = false;
            lblMainProduct.Visible = false;
            lblAddress.Visible = false;
        }

        private void btnCards_Click(object sender, EventArgs e)
        {
            //ResetHeader();
            Card.FrmCards frmCard = new Card.FrmCards(this);
            frmCard.Text = "Card";
            this.OpenChildForm(frmCard);
        }

        private void btnadminManagement_Click(object sender, EventArgs e)
        {
            Admin.FrmAdminForm frmAdmManagement = new Admin.FrmAdminForm(this);
            frmAdmManagement.Text = "Admin Menu";
            this.OpenChildForm(frmAdmManagement);
            btngear_Click(null, null);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports.FrmReports frmReport = new Reports.FrmReports(this);
            frmReport.Text = "Reports";
            frmReport.Tag = ClsStaticVariable.controllerUser.objUser.TipeUser;
            this.OpenChildForm(frmReport);
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            Shop.FrmCashier frmCashier = new Shop.FrmCashier(this);
            frmCashier.Text = "Supervisor";
            this.OpenChildForm(frmCashier);
        }

        private void btnChangePasswordG_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword();
            FormBlank frmBlank = new FormBlank();
            frmBlank.Show();
            frmChangePassword.ShowDialog();
            frmBlank.Close();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            if(ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                Admin.FrmUserManagement frmUserManagement = new Admin.FrmUserManagement(this);
                frmUserManagement.Text = "User Management";
                this.OpenChildForm(frmUserManagement);
            }
            else
            {
                ClsFungsi.Pesan("Maaf Anda Bukan Admin ");
            }
        }

        private void btnCardManagement_Click(object sender, EventArgs e)
        {
            Admin.FrmCardManagement frmCardManagement = new Admin.FrmCardManagement(this);
            frmCardManagement.Text = "Card Management";
            this.OpenChildForm(frmCardManagement);
        }

        private void btnBackUPDB_Click(object sender, EventArgs e)
        {
            FrmBackUPDB frmBackUp = new FrmBackUPDB();
            frmBackUp.ShowDialog();
        }

        private void btnOrderTiket_Click(object sender, EventArgs e)
        {
            Transaction.FrmOrderTiket frmOrderTiket = new Transaction.FrmOrderTiket(this);
            frmOrderTiket.Text = "Order Tiket";
            this.OpenChildForm(frmOrderTiket);
        }

        private void btnGate_Click(object sender, EventArgs e)
        {
            var frmGateCtrl = new FrmGateControl();
            frmGateCtrl.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Transaction.FrmMainOrder frmMainOrder = new Transaction.FrmMainOrder(this);
            frmMainOrder.Text = "Main Order";
            //frmMainOrder.Show();
            this.OpenChildForm(frmMainOrder);
        }

        // btn Branch 
        private void button1_Click(object sender, EventArgs e)
        {
            Branch.FrmCabang frmCabang = new Branch.FrmCabang(this);
            frmCabang.Text = "Branch / Cabang";
            //frmMainOrder.Show();
            this.OpenChildForm(frmCabang);
        }
    }
}
