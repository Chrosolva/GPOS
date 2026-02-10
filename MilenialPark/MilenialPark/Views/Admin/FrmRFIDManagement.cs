using System;
using System.Data;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Models;
using MilenialPark.Master;

namespace MilenialPark.Views.Admin
{
    /// <summary>
    /// Code-behind for the RFID Management form. This partial class
    /// implements simple CRUD (Create, Read, Update, Delete) operations
    /// against the RFIDTags table. It relies on a controller (ControllerRFID)
    /// to perform database operations using the existing MilenialPark
    /// infrastructure. The designer portion of this form is defined in
    /// FrmRFIDManagement.Designer.cs.
    /// </summary>
    public partial class FrmRFIDManagement : Form
    {
        /// <summary>
        /// Binding source used to filter and display RFID rows in the grid.
        /// </summary>
        private BindingSource bind = new BindingSource();

        /// <summary>
        /// Controller responsible for all RFID data access operations.
        /// </summary>
        private ControllerRFID controllerRFID = new ControllerRFID();

        public FrmRFIDManagement()
        {
            InitializeComponent();
            // Attach event handlers that are not wired via the designer.
            btnSave.Click += btnSave_Click;
            btnReset.Click += btnReset_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvRFIDList.CellClick += dgvRFIDList_CellClick;
        }

        /// <summary>
        /// Form load event: apply styling, set defaults, and populate the list.
        /// </summary>
        private void FrmRFIDManagement_Load(object sender, EventArgs e)
        {
            // Apply existing POS styling helpers from your project.
            DataGridViewHelper.ApplyPOSStyle(dgvRFIDList, false, true);
            DataGridViewHelper.SizeCompact(dgvRFIDList, 100, 420);

            // Default initial field values
            RFIDStatus.Checked = true;
            txtRFIDType.Text = "GELANG";

            LoadRFIDList();
        }

        /// <summary>
        /// Retrieves the entire list of RFID tags from the database and binds
        /// it to the DataGridView. Also updates the row count label.
        /// </summary>
        private void LoadRFIDList()
        {
            try
            {
                DataTable dt = controllerRFID.GetRFIDList();
                bind.DataSource = dt;
                dgvRFIDList.DataSource = bind;
                lblRowCount.Text = "Row Count : " + dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                ClsFungsi.Pesan("Error loading RFID list: " + ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// Resets all input fields to their default values and re‑enables
        /// editable fields. Also resets the Save button text.
        /// </summary>
        private void ClearForm()
        {
            txtRFID.Text = string.Empty;
            txtRFIDName.Text = string.Empty;
            txtRFIDType.Text = "GELANG";
            RFIDStatus.Checked = true;
            txtRFID.Enabled = true;
            txtRFIDType.Enabled = true;
            btnSave.Text = "Save";
        }

        /// <summary>
        /// Event handler for the Reset button. Clears the form.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Handles saving or updating an RFID tag when the Save button is clicked.
        /// Validates input, performs duplicate checks, and calls the
        /// controller methods accordingly.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tagID = txtRFID.Text.Trim();
            string name = txtRFIDName.Text.Trim();
            string typeRFID = txtRFIDType.Text.Trim();
            bool status = RFIDStatus.Checked;

            // Basic validation
            if (string.IsNullOrEmpty(tagID))
            {
                ClsFungsi.Pesan("RFID cannot be empty.", "ERROR");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                ClsFungsi.Pesan("RFID Name cannot be empty.", "ERROR");
                return;
            }
            if (string.IsNullOrEmpty(typeRFID))
            {
                ClsFungsi.Pesan("RFID Type cannot be empty.", "ERROR");
                return;
            }

            // Construct the RFID model
            ClsRFID rfid = new ClsRFID(tagID, name, typeRFID, status);

            try
            {
                // Check if the record already exists (natural key = TagID + TypeRFID)
                if (!controllerRFID.CheckRFID(tagID, typeRFID))
                {
                    // Insert new record
                    controllerRFID.InsertRFID(rfid);
                    ClsFungsi.Pesan("RFID tag added successfully.", "INFO");
                }
                else
                {
                    // Update existing record
                    controllerRFID.UpdateRFID(rfid);
                    ClsFungsi.Pesan("RFID tag updated successfully.", "INFO");
                }

                // Refresh list and clear form
                LoadRFIDList();
                ClearForm();
            }
            catch (Exception ex)
            {
                ClsFungsi.Pesan("Error saving RFID: " + ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// Populates the input fields with the selected row values when a grid
        /// row is clicked. Puts the form into update mode (changes the save
        /// button text) and disables editing of TagID and TypeRFID.
        /// </summary>
        private void dgvRFIDList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRFIDList.Rows.Count > 0)
            {
                DataGridViewRow row = dgvRFIDList.Rows[e.RowIndex];
                txtRFID.Text = row.Cells["TagID"].Value.ToString();
                txtRFIDName.Text = row.Cells["RFIDName"].Value.ToString();
                txtRFIDType.Text = row.Cells["TypeRFID"].Value.ToString();
                RFIDStatus.Checked = Convert.ToBoolean(row.Cells["Status"].Value);
                txtRFID.Enabled = false;
                txtRFIDType.Enabled = false;
                btnSave.Text = "Update";
            }
        }

        /// <summary>
        /// Filters the binding source when the search text changes. Looks up
        /// TagID, RFIDName or TypeRFID for partial matches and updates the row
        /// count accordingly.
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim().Replace("'", "''");
            if (bind.DataSource != null)
            {
                DataView dv = ((DataTable)bind.DataSource).DefaultView;
                dv.RowFilter = $"TagID LIKE '%{filter}%' OR RFIDName LIKE '%{filter}%' OR TypeRFID LIKE '%{filter}%'";
                lblRowCount.Text = "Row Count : " + dv.Count.ToString();
            }
        }

        /// <summary>
        /// Overrides the form's key processing to enable deletion of a selected
        /// RFID record using the Delete key. Prompts for confirmation and
        /// delegates deletion to the controller.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && dgvRFIDList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRFIDList.SelectedRows[0];
                string tagID = row.Cells["TagID"].Value.ToString();
                string typeRFID = row.Cells["TypeRFID"].Value.ToString();
                DialogResult result = MessageBox.Show($"Apakah Anda yakin ingin menghapus data RFID {tagID} - {typeRFID} ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        controllerRFID.DeleteRFID(tagID, typeRFID);
                        ClsFungsi.Pesan("Data RFID berhasil dihapus.", "INFO");
                        LoadRFIDList();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        ClsFungsi.Pesan("Data RFID gagal dihapus, pesan error = " + ex.Message, "ERROR");
                    }
                }
                // Indicate that we handled the key
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}