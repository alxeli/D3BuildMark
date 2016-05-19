using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManagement;

namespace D3BuildMarkSite.Controls
{
    public partial class ViewSearchResults : System.Web.UI.UserControl
    {
        private string m_search_string = "";
        private DBManager m_manager = new DBManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            m_search_string = (string)Session["SearchString"];

            lblSearchString.Text += "\"" + m_search_string + "\"";

            if (!IsPostBack)
            {

                
            }

            uxHeroNameResults.Controls.Clear();
            uxClassResults.Controls.Clear();
            uxBattletagResults.Controls.Clear();
            foreach (DBManager.SearchResult result in m_manager.SearchHeroNames(m_search_string))
            {
                ViewSearchResult t_control = Page.LoadControl("~/Controls/ViewSearchResult.ascx") as ViewSearchResult;
                t_control.m_result = result;
                uxHeroNameResults.Controls.Add(t_control);
                uxHeroNameResults.Controls.Add(new LiteralControl("<br />"));
            }

            foreach (DBManager.SearchResult result in m_manager.SearchClassNames(m_search_string))
            {
                ViewSearchResult t_control = Page.LoadControl("~/Controls/ViewSearchResult.ascx") as ViewSearchResult;
                t_control.m_result = result;
                uxClassResults.Controls.Add(t_control);
                uxClassResults.Controls.Add(new LiteralControl("<br />"));
            }

            foreach (DBManager.SearchResult result in m_manager.SearchBattletags(m_search_string))
            {
                ViewSearchResult t_control = Page.LoadControl("~/Controls/ViewSearchResult.ascx") as ViewSearchResult;
                t_control.m_result = result;
                uxBattletagResults.Controls.Add(t_control);
                uxBattletagResults.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}