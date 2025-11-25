namespace MilenialPark.Views.Transaction
{
    partial class FrmNEOrderTiket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNEOrderTiket));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblFinalTotalAmount = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.lblIdentity = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCardID = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxTransType = new System.Windows.Forms.ComboBox();
            this.NUDToleransi = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.NUDWaktuBermain = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTransacTiketDet = new System.Windows.Forms.DataGridView();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblItemID = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.NUDPPN = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NUDQty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NUDTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.lblShopID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddorEdit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NUDprice = new System.Windows.Forms.NumericUpDown();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.lblCardID2 = new System.Windows.Forms.Label();
            this.cbxRemarks = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDToleransi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWaktuBermain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacTiketDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDprice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFormTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 33);
            this.panel1.TabIndex = 5;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(6, 7);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(49, 25);
            this.lblFormTitle.TabIndex = 35;
            this.lblFormTitle.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.cbxRemarks);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblNote);
            this.panel2.Controls.Add(this.lblFinalTotalAmount);
            this.panel2.Controls.Add(this.lblRowCount);
            this.panel2.Controls.Add(this.lblIdentity);
            this.panel2.Controls.Add(this.lblCustomerName);
            this.panel2.Controls.Add(this.lblCardID);
            this.panel2.Controls.Add(this.txtCardID);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cbxTransType);
            this.panel2.Controls.Add(this.NUDToleransi);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.NUDWaktuBermain);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dgvTransacTiketDet);
            this.panel2.Controls.Add(this.lblItemID);
            this.panel2.Controls.Add(this.cbxPaymentType);
            this.panel2.Controls.Add(this.NUDPPN);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblBalance);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.NUDQty);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.NUDTotalAmount);
            this.panel2.Controls.Add(this.lblShopID);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnAddorEdit);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.NUDprice);
            this.panel2.Controls.Add(this.cbxCategory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtItemDesc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtItemName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTransactionID);
            this.panel2.Controls.Add(this.lblCardID2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1229, 743);
            this.panel2.TabIndex = 6;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(134, 680);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(283, 29);
            this.txtRemarks.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 656);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 21);
            this.label13.TabIndex = 90;
            this.label13.Text = "Remarks";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(422, 175);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(51, 19);
            this.lblNote.TabIndex = 89;
            this.lblNote.Text = "Note : ";
            this.lblNote.Visible = false;
            // 
            // lblFinalTotalAmount
            // 
            this.lblFinalTotalAmount.AutoSize = true;
            this.lblFinalTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalTotalAmount.Location = new System.Drawing.Point(519, 623);
            this.lblFinalTotalAmount.Name = "lblFinalTotalAmount";
            this.lblFinalTotalAmount.Size = new System.Drawing.Size(167, 21);
            this.lblFinalTotalAmount.TabIndex = 88;
            this.lblFinalTotalAmount.Text = "Final Total Amount : ";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(487, 71);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(90, 21);
            this.lblRowCount.TabIndex = 87;
            this.lblRowCount.Text = "Total Tiket : ";
            // 
            // lblIdentity
            // 
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentity.ForeColor = System.Drawing.Color.Black;
            this.lblIdentity.Location = new System.Drawing.Point(13, 154);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new System.Drawing.Size(132, 21);
            this.lblIdentity.TabIndex = 73;
            this.lblIdentity.Text = "No (KTP/SIM) : - ";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(13, 131);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(71, 21);
            this.lblCustomerName.TabIndex = 72;
            this.lblCustomerName.Text = "Name : -";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSize = true;
            this.lblCardID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID.ForeColor = System.Drawing.Color.Black;
            this.lblCardID.Location = new System.Drawing.Point(13, 110);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(82, 21);
            this.lblCardID.TabIndex = 71;
            this.lblCardID.Text = "Card ID : -";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(16, 78);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(395, 29);
            this.txtCardID.TabIndex = 69;
            this.txtCardID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyUp);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(15, 49);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(251, 23);
            this.label.TabIndex = 70;
            this.label.Text = "Scan Card ID Here  / Type Here";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(523, 656);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7);
            this.btnSave.Size = new System.Drawing.Size(113, 54);
            this.btnSave.TabIndex = 86;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 21);
            this.label12.TabIndex = 85;
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
            this.cbxTransType.Location = new System.Drawing.Point(141, 17);
            this.cbxTransType.Name = "cbxTransType";
            this.cbxTransType.Size = new System.Drawing.Size(181, 29);
            this.cbxTransType.TabIndex = 84;
            this.cbxTransType.SelectedIndexChanged += new System.EventHandler(this.cbxTransType_SelectedIndexChanged);
            // 
            // NUDToleransi
            // 
            this.NUDToleransi.Enabled = false;
            this.NUDToleransi.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDToleransi.Location = new System.Drawing.Point(330, 564);
            this.NUDToleransi.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDToleransi.Name = "NUDToleransi";
            this.NUDToleransi.Size = new System.Drawing.Size(83, 32);
            this.NUDToleransi.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(288, 540);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 21);
            this.label11.TabIndex = 82;
            this.label11.Text = "Toleransi ( Menit)";
            // 
            // NUDWaktuBermain
            // 
            this.NUDWaktuBermain.Enabled = false;
            this.NUDWaktuBermain.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDWaktuBermain.Location = new System.Drawing.Point(18, 564);
            this.NUDWaktuBermain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDWaktuBermain.Name = "NUDWaktuBermain";
            this.NUDWaktuBermain.Size = new System.Drawing.Size(83, 32);
            this.NUDWaktuBermain.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 540);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 21);
            this.label7.TabIndex = 80;
            this.label7.Text = "Waktu Bermain {Jam}";
            // 
            // dgvTransacTiketDet
            // 
            this.dgvTransacTiketDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacTiketDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionID,
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
            this.dgvTransacTiketDet.Location = new System.Drawing.Point(479, 110);
            this.dgvTransacTiketDet.Name = "dgvTransacTiketDet";
            this.dgvTransacTiketDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransacTiketDet.Size = new System.Drawing.Size(738, 487);
            this.dgvTransacTiketDet.TabIndex = 79;
            this.dgvTransacTiketDet.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTransacTiketDet_RowsRemoved);
            // 
            // TransactionID
            // 
            this.TransactionID.HeaderText = "TransactionID";
            this.TransactionID.Name = "TransactionID";
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
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.Location = new System.Drawing.Point(137, 283);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(60, 21);
            this.lblItemID.TabIndex = 78;
            this.lblItemID.Text = "Item ID";
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
            this.cbxPaymentType.Location = new System.Drawing.Point(459, 17);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(205, 29);
            this.cbxPaymentType.TabIndex = 77;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // NUDPPN
            // 
            this.NUDPPN.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDPPN.Location = new System.Drawing.Point(330, 502);
            this.NUDPPN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDPPN.Name = "NUDPPN";
            this.NUDPPN.Size = new System.Drawing.Size(83, 32);
            this.NUDPPN.TabIndex = 76;
            this.NUDPPN.Visible = false;
            this.NUDPPN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUDQty_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(326, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 21);
            this.label10.TabIndex = 75;
            this.label10.Text = "PPN ( % )";
            this.label10.Visible = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(13, 175);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(171, 21);
            this.lblBalance.TabIndex = 74;
            this.lblBalance.Text = "Balance (Saldo)  : Rp. -";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 478);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 21);
            this.label9.TabIndex = 68;
            this.label9.Text = "Qty";
            // 
            // NUDQty
            // 
            this.NUDQty.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDQty.Location = new System.Drawing.Point(17, 502);
            this.NUDQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDQty.Name = "NUDQty";
            this.NUDQty.Size = new System.Drawing.Size(83, 32);
            this.NUDQty.TabIndex = 67;
            this.NUDQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUDQty_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 599);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 66;
            this.label5.Text = "Total Amount";
            // 
            // NUDTotalAmount
            // 
            this.NUDTotalAmount.Enabled = false;
            this.NUDTotalAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDTotalAmount.Location = new System.Drawing.Point(21, 623);
            this.NUDTotalAmount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NUDTotalAmount.Name = "NUDTotalAmount";
            this.NUDTotalAmount.Size = new System.Drawing.Size(396, 32);
            this.NUDTotalAmount.TabIndex = 65;
            this.NUDTotalAmount.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopID.Location = new System.Drawing.Point(130, 227);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(16, 21);
            this.lblShopID.TabIndex = 64;
            this.lblShopID.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 21);
            this.label8.TabIndex = 63;
            this.label8.Text = "Supervisor ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 21);
            this.label6.TabIndex = 62;
            this.label6.Text = "choose package";
            // 
            // btnAddorEdit
            // 
            this.btnAddorEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnAddorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddorEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddorEdit.ForeColor = System.Drawing.Color.White;
            this.btnAddorEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnAddorEdit.Image")));
            this.btnAddorEdit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAddorEdit.Location = new System.Drawing.Point(1104, 656);
            this.btnAddorEdit.Name = "btnAddorEdit";
            this.btnAddorEdit.Padding = new System.Windows.Forms.Padding(7);
            this.btnAddorEdit.Size = new System.Drawing.Size(113, 54);
            this.btnAddorEdit.TabIndex = 60;
            this.btnAddorEdit.Text = "Create";
            this.btnAddorEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddorEdit.UseVisualStyleBackColor = false;
            this.btnAddorEdit.Click += new System.EventHandler(this.btnAddorEdit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Price";
            // 
            // NUDprice
            // 
            this.NUDprice.Enabled = false;
            this.NUDprice.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDprice.Location = new System.Drawing.Point(19, 439);
            this.NUDprice.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NUDprice.Name = "NUDprice";
            this.NUDprice.Size = new System.Drawing.Size(396, 32);
            this.NUDprice.TabIndex = 54;
            this.NUDprice.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(141, 251);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(205, 29);
            this.cbxCategory.TabIndex = 53;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 52;
            this.label3.Text = "Payment Type";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDesc.Location = new System.Drawing.Point(19, 382);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(396, 29);
            this.txtItemDesc.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Item Description";
            // 
            // txtItemName
            // 
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Enabled = false;
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(20, 328);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(395, 29);
            this.txtItemName.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "Item Name";
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.Location = new System.Drawing.Point(130, 206);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(16, 21);
            this.lblTransactionID.TabIndex = 47;
            this.lblTransactionID.Text = "-";
            // 
            // lblCardID2
            // 
            this.lblCardID2.AutoSize = true;
            this.lblCardID2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID2.Location = new System.Drawing.Point(12, 206);
            this.lblCardID2.Name = "lblCardID2";
            this.lblCardID2.Size = new System.Drawing.Size(108, 21);
            this.lblCardID2.TabIndex = 46;
            this.lblCardID2.Text = "Transaction ID";
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
            this.cbxRemarks.Location = new System.Drawing.Point(16, 681);
            this.cbxRemarks.Name = "cbxRemarks";
            this.cbxRemarks.Size = new System.Drawing.Size(104, 29);
            this.cbxRemarks.TabIndex = 92;
            this.cbxRemarks.SelectedIndexChanged += new System.EventHandler(this.cbxRemarks_SelectedIndexChanged);
            // 
            // FrmNEOrderTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 776);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNEOrderTiket";
            this.Text = "FrmNEOrderTiket";
            this.Load += new System.EventHandler(this.FrmNEOrderTiket_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDToleransi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWaktuBermain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacTiketDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDprice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnAddorEdit;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUDprice;
        public System.Windows.Forms.ComboBox cbxCategory;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtItemDesc;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtItemName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTransactionID;
        public System.Windows.Forms.Label lblCardID2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblShopID;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NUDQty;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUDTotalAmount;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.NumericUpDown NUDPPN;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblIdentity;
        public System.Windows.Forms.Label lblCustomerName;
        public System.Windows.Forms.Label lblCardID;
        public System.Windows.Forms.ComboBox cbxPaymentType;
        public System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.DataGridView dgvTransacTiketDet;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
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
        private System.Windows.Forms.NumericUpDown NUDToleransi;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown NUDWaktuBermain;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toleransi;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbxTransType;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblRowCount;
        public System.Windows.Forms.Label lblFinalTotalAmount;
        public System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.TextBox txtRemarks;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cbxRemarks;
    }
}