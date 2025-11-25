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
            this.rtxDataIO = new System.Windows.Forms.RichTextBox();
            this.panellabel1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblNewOrder);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(0, 0);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(1102, 51);
            this.panellabel1.TabIndex = 18;
            // 
            // lblNewOrder
            // 
            this.lblNewOrder.AutoSize = true;
            this.lblNewOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrder.ForeColor = System.Drawing.Color.White;
            this.lblNewOrder.Location = new System.Drawing.Point(12, 15);
            this.lblNewOrder.Name = "lblNewOrder";
            this.lblNewOrder.Size = new System.Drawing.Size(121, 25);
            this.lblNewOrder.TabIndex = 24;
            this.lblNewOrder.Text = "Gate Control";
            // 
            // leftPanel
            // 
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
            this.leftPanel.Location = new System.Drawing.Point(0, 51);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(479, 610);
            this.leftPanel.TabIndex = 19;
            // 
            // lblmanual
            // 
            this.lblmanual.AutoSize = true;
            this.lblmanual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanual.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblmanual.Location = new System.Drawing.Point(41, 353);
            this.lblmanual.Name = "lblmanual";
            this.lblmanual.Size = new System.Drawing.Size(313, 20);
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
            this.btnSend.Location = new System.Drawing.Point(165, 381);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 46);
            this.btnSend.TabIndex = 51;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtGateCode
            // 
            this.txtGateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGateCode.Location = new System.Drawing.Point(45, 391);
            this.txtGateCode.Name = "txtGateCode";
            this.txtGateCode.Size = new System.Drawing.Size(101, 26);
            this.txtGateCode.TabIndex = 50;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(44, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 46);
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
            this.btnDisc.Location = new System.Drawing.Point(156, 185);
            this.btnDisc.Name = "btnDisc";
            this.btnDisc.Size = new System.Drawing.Size(170, 46);
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
            this.btnConn.Location = new System.Drawing.Point(156, 124);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(170, 46);
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
            this.btnRefrs.Location = new System.Drawing.Point(36, 124);
            this.btnRefrs.Name = "btnRefrs";
            this.btnRefrs.Size = new System.Drawing.Size(101, 46);
            this.btnRefrs.TabIndex = 46;
            this.btnRefrs.Text = "Refresh";
            this.btnRefrs.UseVisualStyleBackColor = false;
            this.btnRefrs.Click += new System.EventHandler(this.btnRefrs_Click);
            // 
            // PortStatus
            // 
            this.PortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortStatus.Location = new System.Drawing.Point(156, 75);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(170, 26);
            this.PortStatus.TabIndex = 45;
            // 
            // ComboPort
            // 
            this.ComboPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPort.FormattingEnabled = true;
            this.ComboPort.ItemHeight = 20;
            this.ComboPort.Location = new System.Drawing.Point(156, 35);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.Size = new System.Drawing.Size(170, 28);
            this.ComboPort.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(40, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Port Status :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "COM Port :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtxDataIO);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(479, 51);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(7);
            this.panel3.Size = new System.Drawing.Size(623, 610);
            this.panel3.TabIndex = 20;
            // 
            // rtxDataIO
            // 
            this.rtxDataIO.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtxDataIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDataIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDataIO.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxDataIO.Location = new System.Drawing.Point(7, 7);
            this.rtxDataIO.Name = "rtxDataIO";
            this.rtxDataIO.Size = new System.Drawing.Size(609, 596);
            this.rtxDataIO.TabIndex = 3;
            this.rtxDataIO.Text = "";
            // 
            // FrmGateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.panellabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}