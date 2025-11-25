using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Models;
using MilenialPark.Controller;
using MilenialPark.Master;

namespace MilenialPark.UserControls
{
    public partial class UCOrderItem : UserControl
    {

        #region properties
        public int index = 0;
        public int WaktuBermain;
        public int Toleransi;

        public ClsTransactionDetail objTransdet = new ClsTransactionDetail();
        public ClsTransactionTiketDetail objTranstikdet = new ClsTransactionTiketDetail();

        #endregion
        public UCOrderItem()
        {
            InitializeComponent();
        }

        public UCOrderItem(ClsTransactionDetail transdet, ClsTransactionTiketDetail transtikdet)
        {
            InitializeComponent();
            objTransdet = transdet;
            objTranstikdet = transtikdet;
            lblItemName.Text = objTransdet.ItemName;
            lblPrice.Text = objTransdet.Price.ToString("#,##0");
            lblQty.Text = objTransdet.Qty.ToString();
            NUDQty.Value = objTransdet.Qty;

        }
    }
}
