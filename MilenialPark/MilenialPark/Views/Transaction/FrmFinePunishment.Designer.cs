namespace MilenialPark.Views.Transaction
{
    partial class FrmFinePunishment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinePunishment));
            this.btnVerify = new System.Windows.Forms.Button();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefreshQuinosSales = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvQuinosSales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintStruk = new System.Windows.Forms.Button();
            this.dgvFineDetail = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuinosSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFineDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnVerify.Image = ((System.Drawing.Image)(resources.GetObject("btnVerify.Image")));
            this.btnVerify.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnVerify.Location = new System.Drawing.Point(907, 438);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Padding = new System.Windows.Forms.Padding(7);
            this.btnVerify.Size = new System.Drawing.Size(163, 54);
            this.btnVerify.TabIndex = 89;
            this.btnVerify.Text = "VERIFY";
            this.btnVerify.UseVisualStyleBackColor = true;
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.Location = new System.Drawing.Point(20, 69);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(16, 21);
            this.lblTransactionID.TabIndex = 81;
            this.lblTransactionID.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.btnRefreshQuinosSales);
            this.panel2.Controls.Add(this.lblAmount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dgvQuinosSales);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnPrintStruk);
            this.panel2.Controls.Add(this.dgvFineDetail);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.lblTransactionID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1094, 504);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnRefreshQuinosSales
            // 
            this.btnRefreshQuinosSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnRefreshQuinosSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshQuinosSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshQuinosSales.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshQuinosSales.ForeColor = System.Drawing.Color.White;
            this.btnRefreshQuinosSales.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRefreshQuinosSales.Location = new System.Drawing.Point(107, 278);
            this.btnRefreshQuinosSales.Name = "btnRefreshQuinosSales";
            this.btnRefreshQuinosSales.Padding = new System.Windows.Forms.Padding(7);
            this.btnRefreshQuinosSales.Size = new System.Drawing.Size(94, 54);
            this.btnRefreshQuinosSales.TabIndex = 114;
            this.btnRefreshQuinosSales.Text = "REFRESH";
            this.btnRefreshQuinosSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshQuinosSales.UseVisualStyleBackColor = false;
            this.btnRefreshQuinosSales.Click += new System.EventHandler(this.btnRefreshQuinosSales_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(23, 132);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(16, 21);
            this.lblAmount.TabIndex = 113;
            this.lblAmount.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 112;
            this.label4.Text = "Total Amount";
            // 
            // dgvQuinosSales
            // 
            this.dgvQuinosSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuinosSales.Location = new System.Drawing.Point(212, 230);
            this.dgvQuinosSales.Name = "dgvQuinosSales";
            this.dgvQuinosSales.Size = new System.Drawing.Size(858, 202);
            this.dgvQuinosSales.TabIndex = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 110;
            this.label1.Text = "Quinos Sales";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnPrintStruk
            // 
            this.btnPrintStruk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnPrintStruk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintStruk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintStruk.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStruk.ForeColor = System.Drawing.Color.White;
            this.btnPrintStruk.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStruk.Image")));
            this.btnPrintStruk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPrintStruk.Location = new System.Drawing.Point(12, 160);
            this.btnPrintStruk.Name = "btnPrintStruk";
            this.btnPrintStruk.Padding = new System.Windows.Forms.Padding(7);
            this.btnPrintStruk.Size = new System.Drawing.Size(189, 54);
            this.btnPrintStruk.TabIndex = 109;
            this.btnPrintStruk.Text = "PRINT FINE DETAILS";
            this.btnPrintStruk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintStruk.UseVisualStyleBackColor = false;
           
            // 
            // dgvFineDetail
            // 
            this.dgvFineDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFineDetail.Location = new System.Drawing.Point(212, 12);
            this.dgvFineDetail.Name = "dgvFineDetail";
            this.dgvFineDetail.Size = new System.Drawing.Size(858, 202);
            this.dgvFineDetail.TabIndex = 108;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 21);
            this.label8.TabIndex = 100;
            this.label8.Text = "SANKSI KETERLAMBATAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 80;
            this.label2.Text = "Transaction ID";
            // 
            // FrmFinePunishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 504);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFinePunishment";
            this.Text = "FrmFinePunishment";
            this.Load += new System.EventHandler(this.FrmFinePunishment_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuinosSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFineDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVerify;
        public System.Windows.Forms.Label lblTransactionID;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvFineDetail;
        private System.Windows.Forms.Button btnPrintStruk;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvQuinosSales;
        public System.Windows.Forms.Label lblAmount;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefreshQuinosSales;
    }
}