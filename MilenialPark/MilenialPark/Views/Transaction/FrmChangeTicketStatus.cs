using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Master;
using MilenialPark.Models;
using MilenialPark.Controller;
using MilenialPark.UserControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MilenialPark.Reports;
using MilenialPark.Views.Reports;
using System.Drawing.Printing;

namespace MilenialPark.Views.Transaction
{
    public partial class FrmChangeTicketStatus : Form
    {
        #region properties

        public string TransactionID;
        public int NoUrut;
        public string ShopID;
        public ControllerTransaction controllerTran = new ControllerTransaction();
        public ControllerShop controllerShop = new ControllerShop();
        public DataTable dt;
        decimal subtotal;
        decimal PPN;
        decimal totalamount;
        decimal balance = 0;
        string CardID;
        DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        #endregion

        public FrmChangeTicketStatus()
        {
            InitializeComponent();
        }

        public FrmChangeTicketStatus(string TransactionID, int no, string ShopID)
        {
            InitializeComponent();
            this.TransactionID = TransactionID;
            this.NoUrut = no;
            this.ShopID = ShopID;
        }

        public void setTicket()
        {
            dt = controllerTran.get1TicketDetail(this.TransactionID, this.NoUrut, start, end);
            if(dt.Rows.Count > 0)
            {
                lblTransactionID.Text = dt.Rows[0]["TransactionID"].ToString();
                lblItemID.Text = dt.Rows[0]["ItemID"].ToString();
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                dtpEnd.Value = Convert.ToDateTime(dt.Rows[0]["JamKeluar"]);
                dtpNow.Value = DateTime.Now;

                TimeSpan diff = dtpNow.Value.Subtract(dtpEnd.Value);

                if (diff.Hours == 0 && diff.Minutes > 0)
                {
                    NUDQty.Value = 1;
                }
                else if (diff.Hours == -1)
                {
                    NUDQty.Value = 0;
                }
                else
                {
                    NUDQty.Value = diff.Hours + 1;
                }

                lblOvertime.Text = $"Overtime : {diff.Hours} jam dan {diff.Minutes}"; 
            }
            else
            {
                ClsFungsi.Pesan("Status Overtime Transaksi ini tidak bisa diubah karena sudah lewat hari"); 
                this.Close();
            }
            
        }

        public void calculateamount()
        {
            subtotal = Convert.ToInt32(NUDQty.Value) * NUDprice.Value;
            PPN = (subtotal * NUDPPN.Value / 100);
            totalamount = (subtotal) + (PPN);
            NUDTotalAmount.Value = totalamount;
        }

        public void setCbxPackage()
        {
            dt = controllerShop.getShopItemTiket(ShopID, "EXTEND-TICKET");
            cbxCategory.Items.Clear();
            cbxCategory.DisplayMember = "Text";
            cbxCategory.ValueMember = "Value";
            int selected = 0;
            foreach (DataRow x in dt.Rows)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        cbxCategory.Items.Add(new { Text = dt.Rows[i]["ItemName"].ToString(), Value = dt.Rows[i]["ItemID"].ToString() });
                    }
                }
                cbxCategory.SelectedIndex = selected;
            }
        }

        private void FrmChangeTicketStatus_Load(object sender, EventArgs e)
        {
            setCbxPackage();
            setTicket();
            
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategory.Items.Count != 0)
            {
                dt = controllerShop.getOneShopItemTiket(ShopID, Convert.ToString((cbxCategory.SelectedItem as dynamic).Value));
                lblItemIDExtend.Text = dt.Rows[0]["ItemID"].ToString();
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                txtItemDesc.Text = dt.Rows[0]["ItemDesc"].ToString();
                NUDprice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);
                NUDWaktuBermain.Value = Convert.ToInt32(dt.Rows[0]["WaktuBermain"]);
                NUDToleransi.Value = Convert.ToInt32(dt.Rows[0]["Toleransi"]);
            }
        }

        private void NUDQty_KeyUp(object sender, KeyEventArgs e)
        {
            calculateamount();
        }

        private void NUDQty_ValueChanged(object sender, EventArgs e)
        {
            calculateamount();
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            // update transaksi detail , save extend 
            decimal selisih = balance - NUDTotalAmount.Value;
            if (lblCardID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Data Kartu tidak ada , Silahkan Scan dulu kartu customer!");
            }
            else if (balance == 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda kosong , silahkan diisi terlebih dahulu !!!", "INFO");
            }
            else if (selisih < 0)
            {
                ClsFungsi.Pesan("Maaf Saldo anda tidak cukup , silahkan diisi terlebih dahulu !!!", "ERROR");
            }
            else
            {
                DateTime now = DateTime.Now;
                DateTime Jamkeluarakhir = dtpEnd.Value.AddHours(Convert.ToInt32(NUDQty.Value)).AddMinutes(Convert.ToInt32(NUDToleransi.Value));
                controllerTran.objTransaction = new ClsTransaction("EX-" + lblTransactionID.Text + "-" + NoUrut, now, totalamount, "CARD", controllerTran.objCard.CardID, ShopID, txtRemarks.Text, subtotal, PPN, balance, balance - totalamount, "EXTEND-TICKET", "EXTEND-TICKET");
                controllerTran.objTransactionTiketDetail = new ClsTransactionTiketDetail("EX-" + lblTransactionID.Text + "-" + NoUrut, now, lblItemIDExtend.Text, txtItemName.Text, NUDprice.Value, Convert.ToInt32(NUDQty.Value), "EXTEND-TICKET", dtpEnd.Value, Jamkeluarakhir, Convert.ToInt32(NUDWaktuBermain.Value), Convert.ToInt32(NUDToleransi.Value));
                controllerTran.objTransaction.listtranstikdet.Clear();
                controllerTran.objTransaction.listtranstikdet.Add(controllerTran.objTransactionTiketDetail);
                controllerTran.objExtend = new ClsExtend(lblTransactionID.Text, now, NoUrut, lblItemID.Text, lblItemIDExtend.Text, NUDprice.Value, Convert.ToInt32(NUDQty.Value), dtpEnd.Value, Jamkeluarakhir, "EX-" + lblTransactionID.Text + "-" + NoUrut);

                //ClsFungsi.Pesan(controllerTran.ExtendOvertime(controllerTran.objExtend, controllerTran.objTransaction, controllerTran.objCard));
                this.Close();
            }
        }

        private void txtCardID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controllerTran.dt = controllerTran.getCard(txtCardID.Text);
                controllerTran.SetCard(txtCardID.Text);

                if (controllerTran.dt.Rows.Count == 0)
                {
                    ClsFungsi.Pesan("Data Kartu tidak terdaftar pada sistem , mohon hubungi admin !!!", "ERROR");
                }
                else
                {
                    controllerTran.objCard = new ClsCard(controllerTran.dt.Rows[0]["CardID"].ToString(), controllerTran.dt.Rows[0]["CustomerName"].ToString(), controllerTran.dt.Rows[0]["NoIdentitas"].ToString(), Convert.ToDecimal(controllerTran.dt.Rows[0]["Saldo"]), Convert.ToBoolean(controllerTran.dt.Rows[0]["Active"]));
                    lblCustomerName.Text = controllerTran.objCard.CustomerName;
                    lblBalance.Text = "Balance (Saldo) : Rp. " + controllerTran.objCard.Saldo.ToString("#,##0");
                    balance = controllerTran.objCard.Saldo;
                    lblCardID.Text = "Card ID : " + controllerTran.objCard.CardID;
                    CardID = controllerTran.objCard.CardID;
                    lblIdentity.Text = "No (KTP/SIM) : " + controllerTran.objCard.Noidentitas;
                }
            }
        }
    }
}
