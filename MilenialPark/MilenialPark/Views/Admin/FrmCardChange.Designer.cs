namespace MilenialPark.Views.Admin
{
    partial class FrmCardChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardChange));
            this.lblCardIDOld = new System.Windows.Forms.Label();
            this.txtCardIDOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardIDNew = new System.Windows.Forms.TextBox();
            this.lblSaldoOld = new System.Windows.Forms.Label();
            this.lblCustomerNameOld = new System.Windows.Forms.Label();
            this.lblIdentityNoOld = new System.Windows.Forms.Label();
            this.lblIdentityNoNew = new System.Windows.Forms.Label();
            this.lblCustomerNameNew = new System.Windows.Forms.Label();
            this.lblSaldoNew = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxCause = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCardIDOld
            // 
            this.lblCardIDOld.AutoSize = true;
            this.lblCardIDOld.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardIDOld.Location = new System.Drawing.Point(46, 52);
            this.lblCardIDOld.Name = "lblCardIDOld";
            this.lblCardIDOld.Size = new System.Drawing.Size(98, 21);
            this.lblCardIDOld.TabIndex = 46;
            this.lblCardIDOld.Text = "Old Card ID ";
            // 
            // txtCardIDOld
            // 
            this.txtCardIDOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardIDOld.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardIDOld.Location = new System.Drawing.Point(50, 76);
            this.txtCardIDOld.Name = "txtCardIDOld";
            this.txtCardIDOld.Size = new System.Drawing.Size(327, 29);
            this.txtCardIDOld.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(418, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "New Card ID";
            // 
            // txtCardIDNew
            // 
            this.txtCardIDNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardIDNew.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardIDNew.Location = new System.Drawing.Point(422, 76);
            this.txtCardIDNew.Name = "txtCardIDNew";
            this.txtCardIDNew.Size = new System.Drawing.Size(327, 29);
            this.txtCardIDNew.TabIndex = 47;
            // 
            // lblSaldoOld
            // 
            this.lblSaldoOld.AutoSize = true;
            this.lblSaldoOld.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoOld.Location = new System.Drawing.Point(46, 170);
            this.lblSaldoOld.Name = "lblSaldoOld";
            this.lblSaldoOld.Size = new System.Drawing.Size(121, 21);
            this.lblSaldoOld.TabIndex = 53;
            this.lblSaldoOld.Text = "Balance (Saldo)";
            // 
            // lblCustomerNameOld
            // 
            this.lblCustomerNameOld.AutoSize = true;
            this.lblCustomerNameOld.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameOld.Location = new System.Drawing.Point(46, 120);
            this.lblCustomerNameOld.Name = "lblCustomerNameOld";
            this.lblCustomerNameOld.Size = new System.Drawing.Size(128, 21);
            this.lblCustomerNameOld.TabIndex = 54;
            this.lblCustomerNameOld.Text = "Customer Name";
            // 
            // lblIdentityNoOld
            // 
            this.lblIdentityNoOld.AutoSize = true;
            this.lblIdentityNoOld.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityNoOld.Location = new System.Drawing.Point(46, 145);
            this.lblIdentityNoOld.Name = "lblIdentityNoOld";
            this.lblIdentityNoOld.Size = new System.Drawing.Size(179, 21);
            this.lblIdentityNoOld.TabIndex = 55;
            this.lblIdentityNoOld.Text = "Identity No (KTP / SIM)";
            // 
            // lblIdentityNoNew
            // 
            this.lblIdentityNoNew.AutoSize = true;
            this.lblIdentityNoNew.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityNoNew.Location = new System.Drawing.Point(418, 145);
            this.lblIdentityNoNew.Name = "lblIdentityNoNew";
            this.lblIdentityNoNew.Size = new System.Drawing.Size(179, 21);
            this.lblIdentityNoNew.TabIndex = 58;
            this.lblIdentityNoNew.Text = "Identity No (KTP / SIM)";
            // 
            // lblCustomerNameNew
            // 
            this.lblCustomerNameNew.AutoSize = true;
            this.lblCustomerNameNew.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameNew.Location = new System.Drawing.Point(418, 120);
            this.lblCustomerNameNew.Name = "lblCustomerNameNew";
            this.lblCustomerNameNew.Size = new System.Drawing.Size(128, 21);
            this.lblCustomerNameNew.TabIndex = 57;
            this.lblCustomerNameNew.Text = "Customer Name";
            // 
            // lblSaldoNew
            // 
            this.lblSaldoNew.AutoSize = true;
            this.lblSaldoNew.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoNew.Location = new System.Drawing.Point(418, 170);
            this.lblSaldoNew.Name = "lblSaldoNew";
            this.lblSaldoNew.Size = new System.Drawing.Size(121, 21);
            this.lblSaldoNew.TabIndex = 56;
            this.lblSaldoNew.Text = "Balance (Saldo)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 21);
            this.label8.TabIndex = 60;
            this.label8.Text = "Cause";
            // 
            // cbxCause
            // 
            this.cbxCause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCause.FormattingEnabled = true;
            this.cbxCause.Items.AddRange(new object[] {
            "KARTU HILANG",
            "KARTU RUSAK"});
            this.cbxCause.Location = new System.Drawing.Point(50, 259);
            this.cbxCause.Name = "cbxCause";
            this.cbxCause.Size = new System.Drawing.Size(327, 21);
            this.cbxCause.TabIndex = 61;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(533, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7);
            this.btnSave.Size = new System.Drawing.Size(216, 54);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmCardChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 428);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxCause);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblIdentityNoNew);
            this.Controls.Add(this.lblCustomerNameNew);
            this.Controls.Add(this.lblSaldoNew);
            this.Controls.Add(this.lblIdentityNoOld);
            this.Controls.Add(this.lblCustomerNameOld);
            this.Controls.Add(this.lblSaldoOld);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCardIDNew);
            this.Controls.Add(this.lblCardIDOld);
            this.Controls.Add(this.txtCardIDOld);
            this.Name = "FrmCardChange";
            this.Text = "FrmCardChange";
            this.Load += new System.EventHandler(this.FrmCardChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCardIDOld;
        public System.Windows.Forms.TextBox txtCardIDOld;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCardIDNew;
        public System.Windows.Forms.Label lblSaldoOld;
        public System.Windows.Forms.Label lblCustomerNameOld;
        public System.Windows.Forms.Label lblIdentityNoOld;
        public System.Windows.Forms.Label lblIdentityNoNew;
        public System.Windows.Forms.Label lblCustomerNameNew;
        public System.Windows.Forms.Label lblSaldoNew;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxCause;
        private System.Windows.Forms.Button btnSave;
    }
}