using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsExtend
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set;}
        public int NoUrut { get; set; }
        public string ItemID { get; set; }
        public string ItemIDExtend { get; set; }
        public decimal Price { get; set; }
        public int WaktuBermain { get; set; }
        public DateTime JamKeluarAwal { get; set; }
        public DateTime JamKeluarAkhir { get; set; }
        public string TransactIDExtend { get; set; }

        public ClsExtend()
        {

        }

        public ClsExtend(string ID, DateTime transDate, int No, string itemID , string IDExtend, decimal Price, int Waktubermain, DateTime keluarAwal , DateTime keluarAkhir, string TransIDExt)
        {
            this.TransactionDate = transDate;
            this.TransactionID = ID;
            this.NoUrut = No;
            this.ItemID = itemID;
            this.ItemIDExtend = IDExtend;
            this.Price = Price;
            this.WaktuBermain = Waktubermain;
            this.JamKeluarAwal = keluarAwal;
            this.JamKeluarAkhir = keluarAkhir;
            this.TransactIDExtend = TransIDExt;
        }
    }
}
