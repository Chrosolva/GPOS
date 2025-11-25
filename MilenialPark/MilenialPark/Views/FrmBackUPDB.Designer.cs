namespace MilenialPark.Views
{
    partial class FrmBackUPDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBackUPDB));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDatabaseItems = new System.Windows.Forms.ComboBox();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 69;
            this.label4.Text = "DataBase";
            // 
            // cmbDatabaseItems
            // 
            this.cmbDatabaseItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabaseItems.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabaseItems.FormattingEnabled = true;
            this.cmbDatabaseItems.Items.AddRange(new object[] {
            "WHNPOS"});
            this.cmbDatabaseItems.Location = new System.Drawing.Point(86, 89);
            this.cmbDatabaseItems.Name = "cmbDatabaseItems";
            this.cmbDatabaseItems.Size = new System.Drawing.Size(327, 29);
            this.cmbDatabaseItems.TabIndex = 68;
            // 
            // btnBackUp
            // 
            this.btnBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBackUp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackUp.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBackUp.Image = ((System.Drawing.Image)(resources.GetObject("btnBackUp.Image")));
            this.btnBackUp.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBackUp.Location = new System.Drawing.Point(173, 232);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Padding = new System.Windows.Forms.Padding(7);
            this.btnBackUp.Size = new System.Drawing.Size(134, 54);
            this.btnBackUp.TabIndex = 67;
            this.btnBackUp.Text = "Back Up";
            this.btnBackUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBrowse.Location = new System.Drawing.Point(432, 131);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Padding = new System.Windows.Forms.Padding(7);
            this.btnBrowse.Size = new System.Drawing.Size(123, 54);
            this.btnBrowse.TabIndex = 70;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 71;
            this.label1.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(86, 156);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(327, 29);
            this.txtPath.TabIndex = 72;
            // 
            // FrmBackUPDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 344);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDatabaseItems);
            this.Controls.Add(this.btnBackUp);
            this.Name = "FrmBackUPDB";
            this.Text = "FrmBackUPDB";
            this.Load += new System.EventHandler(this.FrmBackUPDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbDatabaseItems;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPath;
        public System.Windows.Forms.Button btnBackUp;
    }
}