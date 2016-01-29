using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxViewBuildSnapshot_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            BuildSnapshot snapshot = new BuildSnapshot();



            Response.Redirect("Buildview.aspx");
        }
    }
}