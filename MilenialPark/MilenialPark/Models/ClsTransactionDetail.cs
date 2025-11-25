using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsTransactionDetail
    {
        #region properties

        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string OrderStatus { get; set; } 

        #endregion

        #region constructor

        public ClsTransactionDetail()
        {

        }

        public ClsTransactionDetail(string transactionid, DateTime transactiondate, string itemid , string itemname, decimal price, int qty)
        {
            this.TransactionID = transactionid;
            this.TransactionDate = transactiondate;
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.Price = price;
            this.Qty = qty;

        }

        public ClsTransactionDetail(string transactionid, DateTime transactiondate, string itemid, string itemname, decimal price, int qty, string OrderStatus)
        {
            this.TransactionID = transactionid;
            this.TransactionDate = transactiondate;
            this.ItemId = itemid;
            this.ItemName = itemname;
            this.Price = price;
            this.Qty = qty;
            this.OrderStatus = OrderStatus;
        }
        #endregion

    }
}
