using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataManagement;
using System.Web.Security;

namespace D3BuildMarkSite
{
    public partial class Buildview : System.Web.UI.Page
    {         
        protected void Page_Load(object sender, EventArgs e)
        {
            //DBManager db = new DBManager();

            ////Aqcuire logged in user and profile info for testing purposes
            //Guid guid = (Guid)Membership.GetUser().ProviderUserKey;
            //AC_User user = db.ReadProfile(guid);

            //uxTestGUIDAqcuire.Text = user.GUID + " " + user.Name + " " + user.Profile.BattleTag; 
        }
    }
}