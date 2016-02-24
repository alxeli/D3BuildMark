using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataManagement;

namespace D3BuildMarkSite.Users
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxCreateUserWizard.CreatedUser += uxCreateUserWizard_CreatedUser;
        }

        protected void uxCreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            DBManager db_manager = new DBManager();
            AC_User new_user = new AC_User();

            //initialize user object using membership information
            new_user.GUID = new Guid(Membership.GetUser((sender as CreateUserWizard).UserName).ProviderUserKey.ToString());
            new_user.Name = Membership.GetUser((sender as CreateUserWizard).UserName).UserName;

            //add new user to the database based on the GUID
            db_manager.CreateUser(new_user);
            db_manager.CreateProfile(new_user);

            //save user info in session
            Session["User"] = new_user;
        }
    }
}