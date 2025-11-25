using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsTransaction
    {
        #region properties

        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal totalAmount { get; set; }
        public string PaymentType { get; set; }
        public string CardID { get; set; }
        public string ShopId { get; set; }
        public string Remarks { get; set; }

        public decimal Subtotal { get; set; }
        public decimal PPN { get; set; }

        public List<ClsTransactionDetail> listtransdet = new List<ClsTransactionDetail>(); 
        public List<ClsTransactionTiketDetail> listtranstikdet = new List<ClsTransactionTiketDetail>(); 

        public decimal InitialBalance { get; set; }
        public decimal finalBalance { get; set; }

        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public string KodeCabang { get; set; }



        #endregion

        #region constructor

        public ClsTransaction()
        {

        }

        public ClsTransaction(string TransactionID, DateTime TransactionDate, decimal totalamount, string paymenttype, string cardid, string shopid, string remarks)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.totalAmount = totalamount;
            this.PaymentType = paymenttype;
            this.CardID = cardid;
            this.ShopId = shopid;
            this.Remarks = remarks;
        }

        public ClsTransaction(string TransactionID, DateTime TransactionDate, decimal totalamount, string paymenttype, string cardid, string shopid, string remarks, decimal subtotal, decimal ppn, decimal initial, decimal final)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.totalAmount = totalamount;
            this.PaymentType = paymenttype;
            this.CardID = cardid;
            this.ShopId = shopid;
            this.Remarks = remarks;
            this.Subtotal = subtotal;
            this.PPN = ppn;
            this.InitialBalance = initial;
            this.finalBalance = final;
        }

        public ClsTransaction(string TransactionID, DateTime TransactionDate, decimal totalamount, string paymenttype, string cardid, string shopid, string remarks, decimal subtotal, decimal ppn, decimal initial, decimal final, string TransactionStatus)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.totalAmount = totalamount;
            this.PaymentType = paymenttype;
            this.CardID = cardid;
            this.ShopId = shopid;
            this.Remarks = remarks;
            this.Subtotal = subtotal;
            this.PPN = ppn;
            this.InitialBalance = initial;
            this.finalBalance = final;
            this.TransactionStatus = TransactionStatus;
        }

        // TIKET 

        public ClsTransaction(string TransactionID, DateTime TransactionDate, decimal totalamount, string paymenttype, string cardid, string shopid, string remarks, decimal subtotal, decimal ppn, decimal initial, decimal final, string TransactionStatus, string TransactionType)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.totalAmount = totalamount;
            this.PaymentType = paymenttype;
            this.CardID = cardid;
            this.ShopId = shopid;
            this.Remarks = remarks;
            this.Subtotal = subtotal;
            this.PPN = ppn;
            this.InitialBalance = initial;
            this.finalBalance = final;
            this.TransactionStatus = TransactionStatus;
            this.TransactionType = TransactionType;
        }

        // TIKET WITH KODE CABANG 
        public ClsTransaction(string TransactionID, DateTime TransactionDate, decimal totalamount, string paymenttype, string cardid, string shopid, string remarks, decimal subtotal, decimal ppn, decimal initial, decimal final, string TransactionStatus, string TransactionType, string KodeCabang)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.totalAmount = totalamount;
            this.PaymentType = paymenttype;
            this.CardID = cardid;
            this.ShopId = shopid;
            this.Remarks = remarks;
            this.Subtotal = subtotal;
            this.PPN = ppn;
            this.InitialBalance = initial;
            this.finalBalance = final;
            this.TransactionStatus = TransactionStatus;
            this.TransactionType = TransactionType;
            this.KodeCabang = KodeCabang;
        }

        #endregion
    }
}
