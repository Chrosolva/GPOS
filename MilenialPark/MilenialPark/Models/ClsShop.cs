using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsShop
    {
        #region properties

        public string ShopID { get; set; }
        public string ShopName { get; set; }
        public string MainProduct { get; set; }
        public string Address { get; set; }
        public string UserID { get; set; }
        
        public string ShopStatus { get; set; }

        public List<ClsShopItem> listShopitem = new List<ClsShopItem>();


        #endregion



        #region Constructor

        public ClsShop()
        {

        }

        public ClsShop(string ShopID, string ShopName, string MainProduct, string Address, string UserID)
        {
            this.ShopID = ShopID;
            this.ShopName = ShopName;
            this.MainProduct = MainProduct;
            this.Address = Address;
            this.UserID = UserID;
        }

        public ClsShop(string ShopID, string ShopName, string MainProduct, string Address, string UserID, string ShopStatus)
        {
            this.ShopID = ShopID;
            this.ShopName = ShopName;
            this.MainProduct = MainProduct;
            this.Address = Address;
            this.UserID = UserID;
            this.ShopStatus = ShopStatus;
        }

        #endregion
    }
}
