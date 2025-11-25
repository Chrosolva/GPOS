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
using MilenialPark.Models;
using MilenialPark.Master;

namespace MilenialPark.Views.Branch
{
    public partial class FrmCabang : Form
    {
        #region properties

        BindingSource bind = new BindingSource();
        public Mainform parentfrm;
        public DataTable dt;
        public ClsCabang objCabang = new ClsCabang();

        #endregion

        public FrmCabang()
        {
            InitializeComponent();
        }

        public FrmCabang(Mainform parent)
        {
            InitializeComponent();
            parentfrm = parent;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBranchID.Enabled = true;
            txtBranchID.Text = "";
            txtBranchName.Text = "";
            txtAddress.Text = "";
            cbxUser.SelectedIndex = -1;
        }
        
        public void setDgvBranch()
        {
            bind.DataSource = ClsStaticVariable.controllerUser.getAllCabang();
            dgvBranchList.DataSource = bind;
        }

        public void setCbxAdmin()
        {
            dt = ClsStaticVariable.controllerUser.getListUserAdmin();
            if (dt.Rows.Count != 0)
            {
                cbxUser.Items.Clear();
                cbxUser.DisplayMember = "Text";
                cbxUser.ValueMember = "Value";

                foreach (DataRow row in dt.Rows)
                {
                    cbxUser.Items.Add(new { Text = (row["UserID"].ToString() + "-" + row["Username"].ToString()), Value = row["UserID"].ToString()});
                }
            }
        }

        private void FrmCabang_Load(object sender, EventArgs e)
        {
            setDgvBranch();
            setCbxAdmin();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBranchID.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Branch ID kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtBranchName.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Branch Name kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (txtAddress.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Address kosong , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else if (cbxUser.Text.Trim() == "")
            {
                ClsFungsi.Pesan("Admin Penanggung Jawab kosong , silahkan dipilih terlebih dahulu !!!", "ERROR");
            }
            else
            {
                // Create or Edit Cabang 
                // check cabang 
                if(!ClsStaticVariable.controllerUser.checkcabang(txtBranchID.Text))
                {
                    // add cabang 
                    objCabang = new ClsCabang(txtBranchID.Text, txtBranchName.Text, txtAddress.Text, Convert.ToString((cbxUser.SelectedItem as dynamic).Value));
                    try
                    {
                        ClsStaticVariable.controllerUser.InsertCabang(objCabang);
                        ClsFungsi.Pesan("Cabang Berhasil ditambahkan ! ", "INFO");
                        setDgvBranch();
                    }
                    catch(Exception ex)
                    {
                        ClsFungsi.Pesan("Terjadi Error Pada penambahan Cabang baru , pesan error = " + ex.Message, "ERROR");
                    }
                }
                else
                {
                    // edit cabang 
                    objCabang = new ClsCabang(txtBranchID.Text, txtBranchName.Text, txtAddress.Text, Convert.ToString((cbxUser.SelectedItem as dynamic).Value));
                    try
                    {
                        ClsStaticVariable.controllerUser.UpdateCabang(objCabang);
                        ClsFungsi.Pesan("Cabang Berhasil diUbah ! ", "INFO");
                        setDgvBranch();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Terjadi Error Pada penambahan Cabang baru , pesan error = " + ex.Message, "ERROR");
                    }
                }

            }
        }

        private void dgvBranchList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBranchID.Text = dgvBranchList.CurrentRow.Cells["KodeCabang"].Value.ToString();
            txtBranchName.Text = dgvBranchList.CurrentRow.Cells["NamaCabang"].Value.ToString();
            txtAddress.Text = dgvBranchList.CurrentRow.Cells["Alamat"].Value.ToString();
            cbxUser.Text = dgvBranchList.CurrentRow.Cells["AdminID"].Value.ToString();
            txtBranchID.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ClsStaticVariable.controllerUser.objUser.TipeUser == "Admin")
            {
                if (txtBranchID.Text.Trim() == "")
                {
                    ClsFungsi.Pesan("Kode Cabang kosong , silahkan dipilih terlebih dahulu !!!", "ERROR");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data Cabang  " + txtBranchID.Text + " ? ", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // delete cabang 
                        try
                        {
                            ClsStaticVariable.controllerUser.DeleteCabang(txtBranchID.Text);
                            ClsFungsi.Pesan("Data Cabang Berhasil diHapus !!!", "INFO");
                            setDgvBranch();
                        }
                        catch (Exception ex)
                        {
                            ClsFungsi.Pesan("Data Cabang gagal diHapus , pesan error = " + ex.Message, "ERROR");
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
    }
}
