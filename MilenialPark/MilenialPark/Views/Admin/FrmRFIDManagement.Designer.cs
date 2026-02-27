namespace MilenialPark.Views.Admin
{
    partial class FrmRFIDManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRFIDManagement));
            this.leftpanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.RFIDStatus = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRFIDType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRFIDName = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.panellabel1 = new System.Windows.Forms.Panel();
            this.lblNewOrder = new System.Windows.Forms.Label();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.rightbottompanel = new System.Windows.Forms.Panel();
            this.dgvRFIDList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.leftpanel.SuspendLayout();
            this.panellabel1.SuspendLayout();
            this.rightpanel.SuspendLayout();
            this.rightbottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRFIDList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftpanel
            // 
            this.leftpanel.Controls.Add(this.btnSave);
            this.leftpanel.Controls.Add(this.RFIDStatus);
            this.leftpanel.Controls.Add(this.label3);
            this.leftpanel.Controls.Add(this.txtRFIDType);
            this.leftpanel.Controls.Add(this.label2);
            this.leftpanel.Controls.Add(this.txtRFIDName);
            this.leftpanel.Controls.Add(this.btnReset);
            this.leftpanel.Controls.Add(this.lblCardID2);
            this.leftpanel.Controls.Add(this.txtRFID);
            this.leftpanel.Controls.Add(this.panellabel1);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftpanel.Location = new System.Drawing.Point(0, 0);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(467, 678);
            this.leftpanel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(111, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7);
            this.btnSave.Size = new System.Drawing.Size(216, 54);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // RFIDStatus
            // 
            this.RFIDStatus.AutoSize = true;
            this.RFIDStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFIDStatus.Location = new System.Drawing.Point(66, 335);
            this.RFIDStatus.Name = "RFIDStatus";
            this.RFIDStatus.Size = new System.Drawing.Size(85, 29);
            this.RFIDStatus.TabIndex = 50;
            this.RFIDStatus.Text = "Active";
            this.RFIDStatus.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 49;
            this.label3.Text = "RFID Type";
            // 
            // txtRFIDType
            // 
            this.txtRFIDType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRFIDType.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFIDType.Location = new System.Drawing.Point(66, 289);
            this.txtRFIDType.Name = "txtRFIDType";
            this.txtRFIDType.Size = new System.Drawing.Size(327, 29);
            this.txtRFIDType.TabIndex = 48;
            this.txtRFIDType.Text = "GELANG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 47;
            this.label2.Text = "RFID Name";
            // 
            // txtRFIDName
            // 
            this.txtRFIDName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRFIDName.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFIDName.Location = new System.Drawing.Point(66, 216);
            this.txtRFIDName.Name = "txtRFIDName";
            this.txtRFIDName.Size = new System.Drawing.Size(327, 29);
            this.txtRFIDName.TabIndex = 46;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnReset.Location = new System.Drawing.Point(358, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(7);
            this.btnReset.Size = new System.Drawing.Size(103, 54);
            this.btnReset.TabIndex = 45;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(62, 124);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(44, 21);
            this.lblCardID2.TabIndex = 44;
            this.lblCardID2.Text = "RFID";
            // 
            // txtRFID
            // 
            this.txtRFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRFID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFID.Location = new System.Drawing.Point(66, 148);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(327, 29);
            this.txtRFID.TabIndex = 43;
            this.txtRFID.Enter += new System.EventHandler(this.txtRFID_Enter);
            this.txtRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRFID_KeyDown);
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblNewOrder);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(0, 0);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(467, 51);
            this.panellabel1.TabIndex = 15;
            // 
            // lblNewOrder
            // 
            this.lblNewOrder.AutoSize = true;
            this.lblNewOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrder.ForeColor = System.Drawing.Color.White;
            this.lblNewOrder.Location = new System.Drawing.Point(12, 15);
            this.lblNewOrder.Name = "lblNewOrder";
            this.lblNewOrder.Size = new System.Drawing.Size(174, 25);
            this.lblNewOrder.TabIndex = 24;
            this.lblNewOrder.Text = "RFID Management";
            // 
            // rightpanel
            // 
            this.rightpanel.Controls.Add(this.rightbottompanel);
            this.rightpanel.Controls.Add(this.panel1);
            this.rightpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightpanel.Location = new System.Drawing.Point(467, 0);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(531, 678);
            this.rightpanel.TabIndex = 2;
            // 
            // rightbottompanel
            // 
            this.rightbottompanel.Controls.Add(this.dgvRFIDList);
            this.rightbottompanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightbottompanel.Location = new System.Drawing.Point(0, 111);
            this.rightbottompanel.Name = "rightbottompanel";
            this.rightbottompanel.Padding = new System.Windows.Forms.Padding(6);
            this.rightbottompanel.Size = new System.Drawing.Size(531, 567);
            this.rightbottompanel.TabIndex = 5;
            // 
            // dgvRFIDList
            // 
            this.dgvRFIDList.AllowUserToAddRows = false;
            this.dgvRFIDList.AllowUserToDeleteRows = false;
            this.dgvRFIDList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRFIDList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRFIDList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRFIDList.Location = new System.Drawing.Point(6, 6);
            this.dgvRFIDList.Name = "dgvRFIDList";
            this.dgvRFIDList.ReadOnly = true;
            this.dgvRFIDList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRFIDList.Size = new System.Drawing.Size(519, 555);
            this.dgvRFIDList.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblRowCount);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 111);
            this.panel1.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(138, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(381, 29);
            this.txtSearch.TabIndex = 56;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(6, 57);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(115, 25);
            this.lblRowCount.TabIndex = 37;
            this.lblRowCount.Text = "Row Count :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "RFID List";
            // 
            // FrmRFIDManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 678);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.leftpanel);
            this.Name = "FrmRFIDManagement";
            this.Text = "FrmRFIDManagement";
            this.Load += new System.EventHandler(this.FrmRFIDManagement_Load);
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            this.panellabel1.ResumeLayout(false);
            this.panellabel1.PerformLayout();
            this.rightpanel.ResumeLayout(false);
            this.rightbottompanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRFIDList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox RFIDStatus;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtRFIDType;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRFIDName;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.Panel panellabel1;
        public System.Windows.Forms.Label lblNewOrder;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.Panel rightbottompanel;
        private System.Windows.Forms.DataGridView dgvRFIDList;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Label lblRowCount;
        public System.Windows.Forms.Label label13;
    }
}