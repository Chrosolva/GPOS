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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisc = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnRefrs = new System.Windows.Forms.Button();
            this.PortStatus = new System.Windows.Forms.TextBox();
            this.ComboPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblmanual = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtGateCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvReminder = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvGateLog = new System.Windows.Forms.DataGridView();
            this.btnChange = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxReason = new System.Windows.Forms.ComboBox();
            this.txtNewRFID = new System.Windows.Forms.TextBox();
            this.txtCurRFID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rtxDataIO = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.panellabel1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGateLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblNewOrder);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(0, 0);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(1419, 51);
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
            this.leftPanel.Controls.Add(this.lblRowCount);
            this.leftPanel.Controls.Add(this.label14);
            this.leftPanel.Controls.Add(this.btnUpdate);
            this.leftPanel.Controls.Add(this.label7);
            this.leftPanel.Controls.Add(this.label6);
            this.leftPanel.Controls.Add(this.label5);
            this.leftPanel.Controls.Add(this.label3);
            this.leftPanel.Controls.Add(this.cbxBaudRate);
            this.leftPanel.Controls.Add(this.label1);
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
            this.leftPanel.Size = new System.Drawing.Size(330, 748);
            this.leftPanel.TabIndex = 19;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(202, 448);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 38);
            this.btnUpdate.TabIndex = 59;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(308, 34);
            this.label7.TabIndex = 58;
            this.label7.Text = "RED = WAKTU BERMAIN DILUAR BATAS \r\nDAN AKAN DI SANKSI";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(5, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 34);
            this.label6.TabIndex = 57;
            this.label6.Text = "ORANGE = WAKTU BERMAIN HABIS DAN \r\nDALAM MASA TOLERANSI";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(9, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 34);
            this.label5.TabIndex = 56;
            this.label5.Text = "YELLOW = WAKTU BERMAIN KURANG \r\nDARI 15 MENIT LAGI";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "GREEN = MASIH DALAM WAKTU BERMAIN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.ItemHeight = 20;
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
            this.cbxBaudRate.Location = new System.Drawing.Point(124, 90);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(170, 28);
            this.cbxBaudRate.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "BAUD RATE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(13, 225);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 39);
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
            this.btnDisc.Location = new System.Drawing.Point(124, 177);
            this.btnDisc.Name = "btnDisc";
            this.btnDisc.Size = new System.Drawing.Size(170, 38);
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
            this.btnConn.Location = new System.Drawing.Point(124, 138);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(170, 33);
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
            this.btnRefrs.Location = new System.Drawing.Point(12, 138);
            this.btnRefrs.Name = "btnRefrs";
            this.btnRefrs.Size = new System.Drawing.Size(101, 33);
            this.btnRefrs.TabIndex = 46;
            this.btnRefrs.Text = "Refresh";
            this.btnRefrs.UseVisualStyleBackColor = false;
            this.btnRefrs.Click += new System.EventHandler(this.btnRefrs_Click);
            // 
            // PortStatus
            // 
            this.PortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortStatus.Location = new System.Drawing.Point(124, 49);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(170, 26);
            this.PortStatus.TabIndex = 45;
            // 
            // ComboPort
            // 
            this.ComboPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPort.FormattingEnabled = true;
            this.ComboPort.ItemHeight = 20;
            this.ComboPort.Location = new System.Drawing.Point(124, 9);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.Size = new System.Drawing.Size(170, 28);
            this.ComboPort.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 52);
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
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "COM Port :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblmanual
            // 
            this.lblmanual.AutoSize = true;
            this.lblmanual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanual.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblmanual.Location = new System.Drawing.Point(664, 1);
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
            this.btnSend.Location = new System.Drawing.Point(813, 26);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 36);
            this.btnSend.TabIndex = 51;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtGateCode
            // 
            this.txtGateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGateCode.Location = new System.Drawing.Point(668, 31);
            this.txtGateCode.Name = "txtGateCode";
            this.txtGateCode.Size = new System.Drawing.Size(101, 26);
            this.txtGateCode.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(330, 51);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(7);
            this.panel3.Size = new System.Drawing.Size(1089, 748);
            this.panel3.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvReminder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 458);
            this.panel2.TabIndex = 5;
            // 
            // dgvReminder
            // 
            this.dgvReminder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReminder.Location = new System.Drawing.Point(0, 0);
            this.dgvReminder.Name = "dgvReminder";
            this.dgvReminder.Size = new System.Drawing.Size(1075, 458);
            this.dgvReminder.TabIndex = 0;
            this.dgvReminder.SelectionChanged += new System.EventHandler(this.dgvReminder_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.txtPerson);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dgvGateLog);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbxReason);
            this.panel1.Controls.Add(this.txtNewRFID);
            this.panel1.Controls.Add(this.lblmanual);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.txtCurRFID);
            this.panel1.Controls.Add(this.txtGateCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.rtxDataIO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 276);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Green;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(881, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 36);
            this.btnExit.TabIndex = 69;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Green;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnter.Location = new System.Drawing.Point(775, 91);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(96, 36);
            this.btnEnter.TabIndex = 68;
            this.btnEnter.Text = "ENTER";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtPerson
            // 
            this.txtPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerson.Location = new System.Drawing.Point(668, 100);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(101, 26);
            this.txtPerson.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(672, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(237, 20);
            this.label13.TabIndex = 66;
            this.label13.Text = "Gate Masuk = 2 Gate Keluar = 3";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(532, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = " (Admin and Emergency Only)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(393, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 65;
            this.label11.Text = "Gate Log";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvGateLog
            // 
            this.dgvGateLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGateLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGateLog.Location = new System.Drawing.Point(393, 157);
            this.dgvGateLog.Name = "dgvGateLog";
            this.dgvGateLog.Size = new System.Drawing.Size(677, 113);
            this.dgvGateLog.TabIndex = 64;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Green;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.SystemColors.Control;
            this.btnChange.Location = new System.Drawing.Point(535, 90);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(119, 36);
            this.btnChange.TabIndex = 60;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(531, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "Reason";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxReason
            // 
            this.cbxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReason.FormattingEnabled = true;
            this.cbxReason.ItemHeight = 20;
            this.cbxReason.Items.AddRange(new object[] {
            "HILANG",
            "RUSAK"});
            this.cbxReason.Location = new System.Drawing.Point(535, 37);
            this.cbxReason.Name = "cbxReason";
            this.cbxReason.Size = new System.Drawing.Size(119, 28);
            this.cbxReason.TabIndex = 60;
            // 
            // txtNewRFID
            // 
            this.txtNewRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewRFID.Location = new System.Drawing.Point(393, 100);
            this.txtNewRFID.Name = "txtNewRFID";
            this.txtNewRFID.Size = new System.Drawing.Size(136, 26);
            this.txtNewRFID.TabIndex = 62;
            this.txtNewRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewRFID_KeyDown);
            // 
            // txtCurRFID
            // 
            this.txtCurRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurRFID.Location = new System.Drawing.Point(393, 39);
            this.txtCurRFID.Name = "txtCurRFID";
            this.txtCurRFID.Size = new System.Drawing.Size(136, 26);
            this.txtCurRFID.TabIndex = 60;
            this.txtCurRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurRFID_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(389, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 61;
            this.label9.Text = "New RFID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(389, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Current RFID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtxDataIO
            // 
            this.rtxDataIO.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtxDataIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxDataIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDataIO.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxDataIO.Location = new System.Drawing.Point(0, 0);
            this.rtxDataIO.Name = "rtxDataIO";
            this.rtxDataIO.Size = new System.Drawing.Size(387, 276);
            this.rtxDataIO.TabIndex = 3;
            this.rtxDataIO.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(10, 502);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(225, 34);
            this.label14.TabIndex = 60;
            this.label14.Text = "TOTAL YANG ADA DI DALAM \r\nPLAYGROUND : ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRowCount.Location = new System.Drawing.Point(277, 519);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(17, 17);
            this.lblRowCount.TabIndex = 61;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmGateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 799);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGateLog)).EndInit();
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
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvReminder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxDataIO;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtNewRFID;
        private System.Windows.Forms.TextBox txtCurRFID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxReason;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgvGateLog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label label14;
    }
}