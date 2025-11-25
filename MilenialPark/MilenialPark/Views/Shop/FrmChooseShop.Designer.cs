namespace MilenialPark.Views.Shop
{
    partial class FrmChooseShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChooseShop));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvShopList = new System.Windows.Forms.DataGridView();
            this.btnAddorEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 51);
            this.panel1.TabIndex = 5;
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
            this.panel2.Controls.Add(this.btnAddorEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 79);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvShopList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 352);
            this.panel3.TabIndex = 7;
            // 
            // dgvShopList
            // 
            this.dgvShopList.AllowUserToAddRows = false;
            this.dgvShopList.AllowUserToDeleteRows = false;
            this.dgvShopList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShopList.Location = new System.Drawing.Point(0, 0);
            this.dgvShopList.Name = "dgvShopList";
            this.dgvShopList.ReadOnly = true;
            this.dgvShopList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopList.Size = new System.Drawing.Size(962, 352);
            this.dgvShopList.TabIndex = 20;
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
            this.btnAddorEdit.Location = new System.Drawing.Point(801, 13);
            this.btnAddorEdit.Name = "btnAddorEdit";
            this.btnAddorEdit.Padding = new System.Windows.Forms.Padding(7);
            this.btnAddorEdit.Size = new System.Drawing.Size(113, 54);
            this.btnAddorEdit.TabIndex = 61;
            this.btnAddorEdit.Text = "Select";
            this.btnAddorEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddorEdit.UseVisualStyleBackColor = false;
            this.btnAddorEdit.Click += new System.EventHandler(this.btnAddorEdit_Click);
            // 
            // FrmChooseShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 482);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChooseShop";
            this.Text = "FrmChooseShop";
            this.Load += new System.EventHandler(this.FrmChooseShop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvShopList;
        public System.Windows.Forms.Button btnAddorEdit;
    }
}