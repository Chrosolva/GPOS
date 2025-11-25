namespace MilenialPark.Views.Transaction
{
    partial class FrmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrder));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.FLMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.leftupPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.ordertabs = new System.Windows.Forms.TabControl();
            this.TPPlaceOrder = new System.Windows.Forms.TabPage();
            this.FLNewOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.rightbottompanel = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPPN = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPPN = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panellabel1 = new System.Windows.Forms.Panel();
            this.lblNewOrder = new System.Windows.Forms.Label();
            this.TPCardTransaction = new System.Windows.Forms.TabPage();
            this.FLCardTransList = new System.Windows.Forms.FlowLayoutPanel();
            this.cardGradientPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblIdentity = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCardID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnFilter2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxTransType = new System.Windows.Forms.ComboBox();
            this.leftPanel.SuspendLayout();
            this.leftupPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.ordertabs.SuspendLayout();
            this.TPPlaceOrder.SuspendLayout();
            this.rightbottompanel.SuspendLayout();
            this.panellabel1.SuspendLayout();
            this.TPCardTransaction.SuspendLayout();
            this.cardGradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.FLMenu);
            this.leftPanel.Controls.Add(this.leftupPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(656, 560);
            this.leftPanel.TabIndex = 0;
            // 
            // FLMenu
            // 
            this.FLMenu.AutoScroll = true;
            this.FLMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLMenu.Location = new System.Drawing.Point(0, 57);
            this.FLMenu.Name = "FLMenu";
            this.FLMenu.Size = new System.Drawing.Size(656, 503);
            this.FLMenu.TabIndex = 1;
            // 
            // leftupPanel
            // 
            this.leftupPanel.Controls.Add(this.label12);
            this.leftupPanel.Controls.Add(this.cbxTransType);
            this.leftupPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftupPanel.Location = new System.Drawing.Point(0, 0);
            this.leftupPanel.Name = "leftupPanel";
            this.leftupPanel.Size = new System.Drawing.Size(656, 57);
            this.leftupPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.ordertabs);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(656, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new System.Windows.Forms.Padding(7);
            this.rightPanel.Size = new System.Drawing.Size(421, 560);
            this.rightPanel.TabIndex = 1;
            // 
            // ordertabs
            // 
            this.ordertabs.Controls.Add(this.TPPlaceOrder);
            this.ordertabs.Controls.Add(this.TPCardTransaction);
            this.ordertabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordertabs.Location = new System.Drawing.Point(7, 7);
            this.ordertabs.Name = "ordertabs";
            this.ordertabs.SelectedIndex = 0;
            this.ordertabs.Size = new System.Drawing.Size(407, 546);
            this.ordertabs.TabIndex = 0;
            // 
            // TPPlaceOrder
            // 
            this.TPPlaceOrder.Controls.Add(this.FLNewOrder);
            this.TPPlaceOrder.Controls.Add(this.rightbottompanel);
            this.TPPlaceOrder.Controls.Add(this.panellabel1);
            this.TPPlaceOrder.Location = new System.Drawing.Point(4, 22);
            this.TPPlaceOrder.Name = "TPPlaceOrder";
            this.TPPlaceOrder.Padding = new System.Windows.Forms.Padding(3);
            this.TPPlaceOrder.Size = new System.Drawing.Size(399, 520);
            this.TPPlaceOrder.TabIndex = 0;
            this.TPPlaceOrder.Text = "PlaceOrder";
            this.TPPlaceOrder.UseVisualStyleBackColor = true;
            // 
            // FLNewOrder
            // 
            this.FLNewOrder.AutoScroll = true;
            this.FLNewOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLNewOrder.Location = new System.Drawing.Point(3, 54);
            this.FLNewOrder.Name = "FLNewOrder";
            this.FLNewOrder.Size = new System.Drawing.Size(393, 287);
            this.FLNewOrder.TabIndex = 19;
            // 
            // rightbottompanel
            // 
            this.rightbottompanel.BackColor = System.Drawing.Color.White;
            this.rightbottompanel.Controls.Add(this.btnPay);
            this.rightbottompanel.Controls.Add(this.lblTotal);
            this.rightbottompanel.Controls.Add(this.lblPPN);
            this.rightbottompanel.Controls.Add(this.lblSubtotal);
            this.rightbottompanel.Controls.Add(this.label1);
            this.rightbottompanel.Controls.Add(this.chkPPN);
            this.rightbottompanel.Controls.Add(this.label4);
            this.rightbottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rightbottompanel.Location = new System.Drawing.Point(3, 341);
            this.rightbottompanel.Name = "rightbottompanel";
            this.rightbottompanel.Size = new System.Drawing.Size(393, 176);
            this.rightbottompanel.TabIndex = 20;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTotal.Location = new System.Drawing.Point(285, 83);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 21);
            this.lblTotal.TabIndex = 61;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPPN
            // 
            this.lblPPN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPPN.AutoSize = true;
            this.lblPPN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPN.Location = new System.Drawing.Point(285, 47);
            this.lblPPN.Name = "lblPPN";
            this.lblPPN.Size = new System.Drawing.Size(19, 21);
            this.lblPPN.TabIndex = 60;
            this.lblPPN.Text = "0";
            this.lblPPN.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPPN.Visible = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(285, 14);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(19, 21);
            this.lblSubtotal.TabIndex = 59;
            this.lblSubtotal.Text = "0";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 58;
            this.label1.Text = "Total";
            // 
            // chkPPN
            // 
            this.chkPPN.AutoSize = true;
            this.chkPPN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPPN.Location = new System.Drawing.Point(17, 47);
            this.chkPPN.Name = "chkPPN";
            this.chkPPN.Size = new System.Drawing.Size(80, 21);
            this.chkPPN.TabIndex = 57;
            this.chkPPN.Text = "PPN 11%";
            this.chkPPN.UseVisualStyleBackColor = true;
            this.chkPPN.Visible = false;
            this.chkPPN.CheckedChanged += new System.EventHandler(this.chkPPN_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "Subtotal";
            // 
            // panellabel1
            // 
            this.panellabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.panellabel1.Controls.Add(this.lblNewOrder);
            this.panellabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellabel1.Location = new System.Drawing.Point(3, 3);
            this.panellabel1.Name = "panellabel1";
            this.panellabel1.Size = new System.Drawing.Size(393, 51);
            this.panellabel1.TabIndex = 18;
            // 
            // lblNewOrder
            // 
            this.lblNewOrder.AutoSize = true;
            this.lblNewOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrder.ForeColor = System.Drawing.Color.White;
            this.lblNewOrder.Location = new System.Drawing.Point(12, 15);
            this.lblNewOrder.Name = "lblNewOrder";
            this.lblNewOrder.Size = new System.Drawing.Size(105, 25);
            this.lblNewOrder.TabIndex = 24;
            this.lblNewOrder.Text = "New Order";
            // 
            // TPCardTransaction
            // 
            this.TPCardTransaction.Controls.Add(this.FLCardTransList);
            this.TPCardTransaction.Controls.Add(this.cardGradientPanel);
            this.TPCardTransaction.Location = new System.Drawing.Point(4, 22);
            this.TPCardTransaction.Name = "TPCardTransaction";
            this.TPCardTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.TPCardTransaction.Size = new System.Drawing.Size(396, 520);
            this.TPCardTransaction.TabIndex = 1;
            this.TPCardTransaction.Text = "Card Transaction";
            this.TPCardTransaction.UseVisualStyleBackColor = true;
            // 
            // FLCardTransList
            // 
            this.FLCardTransList.AutoScroll = true;
            this.FLCardTransList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLCardTransList.Location = new System.Drawing.Point(3, 299);
            this.FLCardTransList.Name = "FLCardTransList";
            this.FLCardTransList.Size = new System.Drawing.Size(390, 218);
            this.FLCardTransList.TabIndex = 2;
            // 
            // cardGradientPanel
            // 
            this.cardGradientPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.cardGradientPanel.Controls.Add(this.label9);
            this.cardGradientPanel.Controls.Add(this.lblBalance);
            this.cardGradientPanel.Controls.Add(this.btnFilter2);
            this.cardGradientPanel.Controls.Add(this.lblIdentity);
            this.cardGradientPanel.Controls.Add(this.dtpTo);
            this.cardGradientPanel.Controls.Add(this.dtpFrom);
            this.cardGradientPanel.Controls.Add(this.lblCustomerName);
            this.cardGradientPanel.Controls.Add(this.label8);
            this.cardGradientPanel.Controls.Add(this.lblCardID);
            this.cardGradientPanel.Controls.Add(this.label7);
            this.cardGradientPanel.Controls.Add(this.label);
            this.cardGradientPanel.Controls.Add(this.txtCardID);
            this.cardGradientPanel.Controls.Add(this.pictureBox1);
            this.cardGradientPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardGradientPanel.Location = new System.Drawing.Point(3, 3);
            this.cardGradientPanel.Name = "cardGradientPanel";
            this.cardGradientPanel.Size = new System.Drawing.Size(390, 296);
            this.cardGradientPanel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(393, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 21);
            this.label9.TabIndex = 45;
            this.label9.Text = "Filter";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(26, 251);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(171, 21);
            this.lblBalance.TabIndex = 33;
            this.lblBalance.Text = "Balance (Saldo)  : Rp. -";
            // 
            // lblIdentity
            // 
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentity.ForeColor = System.Drawing.Color.White;
            this.lblIdentity.Location = new System.Drawing.Point(26, 224);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new System.Drawing.Size(132, 21);
            this.lblIdentity.TabIndex = 32;
            this.lblIdentity.Text = "No (KTP/SIM) : - ";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/M/yyyy HH:mm:ss tt";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(206, 122);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(185, 25);
            this.dtpTo.TabIndex = 44;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/M/yyyy HH:mm:ss tt";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(9, 122);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(185, 25);
            this.dtpFrom.TabIndex = 43;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(25, 199);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(71, 21);
            this.lblCustomerName.TabIndex = 31;
            this.lblCustomerName.Text = "Name : -";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(202, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 21);
            this.label8.TabIndex = 42;
            this.label8.Text = "To";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSize = true;
            this.lblCardID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardID.ForeColor = System.Drawing.Color.White;
            this.lblCardID.Location = new System.Drawing.Point(25, 173);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(82, 21);
            this.lblCardID.TabIndex = 30;
            this.lblCardID.Text = "Card ID : -";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 41;
            this.label7.Text = "From";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(79, 17);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(251, 23);
            this.label.TabIndex = 29;
            this.label.Text = "Scan Card ID Here  / Type Here";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(83, 43);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(327, 29);
            this.txtCardID.TabIndex = 28;
            this.txtCardID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyUp);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(85)))));
            this.btnPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.Image")));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPay.Location = new System.Drawing.Point(122, 105);
            this.btnPay.Name = "btnPay";
            this.btnPay.Padding = new System.Windows.Forms.Padding(7);
            this.btnPay.Size = new System.Drawing.Size(133, 58);
            this.btnPay.TabIndex = 62;
            this.btnPay.Text = "Pay Now";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click_1);
            // 
            // btnFilter2
            // 
            this.btnFilter2.BackColor = System.Drawing.Color.White;
            this.btnFilter2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter2.ForeColor = System.Drawing.Color.Gray;
            this.btnFilter2.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter2.Image")));
            this.btnFilter2.Location = new System.Drawing.Point(397, 114);
            this.btnFilter2.Name = "btnFilter2";
            this.btnFilter2.Padding = new System.Windows.Forms.Padding(7);
            this.btnFilter2.Size = new System.Drawing.Size(45, 44);
            this.btnFilter2.TabIndex = 40;
            this.btnFilter2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFilter2.UseVisualStyleBackColor = false;
            this.btnFilter2.Click += new System.EventHandler(this.btnFilter2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 21);
            this.label12.TabIndex = 89;
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
            this.cbxTransType.Location = new System.Drawing.Point(132, 12);
            this.cbxTransType.Name = "cbxTransType";
            this.cbxTransType.Size = new System.Drawing.Size(181, 29);
            this.cbxTransType.TabIndex = 88;
            this.cbxTransType.SelectedIndexChanged += new System.EventHandler(this.cbxTransType_SelectedIndexChanged);
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 560);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.Name = "FrmOrder";
            this.Text = "FrmOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrder_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            this.leftPanel.ResumeLayout(false);
            this.leftupPanel.ResumeLayout(false);
            this.leftupPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.ordertabs.ResumeLayout(false);
            this.TPPlaceOrder.ResumeLayout(false);
            this.rightbottompanel.ResumeLayout(false);
            this.rightbottompanel.PerformLayout();
            this.panellabel1.ResumeLayout(false);
            this.panellabel1.PerformLayout();
            this.TPCardTransaction.ResumeLayout(false);
            this.cardGradientPanel.ResumeLayout(false);
            this.cardGradientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.FlowLayoutPanel FLMenu;
        private System.Windows.Forms.Panel leftupPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TabControl ordertabs;
        private System.Windows.Forms.TabPage TPPlaceOrder;
        private System.Windows.Forms.TabPage TPCardTransaction;
        private System.Windows.Forms.Panel panellabel1;
        public System.Windows.Forms.Label lblNewOrder;
        private System.Windows.Forms.FlowLayoutPanel FLNewOrder;
        private System.Windows.Forms.Panel rightbottompanel;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPPN;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblPPN;
        public System.Windows.Forms.Label lblSubtotal;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel cardGradientPanel;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.Label lblIdentity;
        public System.Windows.Forms.Label lblCustomerName;
        public System.Windows.Forms.Label lblCardID;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnFilter2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel FLCardTransList;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbxTransType;
    }
}