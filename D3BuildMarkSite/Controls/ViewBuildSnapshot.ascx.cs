using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataManagement;

namespace D3BuildMarkSite.Controls
{
    public partial class uxBuildSnapshotView : System.Web.UI.UserControl
    {
        AC_User m_user = null;
        AC_Hero m_hero = null;
        List<AC_BuildSnapshot> m_snapshots = null;
        AC_BuildSnapshot c_snapshot = null;
        DBManager m_manager = new DBManager();
        
        protected override void OnInit(EventArgs e)
        {
            //Session["ddl_index"] = 0;
            m_user = (AC_User)Session["User_0"];
            m_hero = (AC_Hero)Session["Hero_0"];
            m_snapshots = (List<AC_BuildSnapshot>)Session["Snapshots_0"];
            c_snapshot = (AC_BuildSnapshot)Session["Snapshot_0"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (m_snapshots == null)
                {
                    m_snapshots = new List<AC_BuildSnapshot>();
                }
                if(c_snapshot == null)
                {
                    c_snapshot = new AC_BuildSnapshot();
                }


                //regions go here
                #region data retrieval stuff
                //m_snapshots.Clear();
                //m_snapshots.Add(c_snapshot);

                if (m_hero.IsStored == true)
                {
                    //pull all snapshots from DB
                    m_snapshots = m_manager.ReadBuildSnapshots(m_user.GUID, m_user.Profile.BattleTag, m_hero.Name);
                    Session["Snapshots_0"] = m_snapshots;

                    //c_snapshot = m_snapshots[uxVersion.SelectedIndex >= 0 ? uxVersion.SelectedIndex : 0];
                    c_snapshot = m_snapshots[Session["ddl_index"] == null ? 0 : (int)Session["ddl_index"]];
                    Session["Snapshot_0"] = c_snapshot;
                    //if any item images dont exist on the server, retrieve the snapshot from the API
                    //this will retrieve the images and store them on the server where they will persist
                    if (CheckImageUrlExistence(c_snapshot) == false)
                    {
                        ApiManager.GetInstance().RetrieveHeroBuild(m_user, m_hero, ref c_snapshot);

                        #region getImageUrls
                        GetImageUrl(c_snapshot.Items["Head"]);
                        GetImageUrl(c_snapshot.Items["Neck"]);
                        GetImageUrl(c_snapshot.Items["Shoulders"]);
                        GetImageUrl(c_snapshot.Items["Gloves"]);
                        GetImageUrl(c_snapshot.Items["Chest"]);
                        GetImageUrl(c_snapshot.Items["Bracers"]);
                        GetImageUrl(c_snapshot.Items["Belt"]);
                        GetImageUrl(c_snapshot.Items["LeftRing"]);
                        GetImageUrl(c_snapshot.Items["RightRing"]);
                        GetImageUrl(c_snapshot.Items["Pants"]);
                        GetImageUrl(c_snapshot.Items["Boots"]);
                        GetImageUrl(c_snapshot.Items["LeftHand"]);
                        GetImageUrl(c_snapshot.Items["RightHand"]);
                        #endregion
                    }

                    lblBuildName.Text = c_snapshot.Name;
                    lblBuildName.ForeColor = System.Drawing.Color.Black;
                    lblBattletag.Text = c_snapshot.Battletag;
                }
                else
                {
                    //pull snapshot from API
                    ApiManager.GetInstance().RetrieveHeroBuild(m_user, m_hero, ref c_snapshot);

                    lblBuildName.Text = "NOT IMPORTED";
                    lblBuildName.ForeColor = System.Drawing.Color.Red;
                    lblBattletag.Text = m_user.Profile.BattleTag;
                }
                #endregion

                #region Labels
                //lblHeroName.Text = m_hero.Name;

                //set item Images
                uxHeadImage.ImageUrl = GetImageUrl(c_snapshot.Items["Head"]);
                uxNeckImage.ImageUrl = GetImageUrl(c_snapshot.Items["Neck"]);
                uxShouldersImage.ImageUrl = GetImageUrl(c_snapshot.Items["Shoulders"]);
                uxGlovesImage.ImageUrl = GetImageUrl(c_snapshot.Items["Gloves"]);
                uxChestImage.ImageUrl = GetImageUrl(c_snapshot.Items["Chest"]);
                uxBracersImage.ImageUrl = GetImageUrl(c_snapshot.Items["Bracers"]);
                uxBeltImage.ImageUrl = GetImageUrl(c_snapshot.Items["Belt"]);
                uxLeftRingImage.ImageUrl = GetImageUrl(c_snapshot.Items["LeftRing"]);
                uxRightRingImage.ImageUrl = GetImageUrl(c_snapshot.Items["RightRing"]);
                uxPantsImage.ImageUrl = GetImageUrl(c_snapshot.Items["Pants"]);
                uxBootsImage.ImageUrl = GetImageUrl(c_snapshot.Items["Boots"]);
                uxLeftHandImage.ImageUrl = GetImageUrl(c_snapshot.Items["LeftHand"]);
                uxRightHandImage.ImageUrl = GetImageUrl(c_snapshot.Items["RightHand"]);

                //set attribute textbox values for hovering over items
                uxNeckAttributes.Text = c_snapshot.Items["Neck"].Name + "\n" + c_snapshot.Items["Neck"].Attributes;
                uxShouldersAttributes.Text = c_snapshot.Items["Shoulders"].Name + "\n" + c_snapshot.Items["Shoulders"].Attributes;
                uxBracersAttributes.Text = c_snapshot.Items["Bracers"].Name + "\n" + c_snapshot.Items["Bracers"].Attributes;
                uxBeltAttributes.Text = c_snapshot.Items["Belt"].Name + "\n" + c_snapshot.Items["Belt"].Attributes;
                uxLeftRingAttributes.Text = c_snapshot.Items["LeftRing"].Name + "\n" + c_snapshot.Items["LeftRing"].Attributes;
                uxRightRingAttributes.Text = c_snapshot.Items["RightRing"].Name + "\n" + c_snapshot.Items["RightRing"].Attributes;
                uxPantsAttributes.Text = c_snapshot.Items["Pants"].Name + "\n" + c_snapshot.Items["Pants"].Attributes;
                uxBootsAttributes.Text = c_snapshot.Items["Boots"].Name + "\n" + c_snapshot.Items["Boots"].Attributes;
                uxLeftHandAttributes.Text = c_snapshot.Items["LeftHand"].Name + "\n" + c_snapshot.Items["LeftHand"].Attributes;
                uxRightHandAttributes.Text = c_snapshot.Items["RightHand"].Name + "\n" + c_snapshot.Items["RightHand"].Attributes;
                uxChestAttributes.Text = c_snapshot.Items["Chest"].Name + "\n" + c_snapshot.Items["Chest"].Attributes;
                uxGlovesAttributes.Text = c_snapshot.Items["Gloves"].Name + "\n" + c_snapshot.Items["Gloves"].Attributes;
                uxHeadAttributes.Text = c_snapshot.Items["Head"].Name + "\n" + c_snapshot.Items["Head"].Attributes;

                uxStrength.Text = c_snapshot.BuildMark.Strength.ToString("0,0");
                uxDexterity.Text = c_snapshot.BuildMark.Dexterity.ToString("0,0");
                uxIntelligence.Text = c_snapshot.BuildMark.Intelligence.ToString("0,0");
                uxVitality.Text = c_snapshot.BuildMark.Vitality.ToString("0,0");

                uxDamage.Text = c_snapshot.BuildMark.Damage.ToString("0,0");
                uxToughness.Text = c_snapshot.BuildMark.Toughness.ToString("0,0");
                uxRecovery.Text = c_snapshot.BuildMark.Recovery.ToString("0,0");

                uxLife.Text = c_snapshot.BuildMark.Life.ToString("0,0");

                uxBuildMarkSingle.Text = c_snapshot.BuildMark.ScoreSingle.ToString("0,0");
                uxBuildMarkMultiple.Text = c_snapshot.BuildMark.ScoreMultiple.ToString("0,0");


                #endregion

                #region login specific controls

                //enable/disable snapshot owner functionality
                //build name edit button
                //import snapshot button

                Guid guid;
                AC_User user = null;

                if (HttpContext.Current.User.Identity.Name != String.Empty)
                {
                    guid = (Guid)Membership.GetUser().ProviderUserKey;
                    user = m_manager.ReadProfile(guid);
                }

                if (c_snapshot.Battletag != null && user != null && c_snapshot.Battletag == user.Profile.BattleTag)
                {
                    //the current user owns this snapshot
                    if (lblBuildName.Text == "NOT IMPORTED")
                    {
                        //not in the database
                        uxImportSnapshot.Visible = true;
                        uxEditBuildName.Visible = false;
                        uxDeleteSnapshot.Visible = false;
                    }
                    else
                    {
                        //is in the database
                        uxImportSnapshot.Visible = false;
                        uxEditBuildName.Visible = true;
                        uxDeleteSnapshot.Visible = true;
                    }
                    uxImportNewSnapshot.Visible = true;
                }
                else
                {
                    uxEditBuildName.Visible = false;
                    uxImportSnapshot.Visible = false;
                    uxDeleteSnapshot.Visible = false;
                    uxImportNewSnapshot.Visible = false;
                }

                #endregion
                
                //Session["User_0"] = m_user;
                //Session["Hero_0"] = m_hero;
                //Session["Snapshots_0"] = m_snapshots;
                //Session["Snapshot_0"] = c_snapshot;

                uxHeroName.DataTextField = "Name";
                uxHeroName.DataSource = m_user.Profile.Heroes;
                uxHeroName.SelectedValue = m_hero.Name;
                //uxAltHeroName.SelectedIndex = Session["hero_ddl_index_alt"] == null ? 0 : (int)Session["hero_ddl_index_alt"];
                uxHeroName.DataBind();

                uxVersion.DataTextField = "Name";
                uxVersion.DataSource = m_snapshots;
                uxVersion.SelectedIndex = Session["ddl_index"] == null ? 0 : (int)Session["ddl_index"];
                uxVersion.DataBind();
            }
            else
            {
                //m_user = (AC_User)Session["User_0"];
                //m_hero = (AC_Hero)Session["Hero_0"];
                //m_snapshots = (List<AC_BuildSnapshot>)Session["Snapshots_0"];
                //c_snapshot = (AC_BuildSnapshot)Session["Snapshot_0"];
            }
            //compare colors
            if (Request.RawUrl == "/BuildCompareView.aspx")
            {
                AC_BuildMark other_buildmark = ((AC_BuildSnapshot)Session["Snapshot_1"]).BuildMark;
                AC_BuildMark this_buildmark = ((AC_BuildSnapshot)Session["Snapshot_0"]).BuildMark;

                ////Set color for primary attribute
                //if (this_buildmark.Primary == other_buildmark.Primary)
                //{
                //    uxPrimaryAttribute.ForeColor = System.Drawing.Color.Black;
                //}
                //else if (this_buildmark.Primary > other_buildmark.Primary)
                //{
                //    uxPrimaryAttribute.ForeColor = System.Drawing.Color.Green;
                //}
                //else
                //{
                //    uxPrimaryAttribute.ForeColor = System.Drawing.Color.Red;
                //}

                //Set color for Damage
                if (this_buildmark.Damage == other_buildmark.Damage)
                {
                    uxDamage.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Damage > other_buildmark.Damage)
                {
                    uxDamage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxDamage.ForeColor = System.Drawing.Color.Red;
                }

                //Set color for Toughness
                if (this_buildmark.Toughness == other_buildmark.Toughness)
                {
                    uxToughness.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Toughness > other_buildmark.Toughness)
                {
                    uxToughness.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxToughness.ForeColor = System.Drawing.Color.Red;
                }

                //Set color for Recovery
                if (this_buildmark.Recovery == other_buildmark.Recovery)
                {
                    uxRecovery.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Recovery > other_buildmark.Recovery)
                {
                    uxRecovery.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxRecovery.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //uxPrimaryAttribute.ForeColor = System.Drawing.Color.Black;
                uxDamage.ForeColor = System.Drawing.Color.Black;
                uxToughness.ForeColor = System.Drawing.Color.Black;
                uxRecovery.ForeColor = System.Drawing.Color.Black;
            }
        }

        //Checks too see if images for items exist on the server
        //if not, returns false
        private bool CheckImageUrlExistence(AC_BuildSnapshot snapshot)
        {
            List<string> urls = new List<string>();
            bool ret_value = true;

            urls.Add(GetImageUrl(snapshot.Items["Head"]));
            urls.Add(GetImageUrl(snapshot.Items["Neck"]));
            urls.Add(GetImageUrl(snapshot.Items["Shoulders"]));
            urls.Add(GetImageUrl(snapshot.Items["Gloves"]));
            urls.Add(GetImageUrl(snapshot.Items["Chest"]));
            urls.Add(GetImageUrl(snapshot.Items["Bracers"]));
            urls.Add(GetImageUrl(snapshot.Items["Belt"]));
            urls.Add(GetImageUrl(snapshot.Items["LeftRing"]));
            urls.Add(GetImageUrl(snapshot.Items["RightRing"]));
            urls.Add(GetImageUrl(snapshot.Items["Pants"]));
            urls.Add(GetImageUrl(snapshot.Items["Boots"]));
            urls.Add(GetImageUrl(snapshot.Items["LeftHand"]));
            urls.Add(GetImageUrl(snapshot.Items["RightHand"]));

            if (urls.Contains("_Acquire_All_Images_"))
            {
                ret_value = false;
            }

            return ret_value;
        }
        //Gets the url of an image
        //if there is no item, the image is set to a placeholder image signifying an empty item slot
        private string GetImageUrl(AC_Item item)
        {
            string t_image_url = null;

            if(item != null)
            {
                if ( item.Image != null)
                {
                    using (MemoryStream m = new MemoryStream(item.Image))
                    {
                        byte[] imageBytes = m.ToArray();

                        File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + item.Name + ".png"), imageBytes);
                    }
                }
                if (File.Exists(HttpContext.Current.Server.MapPath("~/Images/" + item.Name + ".png")))
                {
                    t_image_url = "~/Images/" + item.Name + ".png";
                }
                else if(item.Name != "Empty")
                {
                    t_image_url = "_Acquire_All_Images_";
                }
                else
                {
                    t_image_url = "~/Images/placeholder.png";
                }
            }
            else
            {
                t_image_url = "~/Images/placeholder.png";
            }

            return t_image_url;
        }
        protected void uxEditBuildName_Click(object sender, EventArgs e)
        {
            uxSaveBuildName.Visible = true;
            uxBuildName.Visible = true;
            uxBuildName.Text = lblBuildName.Text;

            lblBuildName.Visible = false;
            uxEditBuildName.Visible = false;
            uxDeleteSnapshot.Visible = false;
        }
        protected void uxSaveBuildName_Click(object sender, EventArgs e)
        {
            //rename build snapshot
            m_manager.UpdateBuildSnapshotName(m_user, m_hero, c_snapshot, uxBuildName.Text);

            lblBuildName.Text = uxBuildName.Text;
            lblBuildName.Visible = true;
            uxEditBuildName.Visible = true;
            uxBuildName.Visible = false;
            uxSaveBuildName.Visible = false;
            uxDeleteSnapshot.Visible = true;

            Response.Redirect(Request.RawUrl);
        }
        protected void uxImportSnapshot_Click(object sender, EventArgs e)
        {
            //create hero in the database
            m_manager.CreateHero(m_user, m_hero);

            //store build snapshot in database
            c_snapshot.Name = "Temp Name";
            m_manager.CreateBuildSnapshot(m_user, m_hero, c_snapshot);

            Response.Redirect(Request.RawUrl);
        }
        protected void uxImportNewSnapshot_Click(object sender, EventArgs e)
        {
            //Import new snapshot via API
            AC_BuildSnapshot t_snapshot = new AC_BuildSnapshot();
            ApiManager.GetInstance().RetrieveHeroBuild(m_user, m_hero, ref t_snapshot);

            //store build snapshot in database
            t_snapshot.Name = "Temp Name";
            m_manager.CreateBuildSnapshot(m_user, m_hero, t_snapshot);

            //m_snapshots.Add(t_snapshot);

            Response.Redirect(Request.RawUrl);
        }
        protected void uxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddl_index"] = uxVersion.SelectedIndex;

            Response.Redirect(Request.RawUrl);
        }
        protected void uxDeleteSnapshot_Click(object sender, EventArgs e)
        {
            m_snapshots.RemoveAll(a => a.Name == c_snapshot.Name);

            m_manager.DeleteBuildSnapshot(m_user, m_hero, c_snapshot);

            Session["ddl_index"] = 0;
            Session["ddl_index_alt"] = 0;

            Response.Redirect(Request.RawUrl);
        }
        protected void uxHeroName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddl_index"] = 0;
            Session["Hero_0"] = m_user.Profile.Heroes.Find(a => a.Name == uxHeroName.SelectedValue);
            Session["User_0"] = m_user;
            //Session["Snapshots_0"] = m_snapshots;
            //Session["Snapshot_0"] = c_snapshot;

            Response.Redirect(Request.RawUrl);
        }
    }
}