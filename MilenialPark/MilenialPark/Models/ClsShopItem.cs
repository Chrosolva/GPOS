using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsShopItem
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
        public decimal TopUpAmount { get; set; }

        public int WaktuBermain { get; set; }
        public int Toleransi { get; set; }
        public string CategoryId { get; set; }



        #endregion

        #region Constructor

        public ClsShopItem()
        {

        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath, string Category, decimal TopUpAmount, int WaktuBermain, int Toleransi)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
            this.Category = Category;
            this.TopUpAmount = TopUpAmount;
            this.WaktuBermain = WaktuBermain;
            this.Toleransi = Toleransi;
        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath, decimal topup)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
            this.TopUpAmount = topup;
        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, int StockItem, string ImageFilepath, string Category)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.StockItem = StockItem;
            this.ImageFilePath = ImageFilepath;
            this.Category = Category;
        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, string ImageFilePath, string Category)
        {
            this.ItemID = ItemID;
            this.ShopID = ShopID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.ItemDesc = ItemDesc;
            this.ImageFilePath = ImageFilePath;
            this.Category = Category;
        }

        public ClsShopItem(string ItemID, string ShopID, string ItemName, decimal Price, string ItemDesc, string ImageFilePath)
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
