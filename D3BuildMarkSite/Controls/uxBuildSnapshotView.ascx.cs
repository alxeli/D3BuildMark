using System;
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
        BuildSnapshot m_snapshot = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_snapshot = (BuildSnapshot)Session["Snapshot_0"];

                lblBuildName.Text = m_snapshot.Name;
                lblBattletag.Text = "not retrieved from api.";
                lblHead.Text = m_snapshot.Items["Head"].Name;
                lblNeck.Text = m_snapshot.Items["Neck"].Name;
                lblShoulders.Text = m_snapshot.Items["Shoulders"].Name;
                lblGloves.Text = m_snapshot.Items["Gloves"].Name;
                lblChest.Text = m_snapshot.Items["Chest"].Name;
                lblBracers.Text = m_snapshot.Items["Bracers"].Name;
                lblBelt.Text = m_snapshot.Items["Belt"].Name;
                lblLeftRing.Text = m_snapshot.Items["LeftRing"].Name;
                lblRightRing.Text = m_snapshot.Items["RightRing"].Name;
                lblPants.Text = m_snapshot.Items["Pants"].Name;
                lblBoots.Text = m_snapshot.Items["Boots"].Name;
                lblLeftHand.Text = m_snapshot.Items["LeftHand"].Name;
                lblRightHand.Text = m_snapshot.Items["RightHand"].Name;

                //Attributes ...
                //Version ..
            }
        }
    }
}