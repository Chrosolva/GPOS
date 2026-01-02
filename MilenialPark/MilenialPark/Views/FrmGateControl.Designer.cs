namespace MilenialPark.Views
{
    partial class FrmGateControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGateControl));
            this.panellabel1 = new System.Windows.Forms.Panel();
            this.lblNewOrder = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmanual = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtGateCode = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisc = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnRefrs = new System.Windows.Forms.Button();
            this.PortStatus = new System.Windows.Forms.TextBox();
            this.ComboPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReminder = new System.Windows.Forms.DataGridView();
            this.rtxDataIO = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panellabel1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder)).BeginInit();
            this.SuspendLayout();
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblNewOrder);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(0, 0);
            this.panellabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(1469, 63);
            this.panellabel1.TabIndex = 18;
            // 
            // lblNewOrder
            // 
            this.lblNewOrder.AutoSize = true;
            this.lblNewOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrder.ForeColor = System.Drawing.Color.White;
            this.lblNewOrder.Location = new System.Drawing.Point(16, 18);
            this.lblNewOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewOrder.Name = "lblNewOrder";
            this.lblNewOrder.Size = new System.Drawing.Size(155, 32);
            this.lblNewOrder.TabIndex = 24;
            this.lblNewOrder.Text = "Gate Control";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.label7);
            this.leftPanel.Controls.Add(this.label6);
            this.leftPanel.Controls.Add(this.label5);
            this.leftPanel.Controls.Add(this.label3);
            this.leftPanel.Controls.Add(this.cbxBaudRate);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.lblmanual);
            this.leftPanel.Controls.Add(this.btnSend);
            this.leftPanel.Controls.Add(this.txtGateCode);
            this.leftPanel.Controls.Add(this.btnClear);
            this.leftPanel.Controls.Add(this.btnDisc);
            this.leftPanel.Controls.Add(this.btnConn);
            this.leftPanel.Controls.Add(this.btnRefrs);
            this.leftPanel.Controls.Add(this.PortStatus);
            this.leftPanel.Controls.Add(this.ComboPort);
            this.leftPanel.Controls.Add(this.label4);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 63);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(541, 751);
            this.leftPanel.TabIndex = 19;
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.ItemHeight = 25;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "9600",
            "",
            "",
            "19200",
            "",
            "",
            "38400",
            "",
            "",
            "57600",
            "",
            "",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(208, 143);
            this.cbxBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(225, 33);
            this.cbxBaudRate.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(53, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 53;
            this.label1.Text = "BAUD RATE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblmanual
            // 
            this.lblmanual.AutoSize = true;
            this.lblmanual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanual.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblmanual.Location = new System.Drawing.Point(55, 434);
            this.lblmanual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmanual.Name = "lblmanual";
            this.lblmanual.Size = new System.Drawing.Size(394, 25);
            this.lblmanual.TabIndex = 52;
            this.lblmanual.Text = "Manual Open (Admin and Emergency Only)";
            this.lblmanual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Green;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSend.Location = new System.Drawing.Point(220, 469);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 57);
            this.btnSend.TabIndex = 51;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtGateCode
            // 
            this.txtGateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGateCode.Location = new System.Drawing.Point(60, 481);
            this.txtGateCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGateCode.Name = "txtGateCode";
            this.txtGateCode.Size = new System.Drawing.Size(133, 30);
            this.txtGateCode.TabIndex = 50;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(59, 357);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 57);
            this.btnClear.TabIndex = 49;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDisc
            // 
            this.btnDisc.BackColor = System.Drawing.Color.Red;
            this.btnDisc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisc.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDisc.Location = new System.Drawing.Point(208, 289);
            this.btnDisc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisc.Name = "btnDisc";
            this.btnDisc.Size = new System.Drawing.Size(227, 57);
            this.btnDisc.TabIndex = 48;
            this.btnDisc.Text = "Disconnect";
            this.btnDisc.UseVisualStyleBackColor = false;
            this.btnDisc.Click += new System.EventHandler(this.btnDisc_Click);
            // 
            // btnConn
            // 
            this.btnConn.BackColor = System.Drawing.Color.Green;
            this.btnConn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConn.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConn.Location = new System.Drawing.Point(208, 214);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(227, 57);
            this.btnConn.TabIndex = 47;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = false;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnRefrs
            // 
            this.btnRefrs.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRefrs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrs.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRefrs.Location = new System.Drawing.Point(48, 214);
            this.btnRefrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefrs.Name = "btnRefrs";
            this.btnRefrs.Size = new System.Drawing.Size(135, 57);
            this.btnRefrs.TabIndex = 46;
            this.btnRefrs.Text = "Refresh";
            this.btnRefrs.UseVisualStyleBackColor = false;
            this.btnRefrs.Click += new System.EventHandler(this.btnRefrs_Click);
            // 
            // PortStatus
            // 
            this.PortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortStatus.Location = new System.Drawing.Point(208, 92);
            this.PortStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(225, 30);
            this.PortStatus.TabIndex = 45;
            // 
            // ComboPort
            // 
            this.ComboPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPort.FormattingEnabled = true;
            this.ComboPort.ItemHeight = 25;
            this.ComboPort.Location = new System.Drawing.Point(208, 43);
            this.ComboPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.Size = new System.Drawing.Size(225, 33);
            this.ComboPort.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(53, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 43;
            this.label4.Text = "Port Status :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(53, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "COM Port :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.rtxDataIO);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(541, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.panel3.Size = new System.Drawing.Size(928, 751);
            this.panel3.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReminder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(9, 487);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 255);
            this.panel1.TabIndex = 4;
            // 
            // dgvReminder
            // 
            this.dgvReminder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReminder.Location = new System.Drawing.Point(0, 0);
            this.dgvReminder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReminder.Name = "dgvReminder";
            this.dgvReminder.Size = new System.Drawing.Size(910, 255);
            this.dgvReminder.TabIndex = 0;
            // 
            // rtxDataIO
            // 
            this.rtxDataIO.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtxDataIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxDataIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDataIO.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxDataIO.Location = new System.Drawing.Point(9, 9);
            this.rtxDataIO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxDataIO.Name = "rtxDataIO";
            this.rtxDataIO.Size = new System.Drawing.Size(910, 478);
            this.rtxDataIO.TabIndex = 3;
            this.rtxDataIO.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(60, 544);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 25);
            this.label3.TabIndex = 55;
            this.label3.Text = "GREEN = MASIH DALAM WAKTU BERMAIN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(60, 582);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 50);
            this.label5.TabIndex = 56;
            this.label5.Text = "YELLOW = WAKTU BERMAIN KURANG \r\nDARI 15 MENIT LAGI";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(55, 635);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(405, 50);
            this.label6.TabIndex = 57;
            this.label6.Text = "ORANGE = WAKTU BERMAIN HABIS DAN \r\nDALAM MASA TOLERANSI";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(60, 692);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(397, 50);
            this.label7.TabIndex = 58;
            this.label7.Text = "RED = WAKTU BERMAIN DILUAR BATAS \r\nDAN AKAN DI SANKSI";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmGateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 814);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.panellabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmGateControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGateControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGateControl_FormClosing);
            this.Load += new System.EventHandler(this.FrmGateControl_Load);
            this.panellabel1.ResumeLayout(false);
            this.panellabel1.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panellabel1;
        public System.Windows.Forms.Label lblNewOrder;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblmanual;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtGateCode;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDisc;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnRefrs;
        private System.Windows.Forms.TextBox PortStatus;
        private System.Windows.Forms.ComboBox ComboPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtxDataIO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReminder;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}