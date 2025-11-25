using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilenialPark.Master;

namespace MilenialPark.Models
{
    public class ClsCard
    {
        #region properties

        public string CardID { get; set; }
        public string CustomerName { get; set; }
        public string Noidentitas { get; set; }
        public decimal Saldo { get; set; }

        public bool Active { get; set; }
        public decimal Point { get; set; }
        public string CardType { get; set; }
        #endregion

        #region Constructor

        public ClsCard()
        {

        }

        public ClsCard(string CardID, string CustomerNmae, string NoIdentitas, decimal saldo, bool Active)
        {
            this.CardID = CardID;
            this.CustomerName = CustomerNmae;
            this.Noidentitas = NoIdentitas;
            this.Saldo = saldo;
            this.Active = Active;
        }

        public ClsCard(string CardID, string CustomerNmae, string NoIdentitas, decimal saldo, bool Active, decimal Points , string cardtype)
        {
            this.CardID = CardID;
            this.CustomerName = CustomerNmae;
            this.Noidentitas = NoIdentitas;
            this.Saldo = saldo;
            this.Active = Active;
            this.Point = Points;
            this.CardType = cardtype;
        }

        public string getCustomerName (string CardID)
        {
            string query = "Select CustomerName from WHNPOS.dbo.TblCard where CardID = " + ClsFungsi.C2Q(CardID);
            return ClsStaticVariable.objConnection.objsqlconnection.ExecuteScalar(query);
        }

        #endregion

    }
}
