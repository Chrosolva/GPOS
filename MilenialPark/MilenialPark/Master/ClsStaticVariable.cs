using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilenialPark.Controller;
using MilenialPark.Models;
using MilenialPark.UserControls;
using MilenialPark.Views;

namespace MilenialPark.Master
{
    public class ClsStaticVariable
    {
        public static string DataBase = "WHNPOS";
        public static string server = "localhost";
        public static string dbmysql = "test_app";
        public static string servermysql = "127.0.0.1";
        public static DBConnect objConnection = new DBConnect();
        public static ControllerUser controllerUser = new ControllerUser();
        public static ClsTransactionDetail objtransdet = new ClsTransactionDetail();
        public static ClsTransactionTiketDetail objtranstikdet = new ClsTransactionTiketDetail();
        public static string QRCODEtoReply = "-";
        public static int NoUrut = 0;
        public static bool placeorder = false;
        public static UCOrderItem ucOrderItem = new UCOrderItem();
        public static Mainform mainForm;
        public static bool sukses = false;
        public static string ShopID = "JOYLAND";
        public static string CardID = "";
        public static string TransactionID = "";
        public static string currentID = "";
        public static ClsTransaction currenttrans;
        public static int WaktuBermain = 0;
        public static int Toleransi = 0;
        //public static string KodeBranch = "BSTCMR";
        public static string KodeBranch = "JCITY";

        #region function

        public static void setNewConnection(string Database, string Server, string uidmysql, string passmysql)
        {
            objConnection.setConnectionString(Database, Server);
            objConnection = new DBConnect(Database, Server, dbmysql, servermysql, uidmysql, passmysql);
        }


        #endregion
    }
}
