﻿using System;
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

        }

        protected void uxEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/AccountSettings.aspx");
        }
    }
}