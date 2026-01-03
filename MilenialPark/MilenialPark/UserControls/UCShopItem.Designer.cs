namespace MilenialPark.UserControls
{
    partial class UCShopItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outerpanel = new System.Windows.Forms.Panel();
            this.contentpanel = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblRP = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.outerpanel.SuspendLayout();
            this.contentpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerpanel
            // 
            this.outerpanel.Controls.Add(this.contentpanel);
            this.outerpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerpanel.Location = new System.Drawing.Point(0, 0);
            this.outerpanel.Name = "outerpanel";
            this.outerpanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.outerpanel.Size = new System.Drawing.Size(231, 104);
            this.outerpanel.TabIndex = 0;
            this.outerpanel.MouseEnter += new System.EventHandler(this.outerpanel_MouseEnter);
            this.outerpanel.MouseLeave += new System.EventHandler(this.outerpanel_MouseLeave);
            // 
            // contentpanel
            // 
            this.contentpanel.BackColor = System.Drawing.Color.White;
            this.contentpanel.Controls.Add(this.lblCategory);
            this.contentpanel.Controls.Add(this.lblItemPrice);
            this.contentpanel.Controls.Add(this.lblRP);
            this.contentpanel.Controls.Add(this.lblItemName);
            this.contentpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentpanel.Location = new System.Drawing.Point(5, 5);
            this.contentpanel.Name = "contentpanel";
            this.contentpanel.Size = new System.Drawing.Size(221, 94);
            this.contentpanel.TabIndex = 1;
            this.contentpanel.MouseEnter += new System.EventHandler(this.outerpanel_MouseEnter);
            this.contentpanel.MouseLeave += new System.EventHandler(this.outerpanel_MouseLeave);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(6, 68);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(13, 17);
            this.lblCategory.TabIndex = 60;
            this.lblCategory.Text = "-";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(36, 51);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(13, 17);
            this.lblItemPrice.TabIndex = 59;
            this.lblItemPrice.Text = "-";
            // 
            // lblRP
            // 
            this.lblRP.AutoSize = true;
            this.lblRP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRP.Location = new System.Drawing.Point(3, 51);
            this.lblRP.Name = "lblRP";
            this.lblRP.Size = new System.Drawing.Size(27, 17);
            this.lblRP.TabIndex = 58;
            this.lblRP.Text = "Rp.";
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(3, 3);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(215, 41);
            this.lblItemName.TabIndex = 57;
            this.lblItemName.Text = "ItemName";
            // 
            // UCShopItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outerpanel);
            this.Name = "UCShopItem";
            this.Size = new System.Drawing.Size(231, 104);
            this.outerpanel.ResumeLayout(false);
            this.contentpanel.ResumeLayout(false);
            this.contentpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.Label lblItemPrice;
        public System.Windows.Forms.Label lblRP;
        public System.Windows.Forms.Label lblItemName;
        public System.Windows.Forms.Panel outerpanel;
        public System.Windows.Forms.Panel contentpanel;
    }
}
