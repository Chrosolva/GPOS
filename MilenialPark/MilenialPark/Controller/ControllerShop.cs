using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MilenialPark.Models;
using MilenialPark.Master;

namespace MilenialPark.Controller
{
    public class ControllerShop
    {

        #region properties

        public ClsShop objShop = new ClsShop();
        public ClsShopItem objShopItem = new ClsShopItem();
        public ClsShopItemTiket objShopItemTiket = new ClsShopItemTiket();
        public string query;
        public DataTable dt;
        public DataTable dt2;
        public DataRow dr;
        public string ShopID;
        public string ShopItemID;
        public int counter;

        #endregion

        #region Controller
        
        public ControllerShop()
        {

        }
        
        #endregion


        public bool checkShop (string UserID)
        {
            query = $"Select * from WHNPOS.dbo.Shop where UserID = {ClsFungsi.C2Q(UserID)} and ShopID like 'SH%'";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkShopV2(string UserID)
        {
            query = $"Select * from WHNPOS.dbo.Shop where UserID = {ClsFungsi.C2Q(UserID)} and ShopID like 'CSHR%' or ShopID like 'ADMCR%'";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkShop2(string UserID, string ShopID)
        {
            query = $"Select * from WHNPOS.dbo.Shop where UserID = {ClsFungsi.C2Q(UserID)} and ShopID like {ClsFungsi.C2Q(ShopID)}";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCashier(string UserID)
        {
            query = $"Select * from WHNPOS.dbo.Shop where UserID = {ClsFungsi.C2Q(UserID)} and (ShopID like 'CSHR%' or ShopID like 'ADMCR%' and MainProduct like '%Top Up%')";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCashier2(string UserID)
        {
            query = $"Select * from WHNPOS.dbo.Shop where ShopID like {ClsFungsi.C2Q(UserID)} and (ShopID like 'CSHR%' or ShopID like 'ADMCR%' and MainProduct like '%Top Up%')";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void setShop(string ShopID, string ShopName, string MainProduct, string Address, string UserID)
        {
            objShop = new ClsShop(ShopID, ShopName, MainProduct, Address, UserID);
        }

        public void setShop2(string ShopID, string ShopName, string MainProduct, string Address, string UserID, string ShopStatus)
        {
            objShop = new ClsShop(ShopID, ShopName, MainProduct, Address, UserID, ShopStatus);
        }

        public void autogenerateShopID ()
        {
            string keyword = "SH" + DateTime.Now.Year.ToString().Substring(2, 2);
            query = $" Select top 1 ShopID from WHNPOS.dbo.Shop where ShopID like '{keyword}%' Order By createdDate desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query); 
            if(dt.Rows.Count > 0 )
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ShopID"].ToString().Substring(dt.Rows[0]["ShopID"].ToString().Length-3, 3));
                ShopID = "SH" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + (tmp+1).ToString("D3"); 
            }
            else
            {
                ShopID = "SH" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + 1.ToString("D3");
            }
        }

        public void autogenerateShopIDCSHR()
        {
            string keyword = "CSHR";
            query = $" Select top 1 ShopID from WHNPOS.dbo.Shop where ShopID like '{keyword}%' Order By createdDate desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count > 0)
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ShopID"].ToString().Substring(dt.Rows[0]["ShopID"].ToString().Length - 3, 3));
                ShopID = "CSHR" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + (tmp + 1).ToString("D3");
                counter = tmp + 1;
            }
            else
            {
                ShopID = "CSHR" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + 1.ToString("D3");
                counter = 1;
            }
        }

        public void autogenerateShopIDADM()
        {
            string keyword = "ADMCR";
            query = $" Select top 1 ShopID from WHNPOS.dbo.Shop where ShopID like '{keyword}%' Order By createdDate desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count > 0)
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ShopID"].ToString().Substring(dt.Rows[0]["ShopID"].ToString().Length - 3, 3));
                ShopID = "ADMCR" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + (tmp + 1).ToString("D3");
                counter = tmp + 1;
            }
            else
            {
                ShopID = "ADMCR" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + 1.ToString("D3");
                counter = 1;
            }
        }

        public void getShop(string UserID)
        {
            query = "Select * from WHNPOS.dbo.Shop where UserID = " + ClsFungsi.C2Q(UserID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if(dt.Rows.Count != 0)
            {
                objShop = new ClsShop(dt.Rows[0]["ShopID"].ToString(), dt.Rows[0]["ShopName"].ToString(), dt.Rows[0]["MainProduct"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["UserID"].ToString());

            }
        }

        public void getShop2(string ShopID)
        {
            query = "Select * from WHNPOS.dbo.Shop where ShopID = " + ClsFungsi.C2Q(ShopID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count != 0)
            {
                objShop = new ClsShop(dt.Rows[0]["ShopID"].ToString(), dt.Rows[0]["ShopName"].ToString(), dt.Rows[0]["MainProduct"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["UserID"].ToString(), dt.Rows[0]["ShopStatus"].ToString());

            }
        }

        public void getcashier(string UserID)
        {
            query = "Select * from WHNPOS.dbo.Shop where UserID = " + ClsFungsi.C2Q(UserID) + "and MainProduct like '%Top Up%'";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if(dt.Rows.Count != 0)
            {
                objShop = new ClsShop(dt.Rows[0]["ShopID"].ToString(), dt.Rows[0]["ShopName"].ToString(), dt.Rows[0]["MainProduct"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["UserID"].ToString());
            }
        }

        public void getcashier2(string ShopID)
        {
            query = "Select * from WHNPOS.dbo.Shop where ShopID = " + ClsFungsi.C2Q(ShopID) + "";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count != 0)
            {
                objShop = new ClsShop(dt.Rows[0]["ShopID"].ToString(), dt.Rows[0]["ShopName"].ToString(), dt.Rows[0]["MainProduct"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["UserID"].ToString());
            }
        }

        public bool checkShopItem(string ItemName, string ShopID)
        {
            query = $"Select * from WHNPOS.dbo.ShopItem where ShopID = {ClsFungsi.C2Q(ShopID)} and ItemName like {ClsFungsi.C2Q("%" + ItemName + "%")}";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);

            bool exist = true;
            if (dt.Rows.Count > 0)
            {
                exist = false;
                foreach(DataRow row in dt.Rows)
                {
                    if(row["ItemName"].ToString() == ItemName)
                    {
                        exist = true;
                    }
                }
                return exist;
            }
            else
            {
                return false;
            }
        }

        public void setShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string Itemdesc, string ImageFilePath)
        {
            objShopItem = new ClsShopItem(ItemID, ShopID, ItemName,Price , Itemdesc, ImageFilePath);
        }

        public void setShopItemWithTopUpAmount(string ItemID, string ShopID, string ItemName, decimal Price, string Itemdesc, int stockitem, string ImageFilePath, decimal topup)
        {
            objShopItem = new ClsShopItem(ItemID, ShopID, ItemName, Price, Itemdesc, stockitem, ImageFilePath, topup);
        }

        public void setShopItem2(string ItemID, string ShopID, string ItemName, decimal Price, string Itemdesc, string ImageFilePath, string Category)
        {
            objShopItem = new ClsShopItem(ItemID, ShopID, ItemName, Price, Itemdesc, ImageFilePath, Category);
        }

        public void setShopItem3(string ItemID, string ShopID, string ItemName, decimal Price, string Itemdesc, string ImageFilePath, string Category, decimal topupamount)
        {
            objShopItem = new ClsShopItem(ItemID, ShopID, ItemName, Price, Itemdesc, 0, ImageFilePath,Category, topupamount, 0, 0);
        }

        public void setShopItemTiket2(string ItemID, string ShopID, string ItemName, decimal Price, string Itemdesc, string ImageFilePath, string Category, int Waktubermain, int Toleransi)
        {
            objShopItemTiket = new ClsShopItemTiket(ItemID, ShopID, ItemName, Price, Itemdesc, ImageFilePath, Category, Waktubermain, Toleransi);
        }

        public DataTable getShopItem(string ShopID)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category ,TopUpAmount from WHNPOS.dbo.ShopItem where ShopID = " + ClsFungsi.C2Q(ShopID) + $" and ItemID like '{ShopID + "_SI%"}'";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getShopItemActivity(string ShopID)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category from WHNPOS.dbo.ShopItem where ShopID = " + ClsFungsi.C2Q(ShopID) + $" and ItemID like '{ShopID + "_AC%"}'";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getShopItemTiket(string ShopID)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category from WHNPOS.dbo.ShopItemTiket where ShopID = " + ClsFungsi.C2Q(ShopID);
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getShopItemTiket(string ShopID, string category)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category from WHNPOS.dbo.ShopItemTiket where ShopID = " + ClsFungsi.C2Q(ShopID) + " and (Category = " + ClsFungsi.C2Q(category) + " or Category = 'COMPANION')";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getOneShopItem(string ShopID, string ItemID)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category, TopUpAmount from WHNPOS.dbo.ShopItem where ShopID = " + ClsFungsi.C2Q(ShopID) + "and ItemID = " + ClsFungsi.C2Q(ItemID);
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getOneShopItemTiket(string ShopID, string ItemID)
        {
            query = "Select ItemID, ItemName, Price, ItemDesc, ImageFilePath, Category, WaktuBermain, Toleransi from WHNPOS.dbo.ShopItemTiket where ShopID = " + ClsFungsi.C2Q(ShopID) + " and ItemID = " + ClsFungsi.C2Q(ItemID);
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public void autogenerateShopItemID(string ShopID)
        {
            query = $"Select top 1 ItemID from WHNPOS.dbo.ShopItem where ShopID = {ClsFungsi.C2Q(ShopID)} and ItemID like '{ShopID + "_SI%"}' Order By ItemID desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count > 0)
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString().Substring(dt.Rows[0]["ItemID"].ToString().Length-3, 3));
                ShopItemID = ShopID + "_" + "SI" + "-" + (tmp + 1).ToString("D3");
            }
            else
            {
                ShopItemID = ShopID + "_" + "SI" + "-" + 1.ToString("D3");
            }
        }

        public void autogenerateShopItemIDActivity(string ShopID)
        {
            query = $"Select top 1 ItemID from WHNPOS.dbo.ShopItem where ShopID = {ClsFungsi.C2Q(ShopID)} and ItemID like '{ShopID + "_AC%"}' Order By ItemID desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count > 0)
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString().Substring(dt.Rows[0]["ItemID"].ToString().Length - 3, 3));
                ShopItemID = ShopID + "_" + "AC" + "-" + (tmp + 1).ToString("D3");
            }
            else
            {
                ShopItemID = ShopID + "_" + "AC" + "-" + 1.ToString("D3");
            }
        }

        public void autogenerateShopItemTiketID(string ShopID)
        {
            query = $"Select top 1 ItemID from WHNPOS.dbo.ShopItemTiket where ShopID = {ClsFungsi.C2Q(ShopID)} Order By ItemID desc";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            if (dt.Rows.Count > 0)
            {
                int tmp = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString().Substring(dt.Rows[0]["ItemID"].ToString().Length - 3, 3));
                ShopItemID = ShopID + "_" + "SI" + "-" + (tmp + 1).ToString("D3");
            }
            else
            {
                ShopItemID = ShopID + "_" + "SI" + "-" + 1.ToString("D3");
            }
        }

        public void getShopandShopItem( string UserID)
        {
            this.getShop(UserID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ShopID = " +  ClsFungsi.C2Q(objShop.ShopID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if(dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItem2(string ShopID)
        {
            this.getShop2(ShopID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ShopID = " + ClsFungsi.C2Q(objShop.ShopID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString(), row["Category"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItem2Activity(string ShopID)
        {
            this.getShop2(ShopID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ShopID = " + ClsFungsi.C2Q(objShop.ShopID) + $" and ItemID like '{objShop.ShopID+ "_AC%"}'";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString(), row["Category"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItem2Union(string ShopID, string Category)
        {
            this.getShop2(ShopID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.GetUnionShopItem() where ShopID = " + ClsFungsi.C2Q(objShop.ShopID) + $" and TopUpAmount = 0 and Category != {ClsFungsi.C2Q(Category)}";
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString(), row["Category"].ToString(), Convert.ToDecimal(row["TopUpAmount"]), Convert.ToInt32(row["WaktuBermain"]), Convert.ToInt32(row["Toleransi"]));
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItemTopUp(string UserID)
        {
            this.getcashier(UserID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ItemName like '%TOP%UP%' and ShopID = " + ClsFungsi.C2Q(objShop.ShopID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString(), row["Category"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItemTopUp2(string UserID, string ItemID)
        {
            this.getcashier(UserID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ItemID = " + ClsFungsi.C2Q(ItemID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString(), row["Category"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public void getShopandShopItemRefund(string UserID)
        {
            this.getcashier(UserID);
            objShop.listShopitem = new List<ClsShopItem>();
            query = "Select * from WHNPOS.dbo.ShopItem where ItemName like '%REFUND%' and ShopID = " + ClsFungsi.C2Q(objShop.ShopID);
            dt = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objShopItem = new ClsShopItem(row["ItemID"].ToString(), row["ShopID"].ToString(), row["ItemName"].ToString(), Convert.ToDecimal(row["Price"]), row["ItemDesc"].ToString(), 0, row["ImageFilePath"].ToString());
                    objShop.listShopitem.Add(objShopItem);
                }
            }

        }

        public DataTable getAllShop()
        {
            query = " Select SH.*, U.UserName, U.TipeUser, U.HakAkses, U.[Password] from WHNPOS.dbo.Shop as SH left join WHNPOS.dbo.TblUser as U on SH.UserID = U.UserID " +
                    " where SH.ShopID like 'SH%' ";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getAllShopV2(string UserID) 
        {
            query = " Select SH.*, U.UserName, U.TipeUser, U.HakAkses, U.[Password] from WHNPOS.dbo.Shop as SH left join WHNPOS.dbo.TblUser as U on SH.UserID = U.UserID " +
                    $" where SH.UserID like {ClsFungsi.C2Q(UserID)} ";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getAllShopV3(string UserID)
        {
            query = " Select SH.*, U.UserName, U.TipeUser, U.HakAkses, U.[Password] from WHNPOS.dbo.Shop as SH left join WHNPOS.dbo.TblUser as U on SH.UserID = U.UserID " +
                    $" where SH.UserID like {ClsFungsi.C2Q(UserID)} and SH.ShopStatus = 'Active'";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getAllAllShop()
        {
            query = " Select SH.*, U.UserName, U.TipeUser, U.HakAkses, U.[Password] from WHNPOS.dbo.Shop as SH left join WHNPOS.dbo.TblUser as U on SH.UserID = U.UserID " +
                    " ";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getAllCAshier()
        {
            query = "Select * from WHNPOS.dbo.Shop";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query); 
        }

        public bool checkcanrefund(string ShopID)
        {
            dt = getShopItem(ShopID);
            if(dt.Rows.Count !=0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if(row["ItemName"].ToString().Contains("REFUND"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public DataTable getAllcategory ()
        {
            query = "Select distinct IsNull(Category, '') as Category from WHNPOS.dbo.ShopItem";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public DataTable getAllcategoryTicket()
        {
            query = "Select distinct IsNull(Category, '') as Category from WHNPOS.dbo.ShopItemTiket";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        #region  CRUID

        public string InsertShop (ClsShop shop)
        {
            query = "Insert Into WHNPOS.dbo.Shop " +
                    " (ShopID, ShopName, MainProduct, Address, UserID, createdDate, updatedDate, ShopStatus) " +
                    " values " +
                    $" ({ClsFungsi.C2Q(shop.ShopID)}, {ClsFungsi.C2Q(shop.ShopName)}, {ClsFungsi.C2Q(shop.MainProduct)}, {ClsFungsi.C2Q(shop.Address)}, {ClsFungsi.C2Q(shop.UserID)}, GETDATE(), GETDATE(), {ClsFungsi.C2Q(shop.ShopStatus)}) "; 

            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Toko Berhasil Untuk diTambah";
            }

            catch(Exception e)
            {
                return "Data Toko Gagal Untuk diTambah !!! error message = " + e.Message;
            }
        }

        public string UpdateShop (ClsShop shop)
        {
            query = "Update WHNPOS.dbo.Shop " +
                    $" set ShopName = {ClsFungsi.C2Q(shop.ShopName)}, MainProduct = {ClsFungsi.C2Q(shop.MainProduct)}, Address = {ClsFungsi.C2Q(shop.Address)}, updatedDate = GETDATE(), ShopStatus = {ClsFungsi.C2Q(shop.ShopStatus)} " +
                    $" where ShopID = {ClsFungsi.C2Q(shop.ShopID)}";
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Toko Berhasil Untuk diUbah";
            }

            catch (Exception e)
            {
                return "Data Toko Gagal Untuk diUbah !!! error message = " + e.Message;
            }
        }

        public string InsertShopItem(ClsShopItem objShopItem)
        {
            query = "Insert Into WHNPOS.dbo.ShopItem " +
                    " (ItemID, ShopID, ItemName, Price, ItemDesc, StockItem, ImageFilePath, Category, TopUpAmount) " +
                    " values " +
                    $" ({ClsFungsi.C2Q(objShopItem.ItemID)}, {ClsFungsi.C2Q(objShopItem.ShopID)}, {ClsFungsi.C2Q(objShopItem.ItemName)}, {ClsFungsi.C2Q(objShopItem.Price)}, {ClsFungsi.C2Q(objShopItem.ItemDesc)}, 0, {ClsFungsi.C2Q(objShopItem.ImageFilePath)}, {ClsFungsi.C2Q(objShopItem.Category)}, {ClsFungsi.C2Q(objShopItem.TopUpAmount)}) ";

            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Item Toko Berhasil Untuk diTambah";
            }

            catch (Exception e)
            {
                return "Data Item Toko Gagal Untuk diTambah !!! error message = " + e.Message;
            }
        }

        public string InsertShopItemTiket(ClsShopItemTiket objShopItemTiket)
        {
            query = "Insert Into WHNPOS.dbo.ShopItemTiket " +
                    " (ItemID, ShopID, ItemName, Price, ItemDesc, StockItem, ImageFilePath, Category, WaktuBermain, Toleransi) " +
                    " values " +
                    $" ({ClsFungsi.C2Q(objShopItemTiket.ItemID)}, {ClsFungsi.C2Q(objShopItemTiket.ShopID)}, {ClsFungsi.C2Q(objShopItemTiket.ItemName)}, {ClsFungsi.C2Q(objShopItemTiket.Price)}, {ClsFungsi.C2Q(objShopItemTiket.ItemDesc)}, 0, {ClsFungsi.C2Q(objShopItemTiket.ImageFilePath)}, {ClsFungsi.C2Q(objShopItemTiket.Category)}, {ClsFungsi.C2Q(objShopItemTiket.WaktuBermain)}, {ClsFungsi.C2Q(objShopItemTiket.Toleransi)}) ";

            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Item Toko Berhasil Untuk diTambah";
            }

            catch (Exception e)
            {
                return "Data Item Toko Gagal Untuk diTambah !!! error message = " + e.Message;
            }
        }

        public string UpdateShopitem(ClsShopItem oShopItem)
        {
            query = "Update WHNPOS.dbo.ShopItem " +
                    $" set ItemName = {ClsFungsi.C2Q(oShopItem.ItemName)}, Price = {ClsFungsi.C2Q(oShopItem.Price)}, ItemDesc = {ClsFungsi.C2Q(oShopItem.ItemDesc)}, ImageFilePath = {ClsFungsi.C2Q(oShopItem.ImageFilePath)}, Category = {ClsFungsi.C2Q(objShopItem.Category)} " +
                    $" where ItemID = {ClsFungsi.C2Q(oShopItem.ItemID)} and ShopID = {ClsFungsi.C2Q(oShopItem.ShopID)}";
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Item Toko Berhasil Untuk diUbah";
            }

            catch (Exception e)
            {
                return "Data Item Toko Gagal Untuk diUbah !!! error message = " + e.Message;
            }
        }

        public string UpdateShopitemTiket(ClsShopItemTiket oShopItemTiket)
        {
            query = "Update WHNPOS.dbo.ShopItemTiket " +
                    $" set ItemName = {ClsFungsi.C2Q(oShopItemTiket.ItemName)}, Price = {ClsFungsi.C2Q(oShopItemTiket.Price)}, ItemDesc = {ClsFungsi.C2Q(oShopItemTiket.ItemDesc)}, ImageFilePath = {ClsFungsi.C2Q(oShopItemTiket.ImageFilePath)}, Category = {ClsFungsi.C2Q(oShopItemTiket.Category)} , WaktuBermain = {ClsFungsi.C2Q(oShopItemTiket.WaktuBermain)} , Toleransi = {ClsFungsi.C2Q(oShopItemTiket.Toleransi)}" +
                    $" where ItemID = {ClsFungsi.C2Q(oShopItemTiket.ItemID)} and ShopID = {ClsFungsi.C2Q(oShopItemTiket.ShopID)}";
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return "Data Item Toko Berhasil Untuk diUbah";
            }

            catch (Exception e)
            {
                return "Data Item Toko Gagal Untuk diUbah !!! error message = " + e.Message;
            }
        }

        public string DeleteShopItem(string ItemID)
        {
            query = "Delete WHNPOS.dbo.ShopItem where ItemID = " + ClsFungsi.C2Q(ItemID); 
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return " Data item Toko Berhasil untuk diHapus"; 
            }
            catch(Exception e)
            {
                return " Data Item Toko Gagal diHapus !!! error Message = " + e.Message;
            }
        }

        public string DeleteShopActivity(string ItemID)
        {
            query = "Delete WHNPOS.dbo.ShopItem where ItemID = " + ClsFungsi.C2Q(ItemID);
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return " Data item Toko Berhasil untuk diHapus";
            }
            catch (Exception e)
            {
                return " Data Item Toko Gagal diHapus !!! error Message = " + e.Message;
            }
        }
        public string DeleteShopItemTiket(string ItemID)
        {
            query = "Delete WHNPOS.dbo.ShopItemTiket where ItemID = " + ClsFungsi.C2Q(ItemID);
            try
            {
                ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
                return " Data item Toko Berhasil untuk diHapus";
            }
            catch (Exception e)
            {
                return " Data Item Toko Gagal diHapus !!! error Message = " + e.Message;
            }
        }

        #endregion
    }
}
