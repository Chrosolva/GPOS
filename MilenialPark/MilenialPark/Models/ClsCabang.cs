using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilenialPark.Master;

namespace MilenialPark.Models
{
    public class ClsCabang
    {
        #region properties

        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        public string Alamat { get; set; }
        public string AdminID { get; set; }

        public bool Active { get; set; }
        #endregion

        #region Constructor

        public ClsCabang()
        {

        }

        public ClsCabang(string KodeCabang, string NamaCabang, string Alamat, string AdminID)
        {
            this.KodeCabang = KodeCabang;
            this.NamaCabang = NamaCabang;
            this.Alamat = Alamat;
            this.AdminID = AdminID;
        }

        #endregion

    }
}
