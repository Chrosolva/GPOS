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
            db = ClsStaticVariable.objConnection;  // assign db here
        }

        public FrmAdminForm(Mainform main)
        {
            InitializeComponent();
            parentfrm = main;
            db = ClsStaticVariable.objConnection;  // assign db here
        }

        private void FrmAdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Defensive check: ensure db is not null and has a connection string
                if (db == null || string.IsNullOrEmpty(db.connectionstring2))
                {
                    MessageBox.Show("MySQL connection has not been initialised.");
                    return;
                }

                db.OpenMySqlConnection();
                using (var cmd = new MySqlCommand(
                    "SELECT " + 
   " i.id          AS item_id, " + 
   " i.code, " + 
   " i.name, " + 
   " c.id      AS category_id, " + 
   " c.name        AS category, " + 
   " i.price1      AS price " +     
   " FROM tbl_items i " + 
   " JOIN tbl_categories c ON c.id = i.category_id " + 
   " WHERE i.active = 1 " + 
   " AND i.price1 > 0 " + 
   " AND i.type = 0 " + 
   " AND(c.id = 5 OR c.`id` = 9) " + 
   " ORDER BY c.priority, c.name, i.name; ",

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
