namespace MilenialPark.Views.Card
{
    partial class FrmCardList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.label13 = new System.Windows.Forms.Label();
            this.bottompanel = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.contentpanel = new System.Windows.Forms.Panel();
            this.dgvSelectCard = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.bottompanel.SuspendLayout();
            this.contentpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectCard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbxCategory);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 51);
            this.panel1.TabIndex = 3;
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Items.AddRange(new object[] {
            "CustomerName",
            "NoIdentitas"});
            this.cbxCategory.Location = new System.Drawing.Point(630, 10);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(121, 29);
            this.cbxCategory.TabIndex = 37;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(197, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(427, 29);
            this.txtSearch.TabIndex = 38;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnExit.IconColor = System.Drawing.Color.Gray;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 25;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(1024, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 32);
            this.btnExit.TabIndex = 36;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "Search Card";
            // 
            // bottompanel
            // 
            this.bottompanel.Controls.Add(this.btnSelect);
            this.bottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottompanel.Location = new System.Drawing.Point(0, 530);
            this.bottompanel.Name = "bottompanel";
            this.bottompanel.Size = new System.Drawing.Size(1066, 77);
            this.bottompanel.TabIndex = 4;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSelect.Location = new System.Drawing.Point(447, 11);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(7);
            this.btnSelect.Size = new System.Drawing.Size(113, 54);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnEditShopItem_Click);
            // 
            // contentpanel
            // 
            this.contentpanel.Controls.Add(this.dgvSelectCard);
            this.contentpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentpanel.Location = new System.Drawing.Point(0, 51);
            this.contentpanel.Name = "contentpanel";
            this.contentpanel.Padding = new System.Windows.Forms.Padding(6);
            this.contentpanel.Size = new System.Drawing.Size(1066, 479);
            this.contentpanel.TabIndex = 5;
            // 
            // dgvSelectCard
            // 
            this.dgvSelectCard.AllowUserToAddRows = false;
            this.dgvSelectCard.AllowUserToDeleteRows = false;
            this.dgvSelectCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSelectCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectCard.Location = new System.Drawing.Point(6, 6);
            this.dgvSelectCard.Name = "dgvSelectCard";
            this.dgvSelectCard.ReadOnly = true;
            this.dgvSelectCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectCard.Size = new System.Drawing.Size(1054, 467);
            this.dgvSelectCard.TabIndex = 18;
            this.dgvSelectCard.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectCard_CellContentDoubleClick);
            // 
            // FrmCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 607);
            this.Controls.Add(this.contentpanel);
            this.Controls.Add(this.bottompanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCardList";
            this.Text = "FrmCardList";
            this.Load += new System.EventHandler(this.FrmCardList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bottompanel.ResumeLayout(false);
            this.contentpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnExit;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cbxCategory;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel bottompanel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel contentpanel;
        private System.Windows.Forms.DataGridView dgvSelectCard;
    }
}