using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace D3BuildMarkSite.App_Master
{
    public partial class BaseTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxSearch.Attributes.Add("onkeypress", "uxSearchButton_Click()");
        }

        protected void uxEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/AccountSettings.aspx");
        }

        protected void uxSearchButton_Click(object sender, EventArgs e)
        {
            Session["SearchString"] = uxSearch.Text;
            Response.Redirect("~/SearchResults.aspx");
        }
    }
}