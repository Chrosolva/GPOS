namespace MilenialPark.UserControls
{
    partial class UCCardTransList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCardTransList));
            this.titlepanel = new System.Windows.Forms.Panel();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.lblcustomer = new System.Windows.Forms.Label();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.lblCardID = new System.Windows.Forms.Label();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.imgdecrease = new System.Windows.Forms.PictureBox();
            this.imgincrease = new System.Windows.Forms.PictureBox();
            this.lblfinalbalance = new System.Windows.Forms.Label();
            this.lblInitialBalance = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.titlepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgdecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgincrease)).BeginInit();
            this.SuspendLayout();
            // 
            // titlepanel
            // 
            this.titlepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titlepanel.Controls.Add(this.lblTransactionID);
            this.titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlepanel.Location = new System.Drawing.Point(0, 0);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(429, 29);
            this.titlepanel.TabIndex = 15;
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.ForeColor = System.Drawing.Color.White;
            this.lblTransactionID.Location = new System.Drawing.Point(5, 3);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(221, 21);
            this.lblTransactionID.TabIndex = 24;
            this.lblTransactionID.Text = "ID : TRD.SH23-001-23-000001";
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.btnDetails.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetails.Location = new System.Drawing.Point(200, 67);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Padding = new System.Windows.Forms.Padding(7);
            this.btnDetails.Size = new System.Drawing.Size(71, 40);
            this.btnDetails.TabIndex = 40;
            this.btnDetails.Text = "Details";
            this.btnDetails.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustomer.ForeColor = System.Drawing.Color.Black;
            this.lblcustomer.Location = new System.Drawing.Point(9, 86);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(69, 19);
            this.lblcustomer.TabIndex = 39;
            this.lblcustomer.Text = "Customer";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentType.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentType.Location = new System.Drawing.Point(9, 62);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(143, 19);
            this.lblPaymentType.TabIndex = 38;
            this.lblPaymentType.Text = "Payment Type : CASH";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDate.ForeColor = System.Drawing.Color.Black;
            this.lblTransactionDate.Location = new System.Drawing.Point(9, 39);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(208, 19);
            this.lblTransactionDate.TabIndex = 37;
            this.lblTransactionDate.Text = "Date : 2023-03-19 03:45:47.987";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSize = true;
            this.lblCardID.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID.ForeColor = System.Drawing.Color.Black;
            this.lblCardID.Location = new System.Drawing.Point(9, 108);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(143, 19);
            this.lblCardID.TabIndex = 41;
            this.lblCardID.Text = "CardID : 10107770101";
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReceipt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.btnReceipt.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceipt.Location = new System.Drawing.Point(278, 67);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Padding = new System.Windows.Forms.Padding(7);
            this.btnReceipt.Size = new System.Drawing.Size(81, 40);
            this.btnReceipt.TabIndex = 42;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceipt.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.Location = new System.Drawing.Point(355, 67);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(7);
            this.btnPrint.Size = new System.Drawing.Size(71, 40);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(304, 39);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(122, 19);
            this.lblTotalAmount.TabIndex = 44;
            this.lblTotalAmount.Text = "Total : Rp. 131.000";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgdecrease
            // 
            this.imgdecrease.Image = ((System.Drawing.Image)(resources.GetObject("imgdecrease.Image")));
            this.imgdecrease.Location = new System.Drawing.Point(203, 142);
            this.imgdecrease.Name = "imgdecrease";
            this.imgdecrease.Size = new System.Drawing.Size(23, 23);
            this.imgdecrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgdecrease.TabIndex = 49;
            this.imgdecrease.TabStop = false;
            // 
            // imgincrease
            // 
            this.imgincrease.Image = ((System.Drawing.Image)(resources.GetObject("imgincrease.Image")));
            this.imgincrease.Location = new System.Drawing.Point(203, 140);
            this.imgincrease.Name = "imgincrease";
            this.imgincrease.Size = new System.Drawing.Size(23, 23);
            this.imgincrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgincrease.TabIndex = 53;
            this.imgincrease.TabStop = false;
            // 
            // lblfinalbalance
            // 
            this.lblfinalbalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblfinalbalance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfinalbalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.lblfinalbalance.Location = new System.Drawing.Point(232, 142);
            this.lblfinalbalance.Name = "lblfinalbalance";
            this.lblfinalbalance.Size = new System.Drawing.Size(194, 19);
            this.lblfinalbalance.TabIndex = 52;
            this.lblfinalbalance.Text = "0";
            // 
            // lblInitialBalance
            // 
            this.lblInitialBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.lblInitialBalance.Location = new System.Drawing.Point(5, 140);
            this.lblInitialBalance.Name = "lblInitialBalance";
            this.lblInitialBalance.Size = new System.Drawing.Size(192, 19);
            this.lblInitialBalance.TabIndex = 51;
            this.lblInitialBalance.Text = "0";
            this.lblInitialBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(176, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 19);
            this.label20.TabIndex = 50;
            this.label20.Text = "Card Balance";
            // 
            // UCCardTransList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgdecrease);
            this.Controls.Add(this.imgincrease);
            this.Controls.Add(this.lblfinalbalance);
            this.Controls.Add(this.lblInitialBalance);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReceipt);
            this.Controls.Add(this.lblCardID);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblcustomer);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.titlepanel);
            this.Name = "UCCardTransList";
            this.Size = new System.Drawing.Size(429, 168);
            this.titlepanel.ResumeLayout(false);
            this.titlepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgdecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgincrease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titlepanel;
        public System.Windows.Forms.Label lblTransactionID;
        public System.Windows.Forms.Button btnDetails;
        public System.Windows.Forms.Label lblcustomer;
        public System.Windows.Forms.Label lblPaymentType;
        public System.Windows.Forms.Label lblTransactionDate;
        public System.Windows.Forms.Label lblCardID;
        public System.Windows.Forms.Button btnReceipt;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.PictureBox imgdecrease;
        private System.Windows.Forms.PictureBox imgincrease;
        public System.Windows.Forms.Label lblfinalbalance;
        public System.Windows.Forms.Label lblInitialBalance;
        public System.Windows.Forms.Label label20;
    }
}
