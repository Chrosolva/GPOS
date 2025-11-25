namespace MilenialPark.Views.Shop
{
    partial class FrmShopV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShopV2));
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.FLShopList = new System.Windows.Forms.FlowLayoutPanel();
            this.panellabel1 = new System.Windows.Forms.Panel();
            this.lblShopList = new System.Windows.Forms.Label();
            this.panelbutton = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvShopItem = new System.Windows.Forms.DataGridView();
            this.rightbottompanel = new System.Windows.Forms.Panel();
            this.pbpreview = new System.Windows.Forms.PictureBox();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblrowcount = new System.Windows.Forms.Label();
            this.lblShopID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateShopItem = new System.Windows.Forms.Button();
            this.btnEditShopItem = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.panellabel1.SuspendLayout();
            this.panelbutton.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopItem)).BeginInit();
            this.rightbottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpreview)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHeader
            // 
            this.grpHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpHeader.Controls.Add(this.FLShopList);
            this.grpHeader.Controls.Add(this.panellabel1);
            this.grpHeader.Controls.Add(this.panelbutton);
            this.grpHeader.Location = new System.Drawing.Point(3, 3);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(495, 656);
            this.grpHeader.TabIndex = 0;
            this.grpHeader.TabStop = false;
            // 
            // FLShopList
            // 
            this.FLShopList.AutoScroll = true;
            this.FLShopList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLShopList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLShopList.Location = new System.Drawing.Point(3, 165);
            this.FLShopList.Name = "FLShopList";
            this.FLShopList.Size = new System.Drawing.Size(489, 488);
            this.FLShopList.TabIndex = 14;
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblShopList);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(3, 93);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(489, 72);
            this.panellabel1.TabIndex = 13;
            // 
            // lblShopList
            // 
            this.lblShopList.AutoSize = true;
            this.lblShopList.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopList.ForeColor = System.Drawing.Color.White;
            this.lblShopList.Location = new System.Drawing.Point(27, 26);
            this.lblShopList.Name = "lblShopList";
            this.lblShopList.Size = new System.Drawing.Size(89, 25);
            this.lblShopList.TabIndex = 24;
            this.lblShopList.Text = "Shop List";
            // 
            // panelbutton
            // 
            this.panelbutton.Controls.Add(this.btnCreate);
            this.panelbutton.Controls.Add(this.btnEdit);
            this.panelbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbutton.Location = new System.Drawing.Point(3, 16);
            this.panelbutton.Name = "panelbutton";
            this.panelbutton.Size = new System.Drawing.Size(489, 77);
            this.panelbutton.TabIndex = 12;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCreate.Location = new System.Drawing.Point(11, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Padding = new System.Windows.Forms.Padding(7);
            this.btnCreate.Size = new System.Drawing.Size(113, 54);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEdit.Location = new System.Drawing.Point(142, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(7);
            this.btnEdit.Size = new System.Drawing.Size(113, 54);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // grpDetail
            // 
            this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetail.Controls.Add(this.dgvShopItem);
            this.grpDetail.Controls.Add(this.rightbottompanel);
            this.grpDetail.Controls.Add(this.panel2);
            this.grpDetail.Controls.Add(this.panel1);
            this.grpDetail.Location = new System.Drawing.Point(507, 3);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(5);
            this.grpDetail.Size = new System.Drawing.Size(785, 656);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            // 
            // dgvShopItem
            // 
            this.dgvShopItem.AllowUserToAddRows = false;
            this.dgvShopItem.AllowUserToDeleteRows = false;
            this.dgvShopItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShopItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShopItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopItem.Location = new System.Drawing.Point(5, 171);
            this.dgvShopItem.Name = "dgvShopItem";
            this.dgvShopItem.ReadOnly = true;
            this.dgvShopItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopItem.Size = new System.Drawing.Size(775, 297);
            this.dgvShopItem.TabIndex = 16;
            // 
            // rightbottompanel
            // 
            this.rightbottompanel.Controls.Add(this.pbpreview);
            this.rightbottompanel.Controls.Add(this.lblItemPrice);
            this.rightbottompanel.Controls.Add(this.lblItemDesc);
            this.rightbottompanel.Controls.Add(this.lblItemName);
            this.rightbottompanel.Controls.Add(this.lblItemID);
            this.rightbottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rightbottompanel.Location = new System.Drawing.Point(5, 468);
            this.rightbottompanel.Name = "rightbottompanel";
            this.rightbottompanel.Size = new System.Drawing.Size(775, 183);
            this.rightbottompanel.TabIndex = 15;
            // 
            // pbpreview
            // 
            this.pbpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbpreview.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbpreview.ErrorImage")));
            this.pbpreview.Location = new System.Drawing.Point(608, 18);
            this.pbpreview.Name = "pbpreview";
            this.pbpreview.Size = new System.Drawing.Size(163, 142);
            this.pbpreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbpreview.TabIndex = 36;
            this.pbpreview.TabStop = false;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.Black;
            this.lblItemPrice.Location = new System.Drawing.Point(6, 136);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(47, 30);
            this.lblItemPrice.TabIndex = 29;
            this.lblItemPrice.Text = "Rp.";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.ForeColor = System.Drawing.Color.Black;
            this.lblItemDesc.Location = new System.Drawing.Point(6, 95);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(20, 25);
            this.lblItemDesc.TabIndex = 28;
            this.lblItemDesc.Text = "-";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(6, 59);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(20, 25);
            this.lblItemName.TabIndex = 27;
            this.lblItemName.Text = "-";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.ForeColor = System.Drawing.Color.Black;
            this.lblItemID.Location = new System.Drawing.Point(6, 18);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(20, 25);
            this.lblItemID.TabIndex = 26;
            this.lblItemID.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panel2.Controls.Add(this.lblrowcount);
            this.panel2.Controls.Add(this.lblShopID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 72);
            this.panel2.TabIndex = 14;
            // 
            // lblrowcount
            // 
            this.lblrowcount.AutoSize = true;
            this.lblrowcount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrowcount.ForeColor = System.Drawing.Color.White;
            this.lblrowcount.Location = new System.Drawing.Point(497, 26);
            this.lblrowcount.Name = "lblrowcount";
            this.lblrowcount.Size = new System.Drawing.Size(115, 25);
            this.lblrowcount.TabIndex = 26;
            this.lblrowcount.Text = "Row Count :";
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopID.ForeColor = System.Drawing.Color.White;
            this.lblShopID.Location = new System.Drawing.Point(238, 26);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(20, 25);
            this.lblShopID.TabIndex = 25;
            this.lblShopID.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Shop List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCreateShopItem);
            this.panel1.Controls.Add(this.btnEditShopItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 77);
            this.panel1.TabIndex = 13;
            // 
            // btnCreateShopItem
            // 
            this.btnCreateShopItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnCreateShopItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreateShopItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShopItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateShopItem.ForeColor = System.Drawing.Color.White;
            this.btnCreateShopItem.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateShopItem.Image")));
            this.btnCreateShopItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCreateShopItem.Location = new System.Drawing.Point(11, 12);
            this.btnCreateShopItem.Name = "btnCreateShopItem";
            this.btnCreateShopItem.Padding = new System.Windows.Forms.Padding(7);
            this.btnCreateShopItem.Size = new System.Drawing.Size(113, 54);
            this.btnCreateShopItem.TabIndex = 10;
            this.btnCreateShopItem.Text = "Create";
            this.btnCreateShopItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateShopItem.UseVisualStyleBackColor = false;
            this.btnCreateShopItem.Click += new System.EventHandler(this.btnCreateShopItem_Click);
            // 
            // btnEditShopItem
            // 
            this.btnEditShopItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnEditShopItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditShopItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditShopItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditShopItem.ForeColor = System.Drawing.Color.White;
            this.btnEditShopItem.Image = ((System.Drawing.Image)(resources.GetObject("btnEditShopItem.Image")));
            this.btnEditShopItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEditShopItem.Location = new System.Drawing.Point(142, 12);
            this.btnEditShopItem.Name = "btnEditShopItem";
            this.btnEditShopItem.Padding = new System.Windows.Forms.Padding(7);
            this.btnEditShopItem.Size = new System.Drawing.Size(113, 54);
            this.btnEditShopItem.TabIndex = 11;
            this.btnEditShopItem.Text = "Edit";
            this.btnEditShopItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditShopItem.UseVisualStyleBackColor = false;
            this.btnEditShopItem.Click += new System.EventHandler(this.btnEditShopItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(649, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(7);
            this.btnDelete.Size = new System.Drawing.Size(113, 54);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmShopV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 665);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpHeader);
            this.Name = "FrmShopV2";
            this.Text = "FrmShopV2";
            this.Load += new System.EventHandler(this.FrmShopV2_Load);
            this.grpHeader.ResumeLayout(false);
            this.panellabel1.ResumeLayout(false);
            this.panellabel1.PerformLayout();
            this.panelbutton.ResumeLayout(false);
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopItem)).EndInit();
            this.rightbottompanel.ResumeLayout(false);
            this.rightbottompanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpreview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panellabel1;
        private System.Windows.Forms.Panel panelbutton;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateShopItem;
        private System.Windows.Forms.Button btnEditShopItem;
        private System.Windows.Forms.FlowLayoutPanel FLShopList;
        public System.Windows.Forms.Label lblShopList;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblrowcount;
        public System.Windows.Forms.Label lblShopID;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShopItem;
        private System.Windows.Forms.Panel rightbottompanel;
        public System.Windows.Forms.Label lblItemPrice;
        public System.Windows.Forms.Label lblItemDesc;
        public System.Windows.Forms.Label lblItemName;
        public System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.PictureBox pbpreview;
        private System.Windows.Forms.Button btnDelete;
    }
}