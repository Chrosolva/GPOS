using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilenialPark.Models;
using MilenialPark.Master;



namespace MilenialPark.Controller
{
    public class ControllerUser
    {
        #region properties

        public ClsUser objUser = new ClsUser();
        public ClsUser other = new ClsUser();
        public ClsCabang cabang = new ClsCabang();
        public List<ClsCabang> listcabang = new List<ClsCabang>();
        public string query;
        public DataTable dt;
        public ControllerShop controllerShop = new ControllerShop();

        #endregion

        #region Constructor 
        #endregion

        #region function

        public ClsUser getOneUser(string UserID, string Password)
        {
            query = "Select * From WHNPOS.dbo.TblUser where UserID = " + ClsFungsi.C2Q(UserID);
            //query = "SELECT * FROM `dbo.TblUser` where UserID = " + ClsFungsi.C2Q(UserID);
            try
            {
                dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
                if (dt.Rows.Count != 0)
                {
                    return new ClsUser(dt.Rows[0]["UserID"].ToString(), dt.Rows[0]["UserName"].ToString(), dt.Rows[0]["Password"].ToString(), dt.Rows[0]["HakAkses"].ToString(), dt.Rows[0]["TipeUser"].ToString());
                }
                else
                {
                    return new ClsUser();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable getListUser()
        {
            query = "Select * from WHNPOS.dbo.TblUser";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public bool CheckUser(string UserID)
        {
            query = "Select * from WHNPOS.dbo.TblUser where UserID = " + ClsFungsi.C2Q(UserID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query); 

            if(dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InsertUser(ClsUser user)
        {
            if(user.TipeUser == "Cashier" || user.TipeUser == "Staf")
            {
                query = "Insert into WHNPOS.dbo.TblUser (UserID,UserName, TipeUser,HakAkses, Password) " +
                    $" values({ClsFungsi.C2Q(user.UserID)}, {ClsFungsi.C2Q(user.UserName)}, {ClsFungsi.C2Q(user.TipeUser)}, {ClsFungsi.C2Q(user.HakAkses)}, {ClsFungsi.C2Q(user.Password)})";
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
            }
            else if(user.TipeUser == "Supervisor")
            {
                query = "Insert into WHNPOS.dbo.TblUser (UserID,UserName, TipeUser,HakAkses, Password) " +
                    $" values({ClsFungsi.C2Q(user.UserID)}, {ClsFungsi.C2Q(user.UserName)}, {ClsFungsi.C2Q(user.TipeUser)}, {ClsFungsi.C2Q(user.HakAkses)}, {ClsFungsi.C2Q(user.Password)})";
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);

                // add Shop

                //set Shop
                controllerShop.autogenerateShopIDCSHR();
                controllerShop.setShop(controllerShop.ShopID, "Supervisor " + controllerShop.counter.ToString() , "Balance Top Up", "", user.UserID);

                //Insert Shop 
                string hasil = "";
                hasil += controllerShop.InsertShop(controllerShop.objShop);

                // add Shop Item 
                controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemWithTopUpAmount(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "TOP UP 500.000", 399000, "TOP UP 500.000",  0 ,"C:\\WHNPOSPict\\notfound.png", 500000);
                hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);

                // add Shop Item 
                //controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                //controllerShop.setShopItem(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "REFUND", 0, "REFUND BALANCE", "C:\\WHNPOSPict\\notfound.png");
                //hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);

                // add shop Item
                controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemWithTopUpAmount(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "TOP UP 1.000.000", 749000, "TOP UP 1.000.000", 0, "C:\\WHNPOSPict\\notfound.png", 1000000);
                hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKDAY 1 HOUR", 60000 , "PAKET WEEKDAY 1 HOUR", "C:\\WHNPOSPict\\notfound.png" , "WEEKDAY", 1, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKDAY 2 HOUR", 75000, "PAKET WEEKDAY 2 HOUR", "C:\\WHNPOSPict\\notfound.png", "WEEKDAY", 2, 0); 
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKDAY UNLIMITED", 100000, "PAKET WEEKDAY UNLIMITED", "C:\\WHNPOSPict\\notfound.png", "WEEKDAY", 15, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "1 CHILD FREE 1 COMPANION", 0, "1 CHILD FREE 1 COMPANION", "C:\\WHNPOSPict\\notfound.png", "COMPANION", 15, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKEND 1 HOUR", 75000, "PAKET WEEKEND 1 HOUR", "C:\\WHNPOSPict\\notfound.png", "WEEKEND", 1, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKEND 2 HOUR", 90000, "PAKET WEEKEND 2 HOUR", "C:\\WHNPOSPict\\notfound.png", "WEEKEND", 2, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "WEEKEND UNLIMITED", 120000, "PAKET WEEKEND UNLIMITED", "C:\\WHNPOSPict\\notfound.png", "WEEKEND", 15, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);

                // add Shop Item Tiket 
                controllerShop.autogenerateShopItemTiketID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemTiket2(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "ADDITIONAL COMPANION", 30000, "ADDITIONAL COMPANION", "C:\\WHNPOSPict\\notfound.png", "COMPANION", 15, 0);
                controllerShop.InsertShopItemTiket(controllerShop.objShopItemTiket);
            }
            else if(user.TipeUser == "Admin")
            {
                query = "Insert into WHNPOS.dbo.TblUser (UserID,UserName, TipeUser,HakAkses, Password) " +
                    $" values({ClsFungsi.C2Q(user.UserID)}, {ClsFungsi.C2Q(user.UserName)}, {ClsFungsi.C2Q(user.TipeUser)}, {ClsFungsi.C2Q(user.HakAkses)}, {ClsFungsi.C2Q(user.Password)})";
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);

                // add Shop

                //set Shop
                controllerShop.autogenerateShopIDADM();
                controllerShop.setShop(controllerShop.ShopID, "ADMIN " + controllerShop.counter.ToString(), "Balance Top Up", "", user.UserID);

                //Insert Shop 
                string hasil = "";
                hasil += controllerShop.InsertShop(controllerShop.objShop);

                // add Shop Item 
                controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemWithTopUpAmount(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "TOP UP", 399000, "TOP UP 500.000", 0, "C:\\WHNPOSPict\\notfound.png", 500000);
                hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);

                // add shop Item
                controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                controllerShop.setShopItemWithTopUpAmount(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "TOP UP", 749000, "TOP UP 1.000.000", 0, "C:\\WHNPOSPict\\notfound.png", 1000000);
                hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);

                // add Shop Item 
                //controllerShop.autogenerateShopItemID(controllerShop.objShop.ShopID);
                //controllerShop.setShopItem(controllerShop.ShopItemID, controllerShop.objShop.ShopID, "REFUND", 0, "REFUND BALANCE", "C:\\WHNPOSPict\\notfound.png");
                //hasil += controllerShop.InsertShopItem(controllerShop.objShopItem);
            }
        }

        public void EditUser(ClsUser user)
        {
            query = "Update WHNPOS.dbo.TblUser set " +
                    $"UserName = {ClsFungsi.C2Q(user.UserName)}, Password = {ClsFungsi.C2Q(user.Password)}, HakAkses = {ClsFungsi.C2Q(user.HakAkses)} , TipeUser = {ClsFungsi.C2Q(user.TipeUser)}" +
                    $"where UserID = {ClsFungsi.C2Q(user.UserID)} ";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        public void DeleteUser(ClsUser user)
        {
            query = "Delete WHNPOS.dbo.Shop where UserID = " + ClsFungsi.C2Q(user.UserID);
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
            query = "Delete WHNPOS.dbo.TblUser where UserID = " + ClsFungsi.C2Q(user.UserID);
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        public void ChangePassword(ClsUser user)
        {
            query = "Update WHNPOS.dbo.TblUser set " +
                    $"Password = {ClsFungsi.C2Q(user.Password)} " +
                    $"where UserID = {ClsFungsi.C2Q(user.UserID)} ";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        //public DataTable getListHakAkses()
        //{
        //    query = "Select * From TblHakAkses where HakAkses != 'superadmin'";
        //    return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        //}

        //public DataTable getListHakAksesB()
        //{
        //    query = "Select * From TblHakAkses";
        //    return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        //}







        //public void EditHakAksesonly(ClsUser user)
        //{
        //    query = "Update TblUser set " +
        //            $"HakAkses = {ClsFungsi.C2Q(user.HakAkses)} " +
        //            $"where UserID = {ClsFungsi.C2Q(user.UserID)} ";
        //    ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        //}

        public DataTable getAllCabang()
        {
            query = "Select* from WHNPOS.dbo.TblCabang";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public void SetCabang()
        {
            dt = this.getAllCabang();
            listcabang.Clear();
            foreach(DataRow row in dt.Rows)
            {
                cabang = new ClsCabang(row["KodeCabang"].ToString(), row["NamaCabang"].ToString(), row["Alamat"].ToString(), row["AdminID"].ToString());
                listcabang.Add(cabang);
            }
        }

        public DataTable getListUserAdmin()
        {
            query = "Select * from WHNPOS.dbo.TblUser where TipeUser = 'Admin'";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public bool checkcabang(string BranchID)
        {
            query = $"Select * from WHNPOS.dbo.TblCabang where KodeCabang = {ClsFungsi.C2Q(BranchID)}";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query); 

            if(dt.Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertCabang (ClsCabang cabang)
        {
            query = "Insert INTO WHNPOS.dbo.TblCabang(KodeCabang, NamaCabang, Alamat, AdminID) " +
                    $" Values ({ClsFungsi.C2Q(cabang.KodeCabang)}, {ClsFungsi.C2Q(cabang.NamaCabang)}, {ClsFungsi.C2Q(cabang.Alamat)}, {ClsFungsi.C2Q(cabang.AdminID)})";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        public void UpdateCabang (ClsCabang cabang)
        {
            query = $"Update WHNPOS.dbo.TblCabang set NamaCabang = {ClsFungsi.C2Q(cabang.NamaCabang)}, Alamat = {ClsFungsi.C2Q(cabang.Alamat)}, " + 
                    $" AdminID = {ClsFungsi.C2Q(cabang.AdminID)} where KodeCabang = {ClsFungsi.C2Q(cabang.KodeCabang)}";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        public void DeleteCabang (string kodecabang)
        {
            query = $"Delete WHNPOS.dbo.TblCabang where KodeCabang = {ClsFungsi.C2Q(kodecabang)}";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }


        #endregion
    }
}
