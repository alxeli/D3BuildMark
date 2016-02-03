using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace D3BuildMarkSite
{
    public partial class Buildview : System.Web.UI.Page
    {
        protected AC_BuildSnapshot m_snapshot = null;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            m_snapshot = (AC_BuildSnapshot)Session["BuildSnapshot"];

        }
    }
}