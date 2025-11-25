using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Models;
using MilenialPark.Master;
using MilenialPark.Controller;

namespace MilenialPark.UserControls
{
    public partial class UCCardTransList : UserControl
    {
        #region properties

        public ClsTransaction objtrans = new ClsTransaction();
        public ClsCard objCard = new ClsCard();
        string type;

        #endregion 

        public UCCardTransList()
        {
            InitializeComponent();
        }

        public UCCardTransList(ClsTransaction trans)
        {
            InitializeComponent();
            objtrans = trans;

            type = objtrans.TransactionID.Substring(0, 3);
            if (type == "TRK" || type == "TRC")
            {
                titlepanel.BackColor = Color.FromArgb(33, 119, 86);
                btnDetails.ForeColor = Color.FromArgb(33, 119, 86);
                btnReceipt.ForeColor = Color.FromArgb(33, 119, 86);
                btnPrint.ForeColor = Color.FromArgb(33, 119, 86);
                lblTotalAmount.ForeColor = Color.FromArgb(33, 119, 86);
                lblInitialBalance.ForeColor = Color.FromArgb(33, 119, 86);
                lblfinalbalance.ForeColor = Color.FromArgb(33, 119, 86);
                imgincrease.Visible = true;
                imgdecrease.Visible = false;
            }
            else if (type == "TRD")
            {
                titlepanel.BackColor = Color.FromArgb(133, 0, 0);
                btnDetails.ForeColor = Color.FromArgb(205, 0, 0);
                btnReceipt.ForeColor = Color.FromArgb(205, 0, 0);
                btnPrint.ForeColor = Color.FromArgb(205, 0, 0);
                lblTotalAmount.ForeColor = Color.FromArgb(205, 4, 4);
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
            }

            else if (type == "TRR")
            {
                titlepanel.BackColor = Color.FromArgb(19, 99, 223);
                btnDetails.ForeColor = Color.FromArgb(19, 99, 223);
                btnReceipt.ForeColor = Color.FromArgb(19, 99, 223);
                btnPrint.ForeColor = Color.FromArgb(19, 99, 223);
                lblTotalAmount.ForeColor = Color.FromArgb(5, 19, 103);
                lblInitialBalance.ForeColor = Color.FromArgb(205, 4, 4);
                lblfinalbalance.ForeColor = Color.FromArgb(205, 4, 4);
                imgincrease.Visible = false;
                imgdecrease.Visible = true;
            }
            objtrans = trans;
            lblTransactionID.Text = "ID : " + objtrans.TransactionID;
            lblTransactionDate.Text = "Date : " + objtrans.TransactionDate.ToString("dd/M/yyyy HH:mm:ss tt");
            lblPaymentType.Text = "Payment Type : " + objtrans.PaymentType;
            lblCardID.Text = "Card ID : " + objtrans.CardID;
            lblcustomer.Text = "Customer : " + objCard.getCustomerName(objtrans.CardID);
            lblTotalAmount.Text = "Total : " + objtrans.totalAmount.ToString("#,##0");
            lblInitialBalance.Text = objtrans.InitialBalance.ToString("#,##0");
            lblfinalbalance.Text = objtrans.finalBalance.ToString("#,##0");
        }

        
    }
}
