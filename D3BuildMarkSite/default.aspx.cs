﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataManagement;

namespace D3BuildMarkSite
{
    public partial class _default : System.Web.UI.Page
    {
        //stay consistent with these consts in DataMgmtTestApp.cs
        const string BATTLETAG = "butchiebags#1483";
        const string GUID = "7ABF093B-19C6-42EC-94CE-5E1907F3B3AF";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxViewBuildSnapshot_Click(object sender, EventArgs e)
        {
            //DBManager manager = new DBManager();

            //Just view a build from the API for now
            ApiManager api = ApiManager.GetInstance();


            AC_User user = new AC_User(new Guid(GUID), "butchiebags");
            user.Profile = new AC_Profile(BATTLETAG);
            AC_Hero hero = new AC_Hero("Timmons", "Monk");
            AC_BuildSnapshot snapshot = new AC_BuildSnapshot("Wave of Fire", BATTLETAG);

            //populate snapshot with data from battle.net based on the battletag and hero's name
            api.RetrieveHeroBuild(user, hero, ref snapshot);

            //store snapshot in the session
            Session["Snapshot_0"] = snapshot;

            Response.Redirect("Buildview.aspx");
        }
    }
}