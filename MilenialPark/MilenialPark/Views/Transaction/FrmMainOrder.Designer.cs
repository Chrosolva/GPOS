namespace MilenialPark.Views.Transaction
{
    partial class FrmMainOrder
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
            this.TCMainOrder = new System.Windows.Forms.TabControl();
            this.TPOrders = new System.Windows.Forms.TabPage();
            this.TPNEOrders = new System.Windows.Forms.TabPage();
            this.TPTopUpCard = new System.Windows.Forms.TabPage();
            this.TPDaftarKartu = new System.Windows.Forms.TabPage();
            this.TPQuinosSales = new System.Windows.Forms.TabPage();
            this.TCMainOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCMainOrder
            // 
            this.TCMainOrder.Controls.Add(this.TPOrders);
            this.TCMainOrder.Controls.Add(this.TPQuinosSales);
            this.TCMainOrder.Controls.Add(this.TPNEOrders);
            this.TCMainOrder.Controls.Add(this.TPTopUpCard);
            this.TCMainOrder.Controls.Add(this.TPDaftarKartu);
            this.TCMainOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCMainOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCMainOrder.ItemSize = new System.Drawing.Size(58, 35);
            this.TCMainOrder.Location = new System.Drawing.Point(0, 0);
            this.TCMainOrder.Name = "TCMainOrder";
            this.TCMainOrder.SelectedIndex = 0;
            this.TCMainOrder.Size = new System.Drawing.Size(1308, 632);
            this.TCMainOrder.TabIndex = 0;
            this.TCMainOrder.SelectedIndexChanged += new System.EventHandler(this.TCMainOrder_SelectedIndexChanged);
            // 
            // TPOrders
            // 
            this.TPOrders.AutoScroll = true;
            this.TPOrders.Location = new System.Drawing.Point(4, 39);
            this.TPOrders.Name = "TPOrders";
            this.TPOrders.Padding = new System.Windows.Forms.Padding(3);
            this.TPOrders.Size = new System.Drawing.Size(1300, 589);
            this.TPOrders.TabIndex = 0;
            this.TPOrders.Text = "Orders";
            this.TPOrders.UseVisualStyleBackColor = true;
            // 
            // TPNEOrders
            // 
            this.TPNEOrders.Location = new System.Drawing.Point(4, 39);
            this.TPNEOrders.Name = "TPNEOrders";
            this.TPNEOrders.Padding = new System.Windows.Forms.Padding(3);
            this.TPNEOrders.Size = new System.Drawing.Size(1300, 589);
            this.TPNEOrders.TabIndex = 1;
            this.TPNEOrders.Text = "Create Orders";
            this.TPNEOrders.UseVisualStyleBackColor = true;
            // 
            // TPTopUpCard
            // 
            this.TPTopUpCard.Location = new System.Drawing.Point(4, 39);
            this.TPTopUpCard.Name = "TPTopUpCard";
            this.TPTopUpCard.Size = new System.Drawing.Size(1300, 589);
            this.TPTopUpCard.TabIndex = 2;
            this.TPTopUpCard.Text = "Top Up Cards";
            this.TPTopUpCard.UseVisualStyleBackColor = true;
            // 
            // TPDaftarKartu
            // 
            this.TPDaftarKartu.Location = new System.Drawing.Point(4, 39);
            this.TPDaftarKartu.Name = "TPDaftarKartu";
            this.TPDaftarKartu.Size = new System.Drawing.Size(1300, 589);
            this.TPDaftarKartu.TabIndex = 3;
            this.TPDaftarKartu.Text = "Daftar Kartu";
            this.TPDaftarKartu.UseVisualStyleBackColor = true;
            // 
            // TPQuinosSales
            // 
            this.TPQuinosSales.Location = new System.Drawing.Point(4, 39);
            this.TPQuinosSales.Name = "TPQuinosSales";
            this.TPQuinosSales.Padding = new System.Windows.Forms.Padding(3);
            this.TPQuinosSales.Size = new System.Drawing.Size(1300, 589);
            this.TPQuinosSales.TabIndex = 4;
            this.TPQuinosSales.Text = "QUINOS ORDER";
            this.TPQuinosSales.UseVisualStyleBackColor = true;
            // 
            // FrmMainOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 632);
            this.Controls.Add(this.TCMainOrder);
            this.Name = "FrmMainOrder";
            this.Text = "FrmMainOrder";
            this.Load += new System.EventHandler(this.FrmMainOrder_Load);
            this.TCMainOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage TPOrders;
        private System.Windows.Forms.TabPage TPNEOrders;
        private System.Windows.Forms.TabPage TPTopUpCard;
        private System.Windows.Forms.TabPage TPDaftarKartu;
        public System.Windows.Forms.TabControl TCMainOrder;
        private System.Windows.Forms.TabPage TPQuinosSales;
    }
}