using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsTransactionTiketDetail
    {
        #region properties

        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int NoUrut { get; set; }
        public string OrderStatus { get; set; }
        public DateTime JamMasuk { get; set; }
        public DateTime JamKeluar { get; set; }
        public int WaktuBermain { get; set; }
        public int Toleransi { get; set; }
        public string RFID { get; set; }  // new property
        public string Keterangan { get; set; }  // new property


        #endregion

        #region constructor

        public ClsTransactionTiketDetail()
        {

        }

        public ClsTransactionTiketDetail(string transactionid, DateTime transactiondate, string itemid, string itemname, decimal price, int qty)
        {
            this.TransactionID = transactionid;
            this.TransactionDate = transactiondate;
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.Price = price;
            this.Qty = qty;

        }

        public ClsTransactionTiketDetail(string transactionid, DateTime transactiondate, string itemid, string itemname, decimal price, int qty, string OrderStatus, DateTime Jammasuk, DateTime Jamkeluar, int WaktuBermain, int Toleransi)
        {
            this.TransactionID = transactionid;
            this.TransactionDate = transactiondate;
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.Price = price;
            this.Qty = qty;
            this.OrderStatus = OrderStatus;
            this.JamMasuk = Jammasuk;
            this.JamKeluar = Jamkeluar;
            this.WaktuBermain = WaktuBermain;
            this.Toleransi = Toleransi;
        }

        public ClsTransactionTiketDetail(string transactionid, DateTime transactiondate, string itemid, string itemname, decimal price, int qty, int NoUrut, string OrderStatus, DateTime Jammasuk, DateTime Jamkeluar, int WaktuBermain, int Toleransi)
        {
            this.TransactionID = transactionid;
            this.TransactionDate = transactiondate;
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.Price = price;
            this.Qty = qty;
            this.NoUrut = NoUrut;
            this.OrderStatus = OrderStatus;
            this.JamMasuk = Jammasuk;
            this.JamKeluar = Jamkeluar;
            this.WaktuBermain = WaktuBermain;
            this.Toleransi = Toleransi;
        }

        public ClsTransactionTiketDetail(string transactionid, DateTime transactiondate, string itemid,
       string itemname, decimal price, int qty, int noUrut, string orderStatus,
       DateTime jamMasuk, DateTime jamKeluar, int waktuBermain, int toleransi, string rfid = null, string keterangan = null)
        {
            TransactionID = transactionid;
            TransactionDate = transactiondate;
            ItemId = itemid;
            ItemName = itemname;
            Price = price;
            Qty = qty;
            NoUrut = noUrut;
            OrderStatus = orderStatus;
            JamMasuk = jamMasuk;
            JamKeluar = jamKeluar;
            WaktuBermain = waktuBermain;
            Toleransi = toleransi;
            RFID = rfid;
            Keterangan = keterangan;
        }


        #endregion
    }
}
