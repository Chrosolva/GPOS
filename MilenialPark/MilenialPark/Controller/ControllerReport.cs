using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MilenialPark.Models;
using MilenialPark.Master;


namespace MilenialPark.Controller
{
    public class ControllerReport
    {
        #region properties

        public ClsCard objCard = new ClsCard();
        public ClsTransaction objTrans = new ClsTransaction();
        public string query;
        public DataTable dt;
        public DataRow dr;
        public DataSet ds;
        public string CardID;

        #endregion

        #region Constructor

        public ControllerReport()
        {

        }

        #endregion

        #region function

        public DataTable getdivider()
        {
            query = "Select * from WHNPOS.dbo.Divider";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        public void SetDivider(decimal value, bool active)
        {
            query = $" Update WHNPOS.dbo.Divider set dividervalue = {ClsFungsi.C2Q(value)}, active = {ClsFungsi.C2Q(active)} ";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        //DONE
        public DataSet LoadTenantDailyTransactionPerShopID(string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = $"  Select * from WHNPOS.dbo.DailyDetailTransaction ( {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , " + 
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, {ClsFungsi.C2Q(ShopID)}) " + 
                    " Order By TransactionID desc, TransactionDate, NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblDailyTenantPerShopID = new DataTable();
            TblDailyTenantPerShopID = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblDailyTenantPerShopID.TableName = "DailyTenantPerShopID";
            ds.Tables.Add(TblDailyTenantPerShopID);
            return ds;
        }

        public DataSet LoadTenantDailyTransactionPerShopIDM(string ShopID, DateTime StartDate, DateTime EndDate, decimal dividervalue)
        {
            query = $"  Select * from WHNPOS.dbo.DailyDetailTransactionM ( {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, {ClsFungsi.C2Q(ShopID)}, {ClsFungsi.C2Q(dividervalue)}) " +
                    " Order By TransactionID desc, TransactionDate, NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblDailyTenantPerShopID = new DataTable();
            TblDailyTenantPerShopID = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblDailyTenantPerShopID.TableName = "DailyTenantPerShopID";
            ds.Tables.Add(TblDailyTenantPerShopID);
            return ds;
        }


        public DataSet LoadCashierDailyTopUpTransactionPerShopID(string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = "  Select TR.TransactionID, TR.TransactionDate, TR.TotalAmount , TR.PaymentType, TR.CardID, C.CustomerName, TR.ShopID, SH.ShopName, " +
                    " TR.Remarks , TR.Subtotal, TR.PPN, TR.InitialBalance, TR.FinalBalance, " +
                    " TRD.NoUrut, TRD.ItemID, TRD.ItemName, TRD.Price, TRD.Qty from WHNPOS.dbo.Transaksi as TR left join WHNPOS.dbo.TransaksiDetail as TRD " +
                    " on TR.TransactionID = TRD.TransactionID left join WHNPOS.dbo.TblCard as C on TR.CardID = C.CardID " +
                    " left join WHNPOS.dbo.Shop as SH on TR.ShopID = SH.ShopID " +
                    $" where TR.ShopID = {ClsFungsi.C2Q(ShopID)} and TR.TransactionID like 'TRK%' " +
                    $" and TR.TransactionDate >= {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} " +
                    $" and TR.TransactionDate <= {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} " +
                    " Order By TR.TransactionID desc, TR.TransactionDate, TRD.NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblDailyTenantPerShopID = new DataTable();
            TblDailyTenantPerShopID = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblDailyTenantPerShopID.TableName = "DailyTenantPerShopID";
            ds.Tables.Add(TblDailyTenantPerShopID);
            return ds;
        }

        //DONE
        public DataSet LoadAllDailyTransactionTenant(DateTime StartDate, DateTime EndDate)
        {
            query = $" Select * from WHNPOS.dbo.GetALLTenantDailyTransaction({ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " + 
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} ) where TransactionID like 'TRD%'  Order By TransactionID desc, TransactionDate, NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblDailyTenantPerShopID = new DataTable();
            TblDailyTenantPerShopID = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblDailyTenantPerShopID.TableName = "DailyTenantPerShopID";
            ds.Tables.Add(TblDailyTenantPerShopID);
            return ds;
        }

        // DONE
        public DataSet LoadAllMonthlyTransactionTenant(DateTime StartDate, DateTime EndDate)
        {
            query = $" Select Bulan, ShopID, ShopName, SUM(Qty) as ItemTerjual, Sum(SubTotal + PPNValue) as TotalPenjualan " + 
                    $" from WHNPOS.dbo.GetTenantMonthlyTransactionALL('TRD%', {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , " + 
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}) Group By Bulan, ShopID, ShopName ";
            DataSet ds = new DataSet();
            DataTable TblGetMonthlyTenantTransactionALL = new DataTable();
            TblGetMonthlyTenantTransactionALL = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetMonthlyTenantTransactionALL.TableName = "GetMonthlyTenantTransactionALL";
            ds.Tables.Add(TblGetMonthlyTenantTransactionALL);
            return ds;
        }

        public DataSet LoadCashierDailyRefundTransactionPerShopID(string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = "  Select TR.TransactionID, TR.TransactionDate, TR.TotalAmount , TR.PaymentType, TR.CardID, C.CustomerName, TR.ShopID, SH.ShopName, " +
                    " TR.Remarks , TR.Subtotal, TR.PPN, TR.InitialBalance, TR.FinalBalance, " +
                    " TRD.NoUrut, TRD.ItemID, TRD.ItemName, TRD.Price, TRD.Qty from WHNPOS.dbo.Transaksi as TR left join WHNPOS.dbo.TransaksiDetail as TRD " +
                    " on TR.TransactionID = TRD.TransactionID left join WHNPOS.dbo.TblCard as C on TR.CardID = C.CardID " +
                    " left join WHNPOS.dbo.Shop as SH on TR.ShopID = SH.ShopID " +
                    $" where TR.ShopID = {ClsFungsi.C2Q(ShopID)} and TR.TransactionID like 'TRR%' " +
                    $" and TR.TransactionDate >= {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} " +
                    $" and TR.TransactionDate <= {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} " +
                    " Order By TR.TransactionID desc, TR.TransactionDate, TRD.NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblDailyTenantPerShopID = new DataTable();
            TblDailyTenantPerShopID = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblDailyTenantPerShopID.TableName = "DailyTenantPerShopID";
            ds.Tables.Add(TblDailyTenantPerShopID);
            return ds;
        }

        //DONE
        public DataSet LoadTenantMonthLyTransactionPerShopID(string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = $" Select Bulan, ShopID, ShopName, PPN, ItemName, Price, Sum(Qty) as Qty from WHNPOS.dbo.GetTenantMonthlyTransaction( {ClsFungsi.C2Q(ShopID)} , {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , " + 
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} ) Group By ItemName, Bulan, ShopID, ShopName, PPN, Price Order By ItemName";
            DataSet ds = new DataSet();
            DataTable TblGetTenantMonthlyTransaction = new DataTable();
            TblGetTenantMonthlyTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTenantMonthlyTransaction.TableName = "GetTenantMonthlyTransaction";
            ds.Tables.Add(TblGetTenantMonthlyTransaction);
            return ds;
        }

        public DataSet LoadTenantMonthLyTransactionPerShopIDM(string ShopID, DateTime StartDate, DateTime EndDate, decimal divider)
        {
            query = $" Select Bulan, ShopID, ShopName, PPN, ItemName, Price, Sum(Qty) as Qty from WHNPOS.dbo.GetTenantMonthlyTransactionM( {ClsFungsi.C2Q(ShopID)} , {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, {ClsFungsi.C2Q(divider)} ) Group By ItemName, Bulan, ShopID, ShopName, PPN, Price Order By ItemName";
            DataSet ds = new DataSet();
            DataTable TblGetTenantMonthlyTransaction = new DataTable();
            TblGetTenantMonthlyTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTenantMonthlyTransaction.TableName = "GetTenantMonthlyTransaction";
            ds.Tables.Add(TblGetTenantMonthlyTransaction);
            return ds;
        }

        //DONE
        public DataSet LoadYearlyTransactionPerTenant(string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = $"Select * from WHNPOS.dbo.GetTenantsYearlyTransaction('TRD%', {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " + 
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}) where ShopID = {ClsFungsi.C2Q(ShopID)} ";
            DataSet ds = new DataSet();
            DataTable TblGetTenantsYearlyTransaction = new DataTable();
            TblGetTenantsYearlyTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTenantsYearlyTransaction.TableName = "GetTenantsYearlyTransaction";
            ds.Tables.Add(TblGetTenantsYearlyTransaction);
            return ds;
        }

        public DataSet LoadYearlyTransactionPerTenantM(string ShopID, DateTime StartDate, DateTime EndDate, decimal divider)
        {
            query = $"Select * from WHNPOS.dbo.GetTenantsYearlyTransactionM('TRD%', {ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, {ClsFungsi.C2Q(divider)}) where ShopID = {ClsFungsi.C2Q(ShopID)} ";
            DataSet ds = new DataSet();
            DataTable TblGetTenantsYearlyTransaction = new DataTable();
            TblGetTenantsYearlyTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTenantsYearlyTransaction.TableName = "GetTenantsYearlyTransaction";
            ds.Tables.Add(TblGetTenantsYearlyTransaction);
            return ds;
        }

        //DONE
        public DataSet LoadCardTransactionAll(DateTime StartDate, DateTime EndDate)
        {
            query = $"   Select * from WHNPOS.dbo.GetCardTransactionAll({ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} ) Order By  TransactionDate desc, CardID, TransactionID ";
            DataSet ds = new DataSet();
            DataTable TblGetCardTransactionAll = new DataTable();
            TblGetCardTransactionAll = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetCardTransactionAll.TableName = "GetCardTransactionAll";
            ds.Tables.Add(TblGetCardTransactionAll);
            return ds;
        }

        //DONE
        public DataSet LoadCardTransactionPerCardID(DateTime StartDate, DateTime EndDate, string CardID)
        {
            query = $"   Select * from WHNPOS.dbo.GetCardTransactionPerCardID({ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, {ClsFungsi.C2Q(CardID)} ) Order By  TransactionDate desc, CardID, TransactionID ";
            DataSet ds = new DataSet();
            DataTable TblGetCardTransactionAll = new DataTable();
            TblGetCardTransactionAll = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetCardTransactionAll.TableName = "GetCardTransactionAll";
            ds.Tables.Add(TblGetCardTransactionAll);
            return ds;
        }

        public DataSet LoadTransactionReceipt(string TransactionID, string ShopID, DateTime StartDate, DateTime EndDate)
        {
            query = $" Select * from WHNPOS.dbo.GetTransaction({ClsFungsi.C2Q(TransactionID)},{ClsFungsi.C2Q(ShopID)},{ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} )   Order By TransactionID desc, TransactionDate, NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblGetTransaction = new DataTable();
            TblGetTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTransaction.TableName = "GetTransaction";
            ds.Tables.Add(TblGetTransaction);
            return ds;
        }

        public DataSet LoadTransactionReceipt2(string TransactionID, string ShopID, DateTime StartDate, DateTime EndDate)
        {
            string functionname = "";
            string sub3 = TransactionID.Substring(0, 3);
            if (sub3 == "TRT" || sub3 == "EX-")
            {
                functionname = "GetTransactionTicket";
            }
            else
            {
                functionname = "GetTransaction";
            }
            //query = $" Select * from WHNPOS.dbo.{functionname}({ClsFungsi.C2Q(TransactionID)},{ClsFungsi.C2Q(ShopID)},{ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
            //        $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} )   Order By TransactionID desc, TransactionDate, NoUrut ";

            query = "Select TransactionID, TransactionDate, TotalAmount, PaymentType, CardID, CustomerName, ShopID, Remarks, Subtotal, " + 
                    " PPN, InitialBalance, FinalBalance, ItemID, ItemName, Price, Sum(Qty) as Qty " + 
                    $" from {functionname}({ClsFungsi.C2Q(TransactionID)}, {ClsFungsi.C2Q(ShopID)},{ClsFungsi.C2QTime(Convert.ToDateTime(StartDate.ToString("dd/M/yyyy HH:mm:ss tt")))}" + 
                    $" , {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))}) " + 
                    " group by TransactionID, TransactionDate, TotalAmount, PaymentType, CardID, CustomerName, ShopID, Remarks, Subtotal, " + 
                    " PPN, InitialBalance, FinalBalance,ItemID, ItemName, Price ";
            DataSet ds = new DataSet();
            DataTable TblGetTransaction = new DataTable();
            TblGetTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTransaction.TableName = "GetTransaction";
            ds.Tables.Add(TblGetTransaction);
            return ds;
        }

        public DataSet LoadTransactionReceipt2(string TransactionID)
        {
            query = $" Select * from WHNPOS.dbo.GetTransactionWTHDate({ClsFungsi.C2Q(TransactionID)}) " +
                    $"    Order By TransactionID desc, TransactionDate, NoUrut ";
            DataSet ds = new DataSet();
            DataTable TblGetTransaction = new DataTable();
            TblGetTransaction = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetTransaction.TableName = "GetTransaction";
            ds.Tables.Add(TblGetTransaction);
            return ds;
        }

        //DONE
        public DataSet LoadSummaryHarianAllTenant(DateTime Startdate, DateTime EndDate)
        {
            query = $" Select NoUrut, ShopID, ShopName, CardID, CustomerName, SUM(JumlahItemTerjual) as JumlahItemTerjual, SUM(Penjualan) as Penjualan from WHNPOS.dbo.GetSummaryPenjualan({ClsFungsi.C2QTime(Convert.ToDateTime(Startdate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , {ClsFungsi.C2Q("TRD%")}, {ClsFungsi.C2Q("TRC%")}) group by NoUrut, ShopID, ShopName, CardID, CustomerName";
            DataSet ds = new DataSet();
            DataTable TbGetSummaryPenjualan = new DataTable();
            TbGetSummaryPenjualan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TbGetSummaryPenjualan.TableName = "GetSummaryPenjualan";
            ds.Tables.Add(TbGetSummaryPenjualan);
            return ds;
        }

        public DataSet LoadSummaryHarianPerTenant(DateTime Startdate, DateTime EndDate, string ShopID)
        {
            query = $" Select NoUrut, ShopID, ShopName, CardID, CustomerName, SUM(JumlahItemTerjual) as JumlahItemTerjual, SUM(Penjualan) as Penjualan from WHNPOS.dbo.GetSummaryPenjualan({ClsFungsi.C2QTime(Convert.ToDateTime(Startdate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , {ClsFungsi.C2Q("TRD%")}, {ClsFungsi.C2Q("TRC%")}) where ShopID = {ClsFungsi.C2Q(ShopID)} group by NoUrut, ShopID, ShopName, CardID, CustomerName";
            DataSet ds = new DataSet();
            DataTable TbGetSummaryPenjualan = new DataTable();
            TbGetSummaryPenjualan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TbGetSummaryPenjualan.TableName = "GetSummaryPenjualan";
            ds.Tables.Add(TbGetSummaryPenjualan);
            return ds;
        }

        public DataSet LoadSummaryHarianAllCashier(DateTime Startdate, DateTime EndDate)
        {
            query = $"  Select NoUrut, ShopID, ShopName, CardID, CustomerName, SUM(JumlahItemTerjual) as JumlahItemTerjual, SUM(Penjualan) as Penjualan from WHNPOS.dbo.GetSummaryPenjualan({ClsFungsi.C2QTime(Convert.ToDateTime(Startdate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , {ClsFungsi.C2Q("TRK%")}, {ClsFungsi.C2Q("TRK%")}) group by NoUrut, ShopID, ShopName, CardID, CustomerName";
            DataSet ds = new DataSet();
            DataTable TbGetSummaryPenjualan = new DataTable();
            TbGetSummaryPenjualan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TbGetSummaryPenjualan.TableName = "GetSummaryPenjualan";
            ds.Tables.Add(TbGetSummaryPenjualan);
            return ds;
        }

        public DataSet LoadSummaryHarianRefundAllCashier(DateTime Startdate, DateTime EndDate)
        {
            query = $" Select NoUrut, ShopID, ShopName, CardID, CustomerName, SUM(JumlahItemTerjual) as JumlahItemTerjual, SUM(Penjualan) as Penjualan from WHNPOS.dbo.GetSummaryPenjualan({ClsFungsi.C2QTime(Convert.ToDateTime(Startdate.ToString("dd/M/yyyy HH:mm:ss tt")))}, " +
                    $" {ClsFungsi.C2QTime(Convert.ToDateTime(EndDate.ToString("dd/M/yyyy HH:mm:ss tt")))} , {ClsFungsi.C2Q("TRR%")}, {ClsFungsi.C2Q("TRR%")}) group by NoUrut, ShopID, ShopName, CardID, CustomerName";
            DataSet ds = new DataSet();
            DataTable TbGetSummaryPenjualan = new DataTable();
            TbGetSummaryPenjualan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TbGetSummaryPenjualan.TableName = "GetSummaryPenjualan";
            ds.Tables.Add(TbGetSummaryPenjualan);
            return ds;
        }

        public DataSet LoadSummaryKartuAllCustomerBulanan(DateTime StartDate, DateTime EndDate)
        {
            query = $" select * from WHNPOS.dbo.GetSummaryKartuBulanan({ClsFungsi.C2QTime(StartDate)}, " +
                    $" {ClsFungsi.C2QTime(EndDate)})";
            DataSet ds = new DataSet();
            DataTable TblGetSummarykartuBulanan = new DataTable();
            TblGetSummarykartuBulanan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetSummarykartuBulanan.TableName = "GetSummaryKartuBulanan";
            ds.Tables.Add(TblGetSummarykartuBulanan);
            return ds;
        }

        public DataSet LoadSummaryKartuAllCustomerTahunan(DateTime StartDate, DateTime EndDate)
        {
            query = $" select * from WHNPOS.dbo.GetSummaryKartuTahunan({ClsFungsi.C2QTime(StartDate)}, " +
                    $" {ClsFungsi.C2QTime(EndDate)})";
            DataSet ds = new DataSet();
            DataTable TblGetSummarykartuTahunan = new DataTable();
            TblGetSummarykartuTahunan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblGetSummarykartuTahunan.TableName = "GetSummaryKartuTahunan";
            ds.Tables.Add(TblGetSummarykartuTahunan);
            return ds;
        }

        public DataSet LoadSummaryBulanan(DateTime StartDate, DateTime EndDate)
        {
            query = $" select * from WHNPOS.dbo.GetSummaryBulanan({ClsFungsi.C2QTime(StartDate)}, " +
                    $" {ClsFungsi.C2QTime(EndDate)})";
            DataSet ds = new DataSet();
            DataTable TblSummaryBulanan = new DataTable();
            TblSummaryBulanan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblSummaryBulanan.TableName = "GetSummaryBulanan";
            ds.Tables.Add(TblSummaryBulanan);
            return ds;
        }

        public DataSet LoadSummaryTahunan(DateTime StartDate, DateTime EndDate)
        {
            query = $" select * from WHNPOS.dbo.GetSummaryTahunan({ClsFungsi.C2QTime(StartDate)}, " +
                    $" {ClsFungsi.C2QTime(EndDate)})";
            DataSet ds = new DataSet();
            DataTable TblSummaryTahunan = new DataTable();
            TblSummaryTahunan = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblSummaryTahunan.TableName = "GetSummaryTahunan";
            ds.Tables.Add(TblSummaryTahunan);
            return ds;
        }

        public DataSet LoadPenjualan( DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $" Select * from GetUnionTransaction()" + 
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType not like 'TOP-UP'" +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " + 
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " + 
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " + 
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)}";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetUnionTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        public DataSet LoadPendapatan(DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $" Select * from GetUnionTransaction()" +
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " +
                    $" and PaymentType not like 'CARD'" +
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " +
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " +
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)}";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetUnionTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        public DataSet LoadPendapatanGroup(DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $" Select TransactionID, PaymentType, CardID, UserID, CustomerName , TransactionType , ItemName, Price, Sum(Qty) as Jumlah , sum(Price * Qty) as Subtotal, Remarks " + 
                    " from GetUnionTransaction()" +
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " +
                    $" and PaymentType not like 'CARD'" +
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " +
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " +
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)} " +
                    "  group by TransactionType , TransactionID, PaymentType, CardID, UserID, CustomerName, ItemName ,Price , Remarks";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetGroupTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        public DataSet LoadPenjualanGroup(DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $" Select TransactionID, PaymentType, CardID, UserID, CustomerName , TransactionType , ItemName, Price, Sum(Qty) as Jumlah , sum(Price * Qty) as Subtotal, Remarks " +
                    " from GetUnionTransaction()" +
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType not like 'TOP-UP'" +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " +
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " +
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " +
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)} " +
                    "  group by TransactionType , TransactionID, PaymentType, CardID, UserID, CustomerName, ItemName ,Price , Remarks";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetGroupTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        public DataSet LoadPenjualanSummary(DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $"Select sub1.TransactionType, sub1.PaymentType , sub1.UserID, sub1.ItemName, sub1.Price, sum(sub1.Jumlah) as Jumlah, " + 
                    " sum(subtotal) as subtotal " + 
                    " from( " + 
                    " Select TransactionID, PaymentType, CardID, UserID, CustomerName , TransactionType , ItemName, Price, Sum(Qty) as Jumlah , sum(Price * Qty) as Subtotal, Remarks " +
                    " from GetUnionTransaction()" +
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType not like 'TOP-UP'" +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " +
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " +
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " +
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)} " +
                    "  group by TransactionType , TransactionID, PaymentType, CardID, UserID, CustomerName, ItemName ,Price , Remarks ) as sub1 " +
                    " group by sub1.PaymentType, sub1.UserID, sub1.TransactionType, sub1.ItemName, sub1.Price ";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetSummaryTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        public DataSet LoadPendapatanSummary(DateTime start, DateTime End, string TransactionType, string PaymentType, string UserID, string Remarks)
        {
            query = $"Select sub1.TransactionType, sub1.PaymentType , sub1.UserID, sub1.ItemName, sub1.Price, sum(sub1.Jumlah) as Jumlah, " +
                    " sum(subtotal) as subtotal " +
                    " from( " +
                    " Select TransactionID, PaymentType, CardID, UserID, CustomerName , TransactionType , ItemName, Price, Sum(Qty) as Jumlah , sum(Price * Qty) as Subtotal, Remarks " +
                    " from GetUnionTransaction()" +
                    $" where TransactionDate >= {ClsFungsi.C2QTime(start)} and TransactionDate <= {ClsFungsi.C2QTime(End)} " +
                    $" and TransactionType like {ClsFungsi.C2Q(TransactionType)} " +
                    $" and PaymentType not like 'CARD'" +
                    $" and PaymentType like {ClsFungsi.C2Q(PaymentType)} " +
                    $" and UserID like {ClsFungsi.C2Q(UserID)} " +
                    $" and Remarks like {ClsFungsi.C2Q(Remarks)} " +
                    "  group by TransactionType , TransactionID, PaymentType, CardID, UserID, CustomerName, ItemName ,Price , Remarks ) as sub1 " +
                    " group by sub1.PaymentType, sub1.UserID, sub1.TransactionType, sub1.ItemName, sub1.Price ";
            DataSet ds = new DataSet();
            DataTable TblUnionTransact = new DataTable();
            TblUnionTransact = ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
            TblUnionTransact.TableName = "GetSummaryTransaction";
            ds.Tables.Add(TblUnionTransact);
            return ds;
        }

        #endregion
    }
}
