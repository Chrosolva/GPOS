namespace MilenialPark.UserControls
{
    partial class UCShopList
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lblShopID = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblMainProduct = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPanel.Controls.Add(this.btnDetails);
            this.contentPanel.Controls.Add(this.lblUserID);
            this.contentPanel.Controls.Add(this.lblAddress);
            this.contentPanel.Controls.Add(this.lblMainProduct);
            this.contentPanel.Controls.Add(this.lblShopName);
            this.contentPanel.Controls.Add(this.lblShopID);
            this.contentPanel.Location = new System.Drawing.Point(5, 6);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(420, 108);
            this.contentPanel.TabIndex = 0;
            this.contentPanel.MouseEnter += new System.EventHandler(this.contentPanel_MouseEnter);
            this.contentPanel.MouseLeave += new System.EventHandler(this.contentPanel_MouseLeave);
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopID.ForeColor = System.Drawing.Color.Black;
            this.lblShopID.Location = new System.Drawing.Point(5, 8);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(70, 21);
            this.lblShopID.TabIndex = 30;
            this.lblShopID.Text = "Shop ID";
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopName.ForeColor = System.Drawing.Color.DimGray;
            this.lblShopName.Location = new System.Drawing.Point(5, 34);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(82, 19);
            this.lblShopName.TabIndex = 31;
            this.lblShopName.Text = "Shop Name";
            // 
            // lblMainProduct
            // 
            this.lblMainProduct.AutoSize = true;
            this.lblMainProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainProduct.ForeColor = System.Drawing.Color.DimGray;
            this.lblMainProduct.Location = new System.Drawing.Point(5, 56);
            this.lblMainProduct.Name = "lblMainProduct";
            this.lblMainProduct.Size = new System.Drawing.Size(94, 19);
            this.lblMainProduct.TabIndex = 32;
            this.lblMainProduct.Text = "Main Product";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblAddress.Location = new System.Drawing.Point(5, 75);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 19);
            this.lblAddress.TabIndex = 33;
            this.lblAddress.Text = "Address";
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblUserID.Location = new System.Drawing.Point(244, 11);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(171, 19);
            this.lblUserID.TabIndex = 34;
            this.lblUserID.Text = "User ID";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnDetails.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetails.Location = new System.Drawing.Point(306, 54);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Padding = new System.Windows.Forms.Padding(7);
            this.btnDetails.Size = new System.Drawing.Size(109, 40);
            this.btnDetails.TabIndex = 35;
            this.btnDetails.Text = "Details";
            this.btnDetails.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // UCShopList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Name = "UCShopList";
            this.Size = new System.Drawing.Size(430, 118);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        public System.Windows.Forms.Label lblUserID;
        public System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.Label lblMainProduct;
        public System.Windows.Forms.Label lblShopName;
        public System.Windows.Forms.Label lblShopID;
        public System.Windows.Forms.Button btnDetails;
    }
}
