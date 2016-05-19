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
    public partial class ViewBuildSnapshotAlt : System.Web.UI.UserControl
    {
        AC_User m_user = null;
        AC_Hero m_hero = null;
        List<AC_BuildSnapshot> m_snapshots = null;
        AC_BuildSnapshot c_snapshot = null;
        DBManager m_manager = new DBManager();

        protected override void OnInit(EventArgs e)
        {
            //Session["ddl_index_alt"] = 0;
            m_user = (AC_User)Session["User_1"];
            m_hero = (AC_Hero)Session["Hero_1"];
            m_snapshots = (List<AC_BuildSnapshot>)Session["Snapshots_1"];
            c_snapshot = (AC_BuildSnapshot)Session["Snapshot_1"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (m_snapshots == null)
                {
                    m_snapshots = new List<AC_BuildSnapshot>();
                }
                if (c_snapshot == null)
                {
                    c_snapshot = new AC_BuildSnapshot();
                }

                #region data retrieval stuff

                if (m_hero.IsStored == true)
                {
                    //pull all snapshots from DB
                    m_snapshots = m_manager.ReadBuildSnapshots(m_user.GUID, m_user.Profile.BattleTag, m_hero.Name);
                    Session["Snapshots_1"] = m_snapshots;

                    //get currently selected snapshot
                    c_snapshot = m_snapshots[Session["ddl_index_alt"] == null ? 0 : (int)Session["ddl_index_alt"]];   
                    Session["Snapshot_1"] = c_snapshot;

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
                uxAltHeadImage.ImageUrl = GetImageUrl(c_snapshot.Items["Head"]);
                uxAltNeckImage.ImageUrl = GetImageUrl(c_snapshot.Items["Neck"]);
                uxAltShouldersImage.ImageUrl = GetImageUrl(c_snapshot.Items["Shoulders"]);
                uxAltGlovesImage.ImageUrl = GetImageUrl(c_snapshot.Items["Gloves"]);
                uxAltChestImage.ImageUrl = GetImageUrl(c_snapshot.Items["Chest"]);
                uxAltBracersImage.ImageUrl = GetImageUrl(c_snapshot.Items["Bracers"]);
                uxAltBeltImage.ImageUrl = GetImageUrl(c_snapshot.Items["Belt"]);
                uxAltLeftRingImage.ImageUrl = GetImageUrl(c_snapshot.Items["LeftRing"]);
                uxAltRightRingImage.ImageUrl = GetImageUrl(c_snapshot.Items["RightRing"]);
                uxAltPantsImage.ImageUrl = GetImageUrl(c_snapshot.Items["Pants"]);
                uxAltBootsImage.ImageUrl = GetImageUrl(c_snapshot.Items["Boots"]);
                uxAltLeftHandImage.ImageUrl = GetImageUrl(c_snapshot.Items["LeftHand"]);
                uxAltRightHandImage.ImageUrl = GetImageUrl(c_snapshot.Items["RightHand"]);

                //set attribute textbox values for hovering over items
                uxAltNeckAttributes.Text = c_snapshot.Items["Neck"].Name + "\n" + c_snapshot.Items["Neck"].Attributes;
                uxAltShouldersAttributes.Text = c_snapshot.Items["Shoulders"].Name + "\n" + c_snapshot.Items["Shoulders"].Attributes;
                uxAltBracersAttributes.Text = c_snapshot.Items["Bracers"].Name + "\n" + c_snapshot.Items["Bracers"].Attributes;
                uxAltBeltAttributes.Text = c_snapshot.Items["Belt"].Name + "\n" + c_snapshot.Items["Belt"].Attributes;
                uxAltLeftRingAttributes.Text = c_snapshot.Items["LeftRing"].Name + "\n" + c_snapshot.Items["LeftRing"].Attributes;
                uxAltRightRingAttributes.Text = c_snapshot.Items["RightRing"].Name + "\n" + c_snapshot.Items["RightRing"].Attributes;
                uxAltPantsAttributes.Text = c_snapshot.Items["Pants"].Name + "\n" + c_snapshot.Items["Pants"].Attributes;
                uxAltBootsAttributes.Text = c_snapshot.Items["Boots"].Name + "\n" + c_snapshot.Items["Boots"].Attributes;
                uxAltLeftHandAttributes.Text = c_snapshot.Items["LeftHand"].Name + "\n" + c_snapshot.Items["LeftHand"].Attributes;
                uxAltRightHandAttributes.Text = c_snapshot.Items["RightHand"].Name + "\n" + c_snapshot.Items["RightHand"].Attributes;
                uxAltChestAttributes.Text = c_snapshot.Items["Chest"].Name + "\n" + c_snapshot.Items["Chest"].Attributes;
                uxAltGlovesAttributes.Text = c_snapshot.Items["Gloves"].Name + "\n" + c_snapshot.Items["Gloves"].Attributes;
                uxAltHeadAttributes.Text = c_snapshot.Items["Head"].Name + "\n" + c_snapshot.Items["Head"].Attributes;
                
                uxAltStrength.Text = c_snapshot.BuildMark.Strength.ToString("0,0");
                uxAltDexterity.Text = c_snapshot.BuildMark.Dexterity.ToString("0,0");
                uxAltIntelligence.Text = c_snapshot.BuildMark.Intelligence.ToString("0,0");
                uxAltVitality.Text = c_snapshot.BuildMark.Vitality.ToString("0,0");

                uxAltDamage.Text = c_snapshot.BuildMark.Damage.ToString("0,0");
                uxAltToughness.Text = c_snapshot.BuildMark.Toughness.ToString("0,0");
                uxAltRecovery.Text = c_snapshot.BuildMark.Recovery.ToString("0,0");

                uxAltLife.Text = c_snapshot.BuildMark.Life.ToString("0,0");

                uxAltBuildMarkSingle.Text = c_snapshot.BuildMark.ScoreSingle.ToString("0,0");
                uxAltBuildMarkMultiple.Text = c_snapshot.BuildMark.ScoreMultiple.ToString("0,0");

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
                        //uxAltImportSnapshot.Visible = true;
                        uxAltEditBuildName.Visible = false;
                        uxAltDeleteSnapshot.Visible = false;
                    }
                    else
                    {
                        //is in the database
                        //uxAltImportSnapshot.Visible = false;
                        uxAltEditBuildName.Visible = true;
                        uxAltDeleteSnapshot.Visible = true;
                    }
                    uxAltImportNewSnapshot.Visible = true;
                }
                else
                {
                    uxAltEditBuildName.Visible = false;
                    //uxAltImportSnapshot.Visible = false;
                    uxAltDeleteSnapshot.Visible = false;
                    uxAltImportNewSnapshot.Visible = false;
                }

                #endregion

                //Session["User_1"] = m_user;
                //Session["Hero_1"] = m_hero;
                //Session["Snapshots_1"] = m_snapshots;
                //Session["Snapshot_1"] = c_snapshot;

                if (m_hero.IsStored == true)
                {
                    uxAltHeroName.DataTextField = "Name";
                    uxAltHeroName.DataSource = m_user.Profile.Heroes;
                    uxAltHeroName.SelectedValue = m_hero.Name;
                    //uxAltHeroName.SelectedIndex = Session["hero_ddl_index_alt"] == null ? 0 : (int)Session["hero_ddl_index_alt"];
                    uxAltHeroName.DataBind();

                    uxAltVersion.DataTextField = "Name";
                    uxAltVersion.DataSource = m_snapshots;
                    //uxAltVersion.SelectedValue = c_snapshot.Name;
                    uxAltVersion.SelectedIndex = Session["ddl_index_alt"] == null ? 0 : (int)Session["ddl_index_alt"];
                    uxAltVersion.DataBind();
                }
            }
            else
            {
                //m_user = (AC_User)Session["User_1"];
                //m_hero = (AC_Hero)Session["Hero_1"];
                //m_snapshots = (List<AC_BuildSnapshot>)Session["Snapshots_1"];
                //c_snapshot = (AC_BuildSnapshot)Session["Snapshot_1"];
            }
            //compare colors
            if (Request.RawUrl == "/BuildCompareView.aspx")
            {
                AC_BuildMark other_buildmark = ((AC_BuildSnapshot)Session["Snapshot_0"]).BuildMark;
                AC_BuildMark this_buildmark = ((AC_BuildSnapshot)Session["Snapshot_1"]).BuildMark;

                ////Set color for primary attribute
                //if (this_buildmark.Primary == other_buildmark.Primary)
                //{
                //    uxAltPrimaryAttribute.ForeColor = System.Drawing.Color.Black;
                //}
                //else if (this_buildmark.Primary > other_buildmark.Primary)
                //{
                //    uxAltPrimaryAttribute.ForeColor = System.Drawing.Color.Green;
                //}
                //else
                //{
                //    uxAltPrimaryAttribute.ForeColor = System.Drawing.Color.Red;
                //}

                //Set color for Damage
                if (this_buildmark.Damage == other_buildmark.Damage)
                {
                    uxAltDamage.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Damage > other_buildmark.Damage)
                {
                    uxAltDamage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxAltDamage.ForeColor = System.Drawing.Color.Red;
                }

                //Set color for Toughness
                if (this_buildmark.Toughness == other_buildmark.Toughness)
                {
                    uxAltToughness.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Toughness > other_buildmark.Toughness)
                {
                    uxAltToughness.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxAltToughness.ForeColor = System.Drawing.Color.Red;
                }

                //Set color for Recovery
                if (this_buildmark.Recovery == other_buildmark.Recovery)
                {
                    uxAltRecovery.ForeColor = System.Drawing.Color.Black;
                }
                else if (this_buildmark.Recovery > other_buildmark.Recovery)
                {
                    uxAltRecovery.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    uxAltRecovery.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //uxAltPrimaryAttribute.ForeColor = System.Drawing.Color.Black;
                uxAltDamage.ForeColor = System.Drawing.Color.Black;
                uxAltToughness.ForeColor = System.Drawing.Color.Black;
                uxAltRecovery.ForeColor = System.Drawing.Color.Black;
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

            if (item != null)
            {
                if (item.Image != null)
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
                else if (item.Name != "Empty")
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
        protected void uxAltEditBuildName_Click(object sender, EventArgs e)
        {
            uxAltSaveBuildName.Visible = true;
            uxAltBuildName.Visible = true;
            uxAltBuildName.Text = lblBuildName.Text;

            lblBuildName.Visible = false;
            uxAltEditBuildName.Visible = false;
            uxAltDeleteSnapshot.Visible = false;
        }
        protected void uxAltSaveBuildName_Click(object sender, EventArgs e)
        {
            //rename build snapshot
            m_manager.UpdateBuildSnapshotName(m_user, m_hero, c_snapshot, uxAltBuildName.Text);

            lblBuildName.Text = uxAltBuildName.Text;
            lblBuildName.Visible = true;
            uxAltEditBuildName.Visible = true;
            uxAltBuildName.Visible = false;
            uxAltSaveBuildName.Visible = false;
            uxAltDeleteSnapshot.Visible = true;

            Response.Redirect(Request.RawUrl);
        }
        //protected void uxAltImportSnapshot_Click(object sender, EventArgs e)
        //{
        //    //create hero in the database
        //    m_manager.CreateHero(m_user, m_hero);

        //    //store build snapshot in database
        //    c_snapshot.Name = "Temp Name";
        //    m_manager.CreateBuildSnapshot(m_user, m_hero, c_snapshot);

        //    Response.Redirect(Request.RawUrl);
        //}
        protected void uxAltImportNewSnapshot_Click(object sender, EventArgs e)
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
        protected void uxAltVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddl_index_alt"] = uxAltVersion.SelectedIndex;

            Response.Redirect(Request.RawUrl);
        }
        protected void uxAltDeleteSnapshot_Click(object sender, EventArgs e)
        {
            m_snapshots.RemoveAll(a => a.Name == c_snapshot.Name);

            m_manager.DeleteBuildSnapshot(m_user, m_hero, c_snapshot);

            Session["ddl_index_alt"] = 0;
            Session["ddl_index"] = 0;

            Response.Redirect(Request.RawUrl);
        }
        protected void uxAltCompare_Click(object sender, EventArgs e)
        {
            Session["ddl_index_alt"] = 0;
            Session["ddl_index"] = 0;
            
            Session["User_0"] = m_user;
            Session["Hero_0"] = m_hero;
            Session["Snapshots_0"] = m_snapshots;
            Session["Snapshot_0"] = c_snapshot;

            Response.Redirect("~/BuildCompareView.aspx");
        }
        protected void uxAltHeroName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddl_index_alt"] = 0;

            Session["Hero_1"] = m_user.Profile.Heroes.Find(a => a.Name == uxAltHeroName.SelectedValue);
            m_hero = (AC_Hero)Session["Hero_1"];
            Session["User_1"] = m_user;

            //pull all snapshots from DB
            m_snapshots = m_manager.ReadBuildSnapshots(m_user.GUID, m_user.Profile.BattleTag, m_hero.Name);
            Session["Snapshots_1"] = m_snapshots;

            //get currently selected snapshot
            c_snapshot = m_snapshots[Session["ddl_index_alt"] == null ? 0 : (int)Session["ddl_index_alt"]];
            Session["Snapshot_1"] = c_snapshot;

            //Session["Snapshots_1"] = m_snapshots;
            //Session["Snapshot_1"] = c_snapshot;

            Response.Redirect(Request.RawUrl);
        }

        protected void uxRunBuildMark_Click(object sender, EventArgs e)
        {
            BuildMarkManager.GetInstance().Add(m_user, m_hero, c_snapshot);

            Response.Redirect(Request.RawUrl);
        }
    }
}