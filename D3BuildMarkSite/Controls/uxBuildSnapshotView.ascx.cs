using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace D3BuildMarkSite.Controls
{
    public partial class uxBuildSnapshotView : System.Web.UI.UserControl
    {
        AC_BuildSnapshot m_snapshot = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_snapshot = (AC_BuildSnapshot)Session["Snapshot_0"];

                lblBuildName.Text = m_snapshot.Name;
                lblBattletag.Text = m_snapshot.Battletag;
                lblHead.Text = m_snapshot.Items["Head"].Name;
                uxHeadImage.ImageUrl = GetImageUrl(m_snapshot.Items["Head"].Image);
                lblNeck.Text = m_snapshot.Items["Neck"].Name;
                uxNeckImage.ImageUrl = GetImageUrl(m_snapshot.Items["Neck"].Image);
                lblShoulders.Text = m_snapshot.Items["Shoulders"].Name;
                uxShouldersImage.ImageUrl = GetImageUrl(m_snapshot.Items["Shoulders"].Image);
                lblGloves.Text = m_snapshot.Items["Gloves"].Name;
                uxGlovesImage.ImageUrl = GetImageUrl(m_snapshot.Items["Gloves"].Image);
                lblChest.Text = m_snapshot.Items["Chest"].Name;
                uxChestImage.ImageUrl = GetImageUrl(m_snapshot.Items["Chest"].Image);
                lblBracers.Text = m_snapshot.Items["Bracers"].Name;
                uxBracersImage.ImageUrl = GetImageUrl(m_snapshot.Items["Bracers"].Image);
                lblBelt.Text = m_snapshot.Items["Belt"].Name;
                uxBeltImage.ImageUrl = GetImageUrl(m_snapshot.Items["Belt"].Image);
                lblLeftRing.Text = m_snapshot.Items["LeftRing"].Name;
                uxLeftRingImage.ImageUrl = GetImageUrl(m_snapshot.Items["LeftRing"].Image);
                lblRightRing.Text = m_snapshot.Items["RightRing"].Name;
                uxRightRingImage.ImageUrl = GetImageUrl(m_snapshot.Items["RightRing"].Image);
                lblPants.Text = m_snapshot.Items["Pants"].Name;
                uxPantsImage.ImageUrl = GetImageUrl(m_snapshot.Items["Pants"].Image);
                lblBoots.Text = m_snapshot.Items["Boots"].Name;
                uxBootsImage.ImageUrl = GetImageUrl(m_snapshot.Items["Boots"].Image);
                lblLeftHand.Text = m_snapshot.Items["LeftHand"].Name;
                uxLeftHandImage.ImageUrl = GetImageUrl(m_snapshot.Items["LeftHand"].Image);
                lblRightHand.Text = m_snapshot.Items["RightHand"].Name;
                uxRightHandImage.ImageUrl = GetImageUrl(m_snapshot.Items["RightHand"].Image);

                //Attributes ...
                //Version ..
                uxItemSummary.Text += m_snapshot.Items["Head"].Name + "\n";
                uxItemSummary.Text += m_snapshot.Items["Head"].Attributes;
            }
        }
        private string GetImageUrl(byte[] image)
        {
            byte[] buffer = image;
            string t_image_url = null;
            string base64String = null;

            if (buffer != null)
            {
                using (MemoryStream m = new MemoryStream(buffer))
                {
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String                    
                    base64String = Convert.ToBase64String(imageBytes);
                }
                if (!string.IsNullOrEmpty(base64String))
                {
                    t_image_url = "data:image/jpeg;base64," + base64String;
                }
            }

            return t_image_url;
        }
        
    }
}