using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BuildSnapshot
    {
        private string m_name;
        private BuildMark m_build_mark;
        private Dictionary<string, Item> m_items;
        private Skill[] m_skills;

        public BuildSnapshot()
        {
            m_name = null;
            m_build_mark = new BuildMark();
            m_items = new Dictionary<string, Item>();
            m_items.Add("Head", null);
            m_items.Add("Neck", null);
            m_items.Add("Shoulders", null);
            m_items.Add("Gloves", null);
            m_items.Add("Chest", null);
            m_items.Add("Bracers", null);
            m_items.Add("Belt", null);
            m_items.Add("LeftRing", null);
            m_items.Add("RightRing", null);
            m_items.Add("Pants", null);
            m_items.Add("Boots", null);
            m_items.Add("LeftHand", null);
            m_items.Add("RightHand", null);
            m_skills = new Skill[10];
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public BuildMark BuildMark
        {
            get { return m_build_mark; }
            set { m_build_mark = value; }
        }
        public Dictionary<string, Item> Items
        {
            get { return m_items; }
            set { m_items = value; }
        }
        public Skill[] Skills
        {
            get { return m_skills; }
            set { m_skills = value; }
        }
    }
}
