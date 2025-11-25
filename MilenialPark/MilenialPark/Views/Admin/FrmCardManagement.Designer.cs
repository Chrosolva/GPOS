namespace MilenialPark.Views.Admin
{
    partial class FrmCardManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardManagement));
            this.leftpanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.NUDQty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdentityNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.panellabel1 = new System.Windows.Forms.Panel();
            this.lblNewOrder = new System.Windows.Forms.Label();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.rightbottompanel = new System.Windows.Forms.Panel();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCardChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.leftpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).BeginInit();
            this.panellabel1.SuspendLayout();
            this.rightpanel.SuspendLayout();
            this.rightbottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftpanel
            // 
            this.leftpanel.Controls.Add(this.btnCardChange);
            this.leftpanel.Controls.Add(this.label5);
            this.leftpanel.Controls.Add(this.btnDelete);
            this.leftpanel.Controls.Add(this.NUDQty);
            this.leftpanel.Controls.Add(this.label4);
            this.leftpanel.Controls.Add(this.btnSave);
            this.leftpanel.Controls.Add(this.chkActive);
            this.leftpanel.Controls.Add(this.label3);
            this.leftpanel.Controls.Add(this.txtIdentityNo);
            this.leftpanel.Controls.Add(this.label2);
            this.leftpanel.Controls.Add(this.txtCustomerName);
            this.leftpanel.Controls.Add(this.btnReset);
            this.leftpanel.Controls.Add(this.lblCardID2);
            this.leftpanel.Controls.Add(this.txtCardID);
            this.leftpanel.Controls.Add(this.panellabel1);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftpanel.Location = new System.Drawing.Point(0, 0);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(467, 732);
            this.leftpanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 655);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(452, 19);
            this.label5.TabIndex = 55;
            this.label5.Text = "NB: Tombol delete hanya berlaku ketika kartu belum memiliki transaksi";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NUDQty
            // 
            this.NUDQty.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDQty.Location = new System.Drawing.Point(66, 501);
            this.NUDQty.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NUDQty.Name = "NUDQty";
            this.NUDQty.Size = new System.Drawing.Size(327, 32);
            this.NUDQty.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 52;
            this.label4.Text = "Balance (Saldo)";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(66, 335);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(85, 29);
            this.chkActive.TabIndex = 50;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 21);
            this.label3.TabIndex = 49;
            this.label3.Text = "Identity No (KTP / SIM)";
            // 
            // txtIdentityNo
            // 
            this.txtIdentityNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentityNo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityNo.Location = new System.Drawing.Point(66, 289);
            this.txtIdentityNo.Name = "txtIdentityNo";
            this.txtIdentityNo.Size = new System.Drawing.Size(327, 29);
            this.txtIdentityNo.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 47;
            this.label2.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(66, 216);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(327, 29);
            this.txtCustomerName.TabIndex = 46;
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(62, 124);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(68, 21);
            this.lblCardID2.TabIndex = 44;
            this.lblCardID2.Text = "Card ID ";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(66, 148);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(327, 29);
            this.txtCardID.TabIndex = 43;
            this.txtCardID.TextChanged += new System.EventHandler(this.txtCardID_TextChanged);
            this.txtCardID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyUp);
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
            this.lblNewOrder.Size = new System.Drawing.Size(52, 25);
            this.lblNewOrder.TabIndex = 24;
            this.lblNewOrder.Text = "Card";
            // 
            // rightpanel
            // 
            this.rightpanel.Controls.Add(this.rightbottompanel);
            this.rightpanel.Controls.Add(this.panel1);
            this.rightpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightpanel.Location = new System.Drawing.Point(467, 0);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(616, 732);
            this.rightpanel.TabIndex = 1;
            // 
            // rightbottompanel
            // 
            this.rightbottompanel.Controls.Add(this.dgvCardList);
            this.rightbottompanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightbottompanel.Location = new System.Drawing.Point(0, 51);
            this.rightbottompanel.Name = "rightbottompanel";
            this.rightbottompanel.Padding = new System.Windows.Forms.Padding(6);
            this.rightbottompanel.Size = new System.Drawing.Size(616, 681);
            this.rightbottompanel.TabIndex = 5;
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardList.Location = new System.Drawing.Point(6, 6);
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.ReadOnly = true;
            this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardList.Size = new System.Drawing.Size(604, 669);
            this.dgvCardList.TabIndex = 18;
            this.dgvCardList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCardList_CellClick);
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
            this.panel1.Size = new System.Drawing.Size(616, 51);
            this.panel1.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(245, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(327, 29);
            this.txtSearch.TabIndex = 56;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(124, 15);
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
            this.label13.Size = new System.Drawing.Size(86, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "Card List";
            // 
            // btnCardChange
            // 
            this.btnCardChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCardChange.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardChange.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnCardChange.Image = ((System.Drawing.Image)(resources.GetObject("btnCardChange.Image")));
            this.btnCardChange.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCardChange.Location = new System.Drawing.Point(239, 587);
            this.btnCardChange.Name = "btnCardChange";
            this.btnCardChange.Padding = new System.Windows.Forms.Padding(7);
            this.btnCardChange.Size = new System.Drawing.Size(207, 54);
            this.btnCardChange.TabIndex = 56;
            this.btnCardChange.Text = "Card Change";
            this.btnCardChange.UseVisualStyleBackColor = true;
            this.btnCardChange.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(17, 587);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(7);
            this.btnDelete.Size = new System.Drawing.Size(113, 54);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmCardManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 732);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.leftpanel);
            this.Name = "FrmCardManagement";
            this.Text = "FrmCardManagement";
            this.Load += new System.EventHandler(this.FrmCardManagement_Load);
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).EndInit();
            this.panellabel1.ResumeLayout(false);
            this.panellabel1.PerformLayout();
            this.rightpanel.ResumeLayout(false);
            this.rightbottompanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblRowCount;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panellabel1;
        public System.Windows.Forms.Label lblNewOrder;
        private System.Windows.Forms.CheckBox chkActive;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtIdentityNo;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.TextBox txtCardID;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown NUDQty;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel rightbottompanel;
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCardChange;
    }
}