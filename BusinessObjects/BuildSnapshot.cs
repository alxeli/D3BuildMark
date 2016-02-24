using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name and description of an item
    /// Used by: Hero
    /// Uses: BuildMark
    /// </summary>

    public class AC_BuildSnapshot
    {
        private string m_name;
        private string m_battletag;
        private AC_BuildMark m_build_mark;
        private Dictionary<string, AC_Item> m_items;
        private AC_Skill[] m_skills;
        
        public AC_BuildSnapshot()
        {
            m_name = null;
            m_battletag = null;
            m_build_mark = new AC_BuildMark();
            m_items = new Dictionary<string, AC_Item>();
            m_items.Add("Head", new AC_Item());
            m_items.Add("Neck", new AC_Item());
            m_items.Add("Shoulders", new AC_Item());
            m_items.Add("Gloves", new AC_Item());
            m_items.Add("Chest", new AC_Item());
            m_items.Add("Bracers", new AC_Item());
            m_items.Add("Belt", new AC_Item());
            m_items.Add("LeftRing", new AC_Item());
            m_items.Add("RightRing", new AC_Item());
            m_items.Add("Pants", new AC_Item());
            m_items.Add("Boots", new AC_Item());
            m_items.Add("LeftHand", new AC_Item());
            m_items.Add("RightHand", new AC_Item());
            m_skills = new AC_Skill[10];
            for(int i=0; i<10; i++)
            {
                m_skills[i] = new AC_Skill();
            }
        }
        public AC_BuildSnapshot(string name)
        {
            m_name = name;
            m_battletag = null;
            m_build_mark = new AC_BuildMark();
            m_items = new Dictionary<string, AC_Item>();
            m_items.Add("Head", new AC_Item());
            m_items.Add("Neck", new AC_Item());
            m_items.Add("Shoulders", new AC_Item());
            m_items.Add("Gloves", new AC_Item());
            m_items.Add("Chest", new AC_Item());
            m_items.Add("Bracers", new AC_Item());
            m_items.Add("Belt", new AC_Item());
            m_items.Add("LeftRing", new AC_Item());
            m_items.Add("RightRing", new AC_Item());
            m_items.Add("Pants", new AC_Item());
            m_items.Add("Boots", new AC_Item());
            m_items.Add("LeftHand", new AC_Item());
            m_items.Add("RightHand", new AC_Item());
            m_skills = new AC_Skill[10];
            for (int i = 0; i < 10; i++)
            {
                m_skills[i] = new AC_Skill();
            }
        }
        public AC_BuildSnapshot(string name, string battletag)
        {
            m_name = name;
            m_battletag = battletag;
            m_build_mark = new AC_BuildMark();
            m_items = new Dictionary<string, AC_Item>();
            m_items.Add("Head", new AC_Item());
            m_items.Add("Neck", new AC_Item());
            m_items.Add("Shoulders", new AC_Item());
            m_items.Add("Gloves", new AC_Item());
            m_items.Add("Chest", new AC_Item());
            m_items.Add("Bracers", new AC_Item());
            m_items.Add("Belt", new AC_Item());
            m_items.Add("LeftRing", new AC_Item());
            m_items.Add("RightRing", new AC_Item());
            m_items.Add("Pants", new AC_Item());
            m_items.Add("Boots", new AC_Item());
            m_items.Add("LeftHand", new AC_Item());
            m_items.Add("RightHand", new AC_Item());
            m_skills = new AC_Skill[10];
            for (int i = 0; i < 10; i++)
            {
                m_skills[i] = new AC_Skill();
            }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string Battletag
        {
            get { return m_battletag; }
            set { m_battletag = value; }
        }
        public AC_BuildMark BuildMark
        {
            get { return m_build_mark; }
            set { m_build_mark = value; }
        }
        public Dictionary<string, AC_Item> Items
        {
            get { return m_items; }
            set { m_items = value; }
        }
        public AC_Skill[] Skills
        {
            get { return m_skills; }
            set { m_skills = value; }
        }
    }
}
