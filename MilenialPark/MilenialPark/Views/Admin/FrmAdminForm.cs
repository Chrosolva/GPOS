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
using MilenialPark.Models;
using MilenialPark.UserControls;
using MySql.Data.MySqlClient;

namespace MilenialPark.Views.Admin
{
    public partial class FrmAdminForm : Form
    {
        #region properties

        public Mainform parentfrm;
        public ImageList imgList = new ImageList();
        public Image img;
        public ControllerShop controllerShop = new ControllerShop();
        public List<UCShopItem> listShopItem = new List<UCShopItem>();
        public ControllerTransaction controllerTrans = new ControllerTransaction();
        public BindingSource bind = new BindingSource();
        private DBConnect db;

        #endregion

        public FrmAdminForm()
        {
            InitializeComponent();
            db = ClsStaticVariable.objConnection;
        }

        public FrmAdminForm(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
        }

        private void FrmAdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Open the MySQL connection using the DBConnect helper
                db.OpenMySqlConnection();

                // Query the users table
                using (var cmd = new MySqlCommand(
                    "SELECT id, username, full_name, email, is_active, created_at FROM users",
                    db.conn))
                {
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgvTest.DataSource = table;
                }

                db.CloseMySqlConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users: " + ex.Message);
            }
        }
    }
}
