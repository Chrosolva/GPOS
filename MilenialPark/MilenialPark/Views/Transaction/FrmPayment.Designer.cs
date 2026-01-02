namespace MilenialPark.Views.Transaction
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRFIDScan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTransaksiDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTransacTiketDet = new System.Windows.Forms.DataGridView();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoUrut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JamMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JamKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaktuBermain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toleransi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxTransType = new System.Windows.Forms.ComboBox();
            this.cbxRemarks = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCardBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksiDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacTiketDet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 63);
            this.panel1.TabIndex = 7;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(8, 18);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(203, 32);
            this.lblFormTitle.TabIndex = 35;
            this.lblFormTitle.Text = "Payment Method";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.txtRFIDScan);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dgvTransaksiDetail);
            this.panel2.Controls.Add(this.dgvTransacTiketDet);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cbxTransType);
            this.panel2.Controls.Add(this.cbxRemarks);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblCardBalance);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.txtCardID);
            this.panel2.Controls.Add(this.lblTransactionID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbxPaymentType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblCustomerName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblCardID2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1688, 561);
            this.panel2.TabIndex = 8;
            // 
            // txtRFIDScan
            // 
            this.txtRFIDScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRFIDScan.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFIDScan.Location = new System.Drawing.Point(660, 21);
            this.txtRFIDScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRFIDScan.Name = "txtRFIDScan";
            this.txtRFIDScan.Size = new System.Drawing.Size(253, 34);
            this.txtRFIDScan.TabIndex = 99;
            this.txtRFIDScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRFIDScan_KeyDown);
            this.txtRFIDScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRFIDScan_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(545, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 28);
            this.label7.TabIndex = 98;
            this.label7.Text = "RFID Scan";
            // 
            // dgvTransaksiDetail
            // 
            this.dgvTransaksiDetail.AllowUserToDeleteRows = false;
            this.dgvTransaksiDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransaksiDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksiDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Price2,
            this.Qty2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvTransaksiDetail.Location = new System.Drawing.Point(536, 331);
            this.dgvTransaksiDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTransaksiDetail.Name = "dgvTransaksiDetail";
            this.dgvTransaksiDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaksiDetail.Size = new System.Drawing.Size(1099, 226);
            this.dgvTransaksiDetail.TabIndex = 97;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TransactionID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "TransactionDate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ItemName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Price2
            // 
            this.Price2.HeaderText = "Price";
            this.Price2.Name = "Price2";
            // 
            // Qty2
            // 
            this.Qty2.HeaderText = "Qty";
            this.Qty2.Name = "Qty2";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "NoUrut";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "OrderStatus";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "JamMasuk";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "JamKeluar";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "WaktuBermain";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Toleransi";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dgvTransacTiketDet
            // 
            this.dgvTransacTiketDet.AllowUserToDeleteRows = false;
            this.dgvTransacTiketDet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransacTiketDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacTiketDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionID,
            this.RFID,
            this.Keterangan,
            this.TransactionDate,
            this.ItemID,
            this.ItemName,
            this.Price,
            this.Qty,
            this.NoUrut,
            this.OrderStatus,
            this.JamMasuk,
            this.JamKeluar,
            this.WaktuBermain,
            this.Toleransi});
            this.dgvTransacTiketDet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTransacTiketDet.Location = new System.Drawing.Point(536, 64);
            this.dgvTransacTiketDet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTransacTiketDet.Name = "dgvTransacTiketDet";
            this.dgvTransacTiketDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransacTiketDet.Size = new System.Drawing.Size(1099, 260);
            this.dgvTransacTiketDet.TabIndex = 96;
            this.dgvTransacTiketDet.SelectionChanged += new System.EventHandler(this.dgvTransacTiketDet_SelectionChanged);
            // 
            // TransactionID
            // 
            this.TransactionID.HeaderText = "TransactionID";
            this.TransactionID.Name = "TransactionID";
            // 
            // RFID
            // 
            this.RFID.HeaderText = "RFID";
            this.RFID.Name = "RFID";
            this.RFID.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            // 
            // TransactionDate
            // 
            this.TransactionDate.HeaderText = "TransactionDate";
            this.TransactionDate.Name = "TransactionDate";
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // NoUrut
            // 
            this.NoUrut.HeaderText = "NoUrut";
            this.NoUrut.Name = "NoUrut";
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "OrderStatus";
            this.OrderStatus.Name = "OrderStatus";
            // 
            // JamMasuk
            // 
            this.JamMasuk.HeaderText = "JamMasuk";
            this.JamMasuk.Name = "JamMasuk";
            // 
            // JamKeluar
            // 
            this.JamKeluar.HeaderText = "JamKeluar";
            this.JamKeluar.Name = "JamKeluar";
            // 
            // WaktuBermain
            // 
            this.WaktuBermain.HeaderText = "WaktuBermain";
            this.WaktuBermain.Name = "WaktuBermain";
            // 
            // Toleransi
            // 
            this.Toleransi.HeaderText = "Toleransi";
            this.Toleransi.Name = "Toleransi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 28);
            this.label12.TabIndex = 95;
            this.label12.Text = "TransactionType";
            // 
            // cbxTransType
            // 
            this.cbxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransType.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTransType.FormattingEnabled = true;
            this.cbxTransType.Items.AddRange(new object[] {
            "WEEKDAY",
            "WEEKEND"});
            this.cbxTransType.Location = new System.Drawing.Point(192, 86);
            this.cbxTransType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTransType.Name = "cbxTransType";
            this.cbxTransType.Size = new System.Drawing.Size(272, 36);
            this.cbxTransType.TabIndex = 94;
            // 
            // cbxRemarks
            // 
            this.cbxRemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRemarks.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRemarks.FormattingEnabled = true;
            this.cbxRemarks.Items.AddRange(new object[] {
            "NONE",
            "QRIS",
            "DEBIT",
            "CASH"});
            this.cbxRemarks.Location = new System.Drawing.Point(24, 366);
            this.cbxRemarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxRemarks.Name = "cbxRemarks";
            this.cbxRemarks.Size = new System.Drawing.Size(137, 36);
            this.cbxRemarks.TabIndex = 93;
            this.cbxRemarks.SelectedIndexChanged += new System.EventHandler(this.cbxRemarks_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(117, 433);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnSave.Size = new System.Drawing.Size(225, 66);
            this.btnSave.TabIndex = 89;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(171, 366);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(294, 34);
            this.txtRemarks.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 331);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 87;
            this.label5.Text = "Remarks";
            // 
            // lblCardBalance
            // 
            this.lblCardBalance.AutoSize = true;
            this.lblCardBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardBalance.Location = new System.Drawing.Point(191, 289);
            this.lblCardBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardBalance.Name = "lblCardBalance";
            this.lblCardBalance.Size = new System.Drawing.Size(23, 28);
            this.lblCardBalance.TabIndex = 86;
            this.lblCardBalance.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 28);
            this.label4.TabIndex = 85;
            this.label4.Text = "Balance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 28);
            this.label6.TabIndex = 84;
            this.label6.Text = "Total ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTotal.Location = new System.Drawing.Point(187, 52);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(23, 28);
            this.lblTotal.TabIndex = 83;
            this.lblTotal.Text = "0";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(24, 201);
            this.txtCardID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(441, 34);
            this.txtCardID.TabIndex = 82;
            this.txtCardID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyUp);
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.Location = new System.Drawing.Point(187, 18);
            this.lblTransactionID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(20, 28);
            this.lblTransactionID.TabIndex = 81;
            this.lblTransactionID.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 28);
            this.label2.TabIndex = 80;
            this.label2.Text = "Transaction ID";
            // 
            // cbxPaymentType
            // 
            this.cbxPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPaymentType.Enabled = false;
            this.cbxPaymentType.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPaymentType.FormattingEnabled = true;
            this.cbxPaymentType.Items.AddRange(new object[] {
            "CARD",
            "MASTER_CARD"});
            this.cbxPaymentType.Location = new System.Drawing.Point(192, 129);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(272, 36);
            this.cbxPaymentType.TabIndex = 79;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 28);
            this.label3.TabIndex = 78;
            this.label3.Text = "Payment Type";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(187, 252);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(20, 28);
            this.lblCustomerName.TabIndex = 61;
            this.lblCustomerName.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 252);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 28);
            this.label1.TabIndex = 48;
            this.label1.Text = "Customer Name";
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(19, 166);
            this.lblCardID2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(77, 28);
            this.lblCardID2.TabIndex = 46;
            this.lblCardID2.Text = "Card ID";
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPayment";
            this.Text = "FrmPayment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksiDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacTiketDet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblCustomerName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.Label lblTransactionID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbxPaymentType;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox txtCardID;
        public System.Windows.Forms.Label lblCardBalance;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtRemarks;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cbxRemarks;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbxTransType;
        private System.Windows.Forms.DataGridView dgvTransacTiketDet;
        private System.Windows.Forms.DataGridView dgvTransaksiDetail;
        public System.Windows.Forms.TextBox txtRFIDScan;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoUrut;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn JamMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn JamKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaktuBermain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toleransi;
    }
}