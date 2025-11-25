using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace MilenialPark.Views
{
    public partial class FrmBackUPDB : Form
    {
        private static Server srvr;
        ServerConnection conn;

        public FrmBackUPDB()
        {
            InitializeComponent();
        }

        private void FrmBackUPDB_Load(object sender, EventArgs e)
        {
            this.cmbDatabaseItems.SelectedIndex = 0;
            txtPath.Text = "C:\\WHNPOS\\BackUp";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = false;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                txtPath.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }

        public void btnBackUp_Click(object sender, EventArgs e)
        {
            Backup bkp = new Backup();
            conn = new ServerConnection();
            srvr = new Server(conn);
            try
            {
                string databaseName = cmbDatabaseItems.Text;
                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                string path;
                if (!(txtPath.Text.EndsWith("\\")))
                {
                    path = txtPath.Text + "\\";
                }
                else
                {
                    path = txtPath.Text;
                }
                BackupDeviceItem bkpDevice = new BackupDeviceItem(path + databaseName + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Year.ToString() + DateTime.Now.Hour+ " " + DateTime.Now.Minute + DateTime.Now.Second+ ".bak", DeviceType.File);

                bkp.Devices.Add(bkpDevice);
                bkp.Incremental = false;
                bkp.SqlBackup(srvr);
                MessageBox.Show("Database Backup created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
