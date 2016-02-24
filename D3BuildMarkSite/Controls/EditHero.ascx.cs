using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataManagement;

namespace D3BuildMarkSite.Controls
{
    public partial class EditHero : System.Web.UI.UserControl
    {
        private AC_Hero m_hero = null;
        public EventHandler AddClickEvent;
        public EventHandler RemoveClickEvent;
        protected override void OnInit(EventArgs e)
        {
            lblHeroClass.Text = m_hero.Class;
            uxHeroLink.Text = m_hero.Name;

            uxAdd.Visible = !m_hero.IsStored;
            uxRemove.Visible = m_hero.IsStored;

            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public AC_Hero Hero
        {
            get { return m_hero; }
            set { m_hero = value; }
        }
        public bool IsStored
        {
            get { return m_hero.IsStored; }
            set { m_hero.IsStored = value; }
        }

        protected void uxAdd_Click(object sender, EventArgs e)
        {
            if(AddClickEvent != null)
            {
                AddClickEvent(this, e);
            }
        }

        protected void uxRemove_Click(object sender, EventArgs e)
        {
            if (RemoveClickEvent != null)
            {
                RemoveClickEvent(this, e);
            }
        }

        protected void uxHeroLink_Click(object sender, EventArgs e)
        {
            Session["Hero_0"] = m_hero;
            Session["Hero_1"] = m_hero;
            Session["ddl_index"] = 0;
            Session["ddl_index_alt"] = 0;

            Response.Redirect("~/Buildview.aspx");
        }
    }
}