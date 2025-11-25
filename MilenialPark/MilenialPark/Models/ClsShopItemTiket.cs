using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsShopItemTiket
    {
        #region properties 

        public string ItemID { get; set; }
        public string ShopID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemDesc { get; set; }
        public int StockItem { get; set; }
        public string ImageFilePath { get; set; }
        public string Category { get; set; }
        public int WaktuBermain { get; set; }
        public int Toleransi { get; set; }
        public string AksesLevel { get; set; }


        #endregion

        #region Constructor

        public ClsShopItemTiket()
        {

        }

        public ClsShopItemTiket(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
        }

        public ClsShopItemTiket(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath, string Category, int waktubermain, int toleransi)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
            this.Category = Category;   
            this.WaktuBermain = waktubermain;
            this.Toleransi = toleransi;
        }

        public ClsShopItemTiket(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, string ImageFilePath, string Category, int Waktubermain, int Toleransi)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.ImageFilePath = ImageFilePath;
            this.Category = Category;
            this.WaktuBermain = Waktubermain;
            this.Toleransi = Toleransi;
        }

        public ClsShopItemTiket(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, string ImageFilePath)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.ImageFilePath = ImageFilePath;
        }
        #endregion
    }
}
