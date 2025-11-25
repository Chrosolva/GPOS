using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilenialPark.Models
{
    public class ClsUser
    {
        #region properties

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string TipeUser { get; set; }
        public string HakAkses { get; set; }
        public string Password { get; set; }

        #endregion

        #region constructor

        public ClsUser()
        {

        }

        public ClsUser(string UserID, string UserName, string Password, string HakAkses, string TipeUser)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.HakAkses = HakAkses;
            this.TipeUser = TipeUser;
        }

        #endregion

    }
}
