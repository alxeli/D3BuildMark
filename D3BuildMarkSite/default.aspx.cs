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
    public partial class _default : System.Web.UI.Page
    {
        //stay consistent with these consts in DataMgmtTestApp.cs
        //const string BATTLETAG = "butchiebags#1483";
        //const string GUID = "82994855-28B2-433A-A6AA-E94CE48BCA89";
        //const string HERONAME = "Timmons";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/AccountSettings.aspx");
        }

        //protected void uxViewBuildSnapshot_Click(object sender, EventArgs e)
        //{
        //    AC_BuildSnapshot snapshot = null;

        //    if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        snapshot = ViewSnapshotFromDB();
        //    }
        //    else
        //    {
        //        snapshot = ViewSnapshotFromAPI();
        //    }
            
        //    //store snapshot in the session
        //    Session["Snapshot_0"] = snapshot;

        //    Response.Redirect("Buildview.aspx");
        //}
        //protected AC_BuildSnapshot ViewSnapshotFromAPI()
        //{
        //    ApiManager api = ApiManager.GetInstance();

        //    AC_BuildSnapshot snapshot = new AC_BuildSnapshot("Wave of Fire", BATTLETAG);
        //    AC_User user = new AC_User(new Guid(GUID), "butchiebags");
        //    user.Profile = new AC_Profile(BATTLETAG);
        //    AC_Hero hero = new AC_Hero("Timmons", "Monk");
            
        //    api.RetrieveHeroBuild(user, hero, ref snapshot);

        //    return snapshot;
        //}
        //protected AC_BuildSnapshot ViewSnapshotFromDB()
        //{
        //    DBManager manager = new DBManager();
        //    Guid guid = new Guid(GUID);
        //    AC_User user = null;
        //    AC_BuildSnapshot snapshot = null;

        //    guid = (Guid)Membership.GetUser().ProviderUserKey;

        //    user = manager.ReadProfile(guid);
        //    snapshot = manager.ReadBuildSnapshots(guid, user.Profile.BattleTag, HERONAME)[0];

        //    return snapshot;
        //}

    }
}