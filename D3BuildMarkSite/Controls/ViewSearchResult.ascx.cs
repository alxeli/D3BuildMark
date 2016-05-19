using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManagement;

namespace D3BuildMarkSite.Controls
{
    public partial class ViewSearchResult : System.Web.UI.UserControl
    {
        public DBManager.SearchResult m_result { get; set; }
        private DBManager m_manager = new DBManager();

        //protected override void OnInit(EventArgs e)
        //{

        //    base.OnInit(e);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblBattletag.Text = m_result.User.Profile.BattleTag;
                lblHeroClass.Text = m_result.Hero.Class;
                uxHeroLink2.Text = m_result.Hero.Name;
            }
        }
        
        protected void uxHeroLink2_Click(object sender, EventArgs e)
        {
            Session["Hero_1"] = m_result.Hero;
            m_result.User.Profile.Heroes = m_manager.ReadHeroes(m_result.User.GUID, m_result.User.Profile.BattleTag);
            Session["User_1"] = m_result.User;
            Session["ddl_index"] = 0;
            Session["ddl_index_alt"] = 0;

            Response.Redirect("~/Buildview.aspx");
        }
    }
}