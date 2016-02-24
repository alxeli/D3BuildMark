using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManagement;
using BusinessObjects;

namespace D3BuildMarkSite.Controls
{
    public partial class EditProfile : System.Web.UI.UserControl
    {
        AC_User user = null;
        List<AC_Hero> online_heroes = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (AC_User)Session["User_0"];
            if (!IsPostBack)
            {
                DBManager manager = new DBManager();
                online_heroes = new List<AC_Hero>();

                //read user's profile from the database using the currently logged in user
                user = manager.ReadProfile((Guid)Membership.GetUser().ProviderUserKey);

                if (user.Profile.BattleTag != string.Empty)
                {
                    //list of all heroes that are in the database
                    user.Profile.Heroes = manager.ReadHeroes(user.GUID, user.Profile.BattleTag);

                    //list of heroes that have are online at Blizzard
                    ApiManager.GetInstance().RetrieveAllHeroes(user.Profile, ref online_heroes);

                    //remove duplicates of database heroes (already stored)
                    online_heroes.RemoveAll(a => user.Profile.Heroes.Exists(h => h.Name == a.Name));

                    //store hero lists in session variables

                    Session["OnlineHeroes"] = online_heroes;

                    //set user info
                    lblBattletagValue.Text = user.Profile.BattleTag;
                }
                else
                {
                    //change to no profile view
                    lblBattletagValue.Text = "Not yet added";
                }

                Session["User_0"] = user;
                Session["User_1"] = user;
                lblUserNameValue.Text = user.Name;
            }
            if (((AC_User)Session["User_0"]).Profile.BattleTag != string.Empty)
            {
                //keep local variables up to date when postback
                user = (AC_User)Session["User_0"];
                online_heroes = (List<AC_Hero>)Session["OnlineHeroes"];

                //populate controls for stored heroes
                foreach (AC_Hero c_hero in user.Profile.Heroes)
                {
                    EditHero t_control = Page.LoadControl("~/Controls/EditHero.ascx") as EditHero;
                    t_control.Hero = c_hero;
                    t_control.IsStored = true;  //these heroes are in the database

                    t_control.RemoveClickEvent += new EventHandler(RemoveHero);

                    uxImportedHeroesPlaceholder.Controls.Add(t_control);

                }

                //populate controls for online heroes (not yet stored)
                foreach (AC_Hero c_hero in online_heroes)
                {
                    EditHero t_control = Page.LoadControl("~/Controls/EditHero.ascx") as EditHero;
                    t_control.Hero = c_hero;
                    t_control.IsStored = false;  //these heroes are not in the database

                    t_control.AddClickEvent += new EventHandler(AddHero);

                    uxOnlineHeroesPlaceholder.Controls.Add(t_control);
                }
            }
        }
        
        protected void AddHero(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            AC_Hero this_hero = ((EditHero)sender).Hero;
            AC_BuildSnapshot t_snapshot = new AC_BuildSnapshot("Temp Name");

            //remove control from list of online heroes
            online_heroes.RemoveAll(a => a.Name == this_hero.Name);
            Session["OnlineHeroes"] = online_heroes;

            //create hero in the database
            manager.CreateHero(user, this_hero);

            //retireve the hero from blizzard API
            ApiManager.GetInstance().RetrieveHeroBuild(user, this_hero, ref t_snapshot);

            //store build snapshot in database
            manager.CreateBuildSnapshot(user, this_hero, t_snapshot);

            //add snapshot to the local hero
            this_hero.BuildSnapshots.Add(t_snapshot);

            //store snapshot in session
            Session["Snapshots_0"] = this_hero.BuildSnapshots;
            Session["Snapshots_1"] = this_hero.BuildSnapshots;

            Response.Redirect("/Users/AccountSettings.aspx");
        }
        protected void RemoveHero(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            AC_Hero this_hero = ((EditHero)sender).Hero;

            //remove control from list of stored heroes
            user.Profile.Heroes.RemoveAll(a => a.Name == this_hero.Name);
            Session["User_0"] = user;
            Session["User_1"] = user;

            this_hero.BuildSnapshots = manager.ReadBuildSnapshots(user.GUID, user.Profile.BattleTag, this_hero.Name);

            foreach(AC_BuildSnapshot c_snapshot in this_hero.BuildSnapshots)
            {
                manager.DeleteBuildSnapshot(user, this_hero, c_snapshot);
            }

            //delete hero from database
            manager.DeleteHero(user, this_hero);

            Response.Redirect("/Users/AccountSettings.aspx");
        }

        protected void uxCancelBattletag_Click(object sender, EventArgs e)
        {
            uxUpdateBattletag.Text = "";
        }

        protected void uxSaveBattletag_Click(object sender, EventArgs e)
        {
            if (ApiManager.GetInstance().BattletagExists(uxUpdateBattletag.Text))
            {
                ((AC_User)Session["User_0"]).Profile.BattleTag = uxUpdateBattletag.Text;
                DBManager manager = new DBManager();
                manager.CreateProfile((AC_User)Session["User_0"]);
            }
            else
            {
                //invalid
                uxUpdateBattletag.Text = "INVALID";
            }
            Response.Redirect("/Users/AccountSettings.aspx");
        }
    }
}