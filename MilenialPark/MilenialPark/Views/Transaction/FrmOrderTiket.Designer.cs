namespace MilenialPark.Views.Transaction
{
    partial class FrmOrderTiket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrderTiket));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.leftbottompanel = new System.Windows.Forms.Panel();
            this.dgvTransTiket = new System.Windows.Forms.DataGridView();
            this.leftuppanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxUserID = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChkTicket = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTransType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxOption = new System.Windows.Forms.ComboBox();
            this.btnPrintStruk = new System.Windows.Forms.Button();
            this.btnPrintQR = new System.Windows.Forms.Button();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.lblrow = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.rightbottompanel = new System.Windows.Forms.Panel();
            this.dgvTransTiketDetail = new System.Windows.Forms.DataGridView();
            this.leftpanel.SuspendLayout();
            this.leftbottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransTiket)).BeginInit();
            this.leftuppanel.SuspendLayout();
            this.rightpanel.SuspendLayout();
            this.rightbottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransTiketDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // leftpanel
            // 
            this.leftpanel.AutoScroll = true;
            this.leftpanel.Controls.Add(this.leftbottompanel);
            this.leftpanel.Controls.Add(this.leftuppanel);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftpanel.Location = new System.Drawing.Point(0, 0);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(1311, 312);
            this.leftpanel.TabIndex = 0;
            // 
            // leftbottompanel
            // 
            this.leftbottompanel.Controls.Add(this.dgvTransTiket);
            this.leftbottompanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftbottompanel.Location = new System.Drawing.Point(0, 112);
            this.leftbottompanel.Name = "leftbottompanel";
            this.leftbottompanel.Padding = new System.Windows.Forms.Padding(10, 2, 10, 10);
            this.leftbottompanel.Size = new System.Drawing.Size(1311, 200);
            this.leftbottompanel.TabIndex = 19;
            // 
            // dgvTransTiket
            // 
            this.dgvTransTiket.AllowUserToAddRows = false;
            this.dgvTransTiket.AllowUserToDeleteRows = false;
            this.dgvTransTiket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTransTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransTiket.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransTiket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransTiket.Location = new System.Drawing.Point(10, 2);
            this.dgvTransTiket.Name = "dgvTransTiket";
            this.dgvTransTiket.ReadOnly = true;
            this.dgvTransTiket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransTiket.Size = new System.Drawing.Size(1291, 188);
            this.dgvTransTiket.TabIndex = 18;
            this.dgvTransTiket.SelectionChanged += new System.EventHandler(this.dgvTransTiket_SelectionChanged);
            // 
            // leftuppanel
            // 
            this.leftuppanel.Controls.Add(this.label3);
            this.leftuppanel.Controls.Add(this.cbxUserID);
            this.leftuppanel.Controls.Add(this.btnCancel);
            this.leftuppanel.Controls.Add(this.btnChkTicket);
            this.leftuppanel.Controls.Add(this.btnPreview);
            this.leftuppanel.Controls.Add(this.label4);
            this.leftuppanel.Controls.Add(this.cbxTransType);
            this.leftuppanel.Controls.Add(this.label2);
            this.leftuppanel.Controls.Add(this.label1);
            this.leftuppanel.Controls.Add(this.cbxOption);
            this.leftuppanel.Controls.Add(this.btnPrintStruk);
            this.leftuppanel.Controls.Add(this.btnPrintQR);
            this.leftuppanel.Controls.Add(this.txtCardID);
            this.leftuppanel.Controls.Add(this.lblrow);
            this.leftuppanel.Controls.Add(this.label9);
            this.leftuppanel.Controls.Add(this.btnFilter);
            this.leftuppanel.Controls.Add(this.dtpTo);
            this.leftuppanel.Controls.Add(this.dtpFrom);
            this.leftuppanel.Controls.Add(this.label8);
            this.leftuppanel.Controls.Add(this.label7);
            this.leftuppanel.Controls.Add(this.btnDelete);
            this.leftuppanel.Controls.Add(this.btnCreate);
            this.leftuppanel.Controls.Add(this.btnEdit);
            this.leftuppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftuppanel.Location = new System.Drawing.Point(0, 0);
            this.leftuppanel.Name = "leftuppanel";
            this.leftuppanel.Size = new System.Drawing.Size(1311, 112);
            this.leftuppanel.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(840, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 80;
            this.label3.Text = "User ID";
            // 
            // cbxUserID
            // 
            this.cbxUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUserID.FormattingEnabled = true;
            this.cbxUserID.Items.AddRange(new object[] {
            "ALL",
            "WEEKDAY",
            "WEEKEND",
            "ACTIVITY",
            "TOP-UP"});
            this.cbxUserID.Location = new System.Drawing.Point(842, 51);
            this.cbxUserID.Name = "cbxUserID";
            this.cbxUserID.Size = new System.Drawing.Size(134, 29);
            this.cbxUserID.TabIndex = 79;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCancel.Location = new System.Drawing.Point(1171, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCancel.Size = new System.Drawing.Size(91, 54);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChkTicket
            // 
            this.btnChkTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnChkTicket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChkTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChkTicket.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChkTicket.ForeColor = System.Drawing.Color.White;
            this.btnChkTicket.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnChkTicket.Location = new System.Drawing.Point(1202, 12);
            this.btnChkTicket.Name = "btnChkTicket";
            this.btnChkTicket.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnChkTicket.Size = new System.Drawing.Size(130, 54);
            this.btnChkTicket.TabIndex = 76;
            this.btnChkTicket.Text = "CHECK TICKET";
            this.btnChkTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChkTicket.UseVisualStyleBackColor = false;
            this.btnChkTicket.Visible = false;
            this.btnChkTicket.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPreview.Location = new System.Drawing.Point(1187, 28);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnPreview.Size = new System.Drawing.Size(88, 54);
            this.btnPreview.TabIndex = 75;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(735, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 74;
            this.label4.Text = "Type";
            // 
            // cbxTransType
            // 
            this.cbxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransType.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTransType.FormattingEnabled = true;
            this.cbxTransType.Items.AddRange(new object[] {
            "ALL",
            "WEEKDAY",
            "WEEKEND",
            "TOP-UP",
            "ACTIVITY"});
            this.cbxTransType.Location = new System.Drawing.Point(729, 52);
            this.cbxTransType.Name = "cbxTransType";
            this.cbxTransType.Size = new System.Drawing.Size(108, 29);
            this.cbxTransType.TabIndex = 73;
            this.cbxTransType.SelectedIndexChanged += new System.EventHandler(this.cbxTransType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(612, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 56;
            this.label2.Text = "Option";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 55;
            this.label1.Text = "Keyword";
            // 
            // cbxOption
            // 
            this.cbxOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOption.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOption.FormattingEnabled = true;
            this.cbxOption.Items.AddRange(new object[] {
            "CardID",
            "TransactionID"});
            this.cbxOption.Location = new System.Drawing.Point(606, 52);
            this.cbxOption.Name = "cbxOption";
            this.cbxOption.Size = new System.Drawing.Size(108, 29);
            this.cbxOption.TabIndex = 54;
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
            this.btnPrintStruk.Location = new System.Drawing.Point(1115, 28);
            this.btnPrintStruk.Name = "btnPrintStruk";
            this.btnPrintStruk.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnPrintStruk.Size = new System.Drawing.Size(104, 54);
            this.btnPrintStruk.TabIndex = 52;
            this.btnPrintStruk.Text = "PRINT";
            this.btnPrintStruk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintStruk.UseVisualStyleBackColor = false;
            this.btnPrintStruk.Visible = false;
            this.btnPrintStruk.Click += new System.EventHandler(this.btnPrintStruk_Click);
            // 
            // btnPrintQR
            // 
            this.btnPrintQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnPrintQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintQR.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintQR.ForeColor = System.Drawing.Color.White;
            this.btnPrintQR.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintQR.Image")));
            this.btnPrintQR.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPrintQR.Location = new System.Drawing.Point(1227, 28);
            this.btnPrintQR.Name = "btnPrintQR";
            this.btnPrintQR.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnPrintQR.Size = new System.Drawing.Size(84, 54);
            this.btnPrintQR.TabIndex = 51;
            this.btnPrintQR.Text = "QR";
            this.btnPrintQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintQR.UseVisualStyleBackColor = false;
            this.btnPrintQR.Visible = false;
            this.btnPrintQR.Click += new System.EventHandler(this.btnPrintQR_Click);
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(398, 53);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(202, 29);
            this.txtCardID.TabIndex = 50;
            this.txtCardID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyUp);
            // 
            // lblrow
            // 
            this.lblrow.AutoSize = true;
            this.lblrow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrow.Location = new System.Drawing.Point(7, 90);
            this.lblrow.Name = "lblrow";
            this.lblrow.Size = new System.Drawing.Size(98, 21);
            this.lblrow.TabIndex = 37;
            this.lblrow.Text = "Row Count : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(987, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 21);
            this.label9.TabIndex = 45;
            this.label9.Text = "Filter";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.White;
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Gray;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(991, 44);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnFilter.Size = new System.Drawing.Size(45, 44);
            this.btnFilter.TabIndex = 40;
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/M/yyyy HH:mm:ss tt";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(207, 52);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(185, 25);
            this.dtpTo.TabIndex = 44;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/M/yyyy HH:mm:ss tt";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(10, 52);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(185, 25);
            this.dtpFrom.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(203, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 21);
            this.label8.TabIndex = 42;
            this.label8.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 41;
            this.label7.Text = "From";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(1106, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnDelete.Size = new System.Drawing.Size(113, 54);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCreate.Location = new System.Drawing.Point(1052, 28);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCreate.Size = new System.Drawing.Size(113, 54);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEdit.Location = new System.Drawing.Point(1064, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnEdit.Size = new System.Drawing.Size(117, 54);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Adjust";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // rightpanel
            // 
            this.rightpanel.AutoScroll = true;
            this.rightpanel.Controls.Add(this.rightbottompanel);
            this.rightpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightpanel.Location = new System.Drawing.Point(0, 312);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(1311, 341);
            this.rightpanel.TabIndex = 1;
            // 
            // rightbottompanel
            // 
            this.rightbottompanel.Controls.Add(this.dgvTransTiketDetail);
            this.rightbottompanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightbottompanel.Location = new System.Drawing.Point(0, 0);
            this.rightbottompanel.Name = "rightbottompanel";
            this.rightbottompanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.rightbottompanel.Size = new System.Drawing.Size(1311, 341);
            this.rightbottompanel.TabIndex = 5;
            // 
            // dgvTransTiketDetail
            // 
            this.dgvTransTiketDetail.AllowUserToAddRows = false;
            this.dgvTransTiketDetail.AllowUserToDeleteRows = false;
            this.dgvTransTiketDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTransTiketDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransTiketDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransTiketDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransTiketDetail.Location = new System.Drawing.Point(10, 5);
            this.dgvTransTiketDetail.Name = "dgvTransTiketDetail";
            this.dgvTransTiketDetail.ReadOnly = true;
            this.dgvTransTiketDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransTiketDetail.Size = new System.Drawing.Size(1291, 326);
            this.dgvTransTiketDetail.TabIndex = 19;
            // 
            // FrmOrderTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 653);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.leftpanel);
            this.Name = "FrmOrderTiket";
            this.Text = "FrmOrderTiket";
            this.Load += new System.EventHandler(this.FrmOrderTiket_Load);
            this.leftpanel.ResumeLayout(false);
            this.leftbottompanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransTiket)).EndInit();
            this.leftuppanel.ResumeLayout(false);
            this.leftuppanel.PerformLayout();
            this.rightpanel.ResumeLayout(false);
            this.rightbottompanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransTiketDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.Panel leftbottompanel;
        private System.Windows.Forms.DataGridView dgvTransTiket;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.Panel rightbottompanel;
        private System.Windows.Forms.DataGridView dgvTransTiketDetail;
        private System.Windows.Forms.Panel leftuppanel;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbxTransType;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbxOption;
        private System.Windows.Forms.Button btnPrintStruk;
        private System.Windows.Forms.Button btnPrintQR;
        public System.Windows.Forms.TextBox txtCardID;
        public System.Windows.Forms.Label lblrow;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnChkTicket;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbxUserID;
    }
}