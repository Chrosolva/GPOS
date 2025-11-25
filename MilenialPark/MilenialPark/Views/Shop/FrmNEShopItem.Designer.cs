namespace MilenialPark.Views.Shop
{
    partial class FrmNEShopItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNEShopItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddorEdit = new System.Windows.Forms.Button();
            this.pbpreview = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtImageFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NUDprice = new System.Windows.Forms.NumericUpDown();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudtopup = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDprice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudtopup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 51);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnExit.IconColor = System.Drawing.Color.Gray;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 25;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(382, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 32);
            this.btnExit.TabIndex = 36;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(6, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(49, 25);
            this.lblFormTitle.TabIndex = 35;
            this.lblFormTitle.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.nudtopup);
            this.panel2.Controls.Add(this.btnAddorEdit);
            this.panel2.Controls.Add(this.pbpreview);
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.txtImageFilePath);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.NUDprice);
            this.panel2.Controls.Add(this.cbxCategory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtItemDesc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtItemName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblItemID);
            this.panel2.Controls.Add(this.lblCardID2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 607);
            this.panel2.TabIndex = 5;
            // 
            // btnAddorEdit
            // 
            this.btnAddorEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnAddorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddorEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddorEdit.ForeColor = System.Drawing.Color.White;
            this.btnAddorEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnAddorEdit.Image")));
            this.btnAddorEdit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAddorEdit.Location = new System.Drawing.Point(300, 547);
            this.btnAddorEdit.Name = "btnAddorEdit";
            this.btnAddorEdit.Padding = new System.Windows.Forms.Padding(7);
            this.btnAddorEdit.Size = new System.Drawing.Size(113, 54);
            this.btnAddorEdit.TabIndex = 60;
            this.btnAddorEdit.Text = "Create";
            this.btnAddorEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddorEdit.UseVisualStyleBackColor = false;
            this.btnAddorEdit.Click += new System.EventHandler(this.btnAddorEdit_Click);
            // 
            // pbpreview
            // 
            this.pbpreview.Location = new System.Drawing.Point(17, 440);
            this.pbpreview.Name = "pbpreview";
            this.pbpreview.Size = new System.Drawing.Size(175, 161);
            this.pbpreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpreview.TabIndex = 59;
            this.pbpreview.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.Gray;
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(368, 393);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Padding = new System.Windows.Forms.Padding(7);
            this.btnBrowse.Size = new System.Drawing.Size(44, 29);
            this.btnBrowse.TabIndex = 58;
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // txtImageFilePath
            // 
            this.txtImageFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageFilePath.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageFilePath.Location = new System.Drawing.Point(17, 394);
            this.txtImageFilePath.Name = "txtImageFilePath";
            this.txtImageFilePath.Size = new System.Drawing.Size(396, 29);
            this.txtImageFilePath.TabIndex = 57;
            this.txtImageFilePath.Text = "C:\\WHNPOSPict\\notfound.png";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 56;
            this.label5.Text = "Picture Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Price";
            // 
            // NUDprice
            // 
            this.NUDprice.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDprice.Location = new System.Drawing.Point(17, 275);
            this.NUDprice.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NUDprice.Name = "NUDprice";
            this.NUDprice.Size = new System.Drawing.Size(396, 32);
            this.NUDprice.TabIndex = 54;
            this.NUDprice.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // cbxCategory
            // 
            this.cbxCategory.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(16, 215);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(205, 29);
            this.cbxCategory.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 52;
            this.label3.Text = "Category";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDesc.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDesc.Location = new System.Drawing.Point(16, 158);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(396, 29);
            this.txtItemDesc.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Item Description";
            // 
            // txtItemName
            // 
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(16, 87);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(396, 29);
            this.txtItemName.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "Item Name";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.Location = new System.Drawing.Point(101, 25);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(16, 21);
            this.lblItemID.TabIndex = 47;
            this.lblItemID.Text = "-";
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(12, 25);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(60, 21);
            this.lblCardID2.TabIndex = 46;
            this.lblCardID2.Text = "Item ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 62;
            this.label6.Text = "TopUpAmount";
            // 
            // nudtopup
            // 
            this.nudtopup.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudtopup.Location = new System.Drawing.Point(17, 335);
            this.nudtopup.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudtopup.Name = "nudtopup";
            this.nudtopup.Size = new System.Drawing.Size(396, 32);
            this.nudtopup.TabIndex = 61;
            this.nudtopup.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // FrmNEShopItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(424, 658);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNEShopItem";
            this.Text = "FrmNEShopItem";
            this.Load += new System.EventHandler(this.FrmNEShopItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDprice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudtopup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnExit;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblItemID;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtItemDesc;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtItemName;
        public System.Windows.Forms.ComboBox cbxCategory;
        public System.Windows.Forms.TextBox txtImageFilePath;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUDprice;
        public System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbpreview;
        public System.Windows.Forms.Button btnAddorEdit;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudtopup;
    }
}