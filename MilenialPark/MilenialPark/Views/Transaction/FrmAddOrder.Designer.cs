namespace MilenialPark.Views.Transaction
{
    partial class FrmAddOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NUDQty = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblItemName2 = new System.Windows.Forms.Label();
            this.btnPalceOrder = new System.Windows.Forms.Button();
            this.pbfoodImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.lblTopUpAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWaktuBermain = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToleransi = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoodImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 51);
            this.panel1.TabIndex = 6;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(6, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(111, 25);
            this.lblFormTitle.TabIndex = 35;
            this.lblFormTitle.Text = "Place Order";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblToleransi);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblWaktuBermain);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTopUpAmount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.NUDQty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblPrice);
            this.panel2.Controls.Add(this.lblItemDesc);
            this.panel2.Controls.Add(this.lblItemName2);
            this.panel2.Controls.Add(this.btnPalceOrder);
            this.panel2.Controls.Add(this.pbfoodImage);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblItemID);
            this.panel2.Controls.Add(this.lblCardID2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 511);
            this.panel2.TabIndex = 7;
            // 
            // NUDQty
            // 
            this.NUDQty.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDQty.Location = new System.Drawing.Point(382, 187);
            this.NUDQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDQty.Name = "NUDQty";
            this.NUDQty.Size = new System.Drawing.Size(83, 32);
            this.NUDQty.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 21);
            this.label7.TabIndex = 64;
            this.label7.Text = "Quantity";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(378, 142);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(16, 21);
            this.lblPrice.TabIndex = 63;
            this.lblPrice.Text = "-";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(378, 99);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(16, 21);
            this.lblItemDesc.TabIndex = 62;
            this.lblItemDesc.Text = "-";
            // 
            // lblItemName2
            // 
            this.lblItemName2.AutoSize = true;
            this.lblItemName2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName2.Location = new System.Drawing.Point(378, 59);
            this.lblItemName2.Name = "lblItemName2";
            this.lblItemName2.Size = new System.Drawing.Size(16, 21);
            this.lblItemName2.TabIndex = 61;
            this.lblItemName2.Text = "-";
            // 
            // btnPalceOrder
            // 
            this.btnPalceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnPalceOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPalceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPalceOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPalceOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnPalceOrder.Image")));
            this.btnPalceOrder.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPalceOrder.Location = new System.Drawing.Point(339, 338);
            this.btnPalceOrder.Name = "btnPalceOrder";
            this.btnPalceOrder.Padding = new System.Windows.Forms.Padding(7);
            this.btnPalceOrder.Size = new System.Drawing.Size(146, 54);
            this.btnPalceOrder.TabIndex = 60;
            this.btnPalceOrder.Text = "PlaceOrder";
            this.btnPalceOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPalceOrder.UseVisualStyleBackColor = false;
            this.btnPalceOrder.Click += new System.EventHandler(this.btnPalceOrder_Click);
            // 
            // pbfoodImage
            // 
            this.pbfoodImage.Location = new System.Drawing.Point(11, 15);
            this.pbfoodImage.Name = "pbfoodImage";
            this.pbfoodImage.Size = new System.Drawing.Size(193, 198);
            this.pbfoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfoodImage.TabIndex = 59;
            this.pbfoodImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Item Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "Item Name";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.Location = new System.Drawing.Point(378, 21);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(16, 21);
            this.lblItemID.TabIndex = 47;
            this.lblItemID.Text = "-";
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(221, 21);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(60, 21);
            this.lblCardID2.TabIndex = 46;
            this.lblCardID2.Text = "Item ID";
            // 
            // lblTopUpAmount
            // 
            this.lblTopUpAmount.AutoSize = true;
            this.lblTopUpAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUpAmount.Location = new System.Drawing.Point(137, 260);
            this.lblTopUpAmount.Name = "lblTopUpAmount";
            this.lblTopUpAmount.Size = new System.Drawing.Size(16, 21);
            this.lblTopUpAmount.TabIndex = 70;
            this.lblTopUpAmount.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 21);
            this.label5.TabIndex = 69;
            this.label5.Text = "Top Up Amount";
            // 
            // lblWaktuBermain
            // 
            this.lblWaktuBermain.AutoSize = true;
            this.lblWaktuBermain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaktuBermain.Location = new System.Drawing.Point(137, 293);
            this.lblWaktuBermain.Name = "lblWaktuBermain";
            this.lblWaktuBermain.Size = new System.Drawing.Size(16, 21);
            this.lblWaktuBermain.TabIndex = 72;
            this.lblWaktuBermain.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 71;
            this.label6.Text = "Waktu Bermain";
            // 
            // lblToleransi
            // 
            this.lblToleransi.AutoSize = true;
            this.lblToleransi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToleransi.Location = new System.Drawing.Point(137, 322);
            this.lblToleransi.Name = "lblToleransi";
            this.lblToleransi.Size = new System.Drawing.Size(16, 21);
            this.lblToleransi.TabIndex = 74;
            this.lblToleransi.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 73;
            this.label8.Text = "Toleransi";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(139, 239);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(16, 21);
            this.lblCategory.TabIndex = 76;
            this.lblCategory.Text = "-";
            this.lblCategory.Click += new System.EventHandler(this.label3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 75;
            this.label9.Text = "Category";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // FrmAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAddOrder";
            this.Text = "FrmAddOrder";
            this.Load += new System.EventHandler(this.FrmAddOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoodImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnPalceOrder;
        private System.Windows.Forms.PictureBox pbfoodImage;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblItemID;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblPrice;
        public System.Windows.Forms.Label lblItemDesc;
        public System.Windows.Forms.Label lblItemName2;
        private System.Windows.Forms.NumericUpDown NUDQty;
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblToleransi;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblWaktuBermain;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblTopUpAmount;
        public System.Windows.Forms.Label label5;
    }
}