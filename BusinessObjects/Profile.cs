﻿using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class AC_Profile
    {
        private string m_battle_tag;
        private List<AC_Hero> m_heroes;

        public AC_Profile()
        {
            m_battle_tag = null;
            m_heroes = new List<AC_Hero>();
        }
        public AC_Profile(string battle_tag)
        {
            m_battle_tag = battle_tag;
            m_heroes = new List<AC_Hero>();
        }

        public string BattleTag
        {
            get { return m_battle_tag; }
            set { m_battle_tag = value; }
        }
        public List<AC_Hero> Heroes
        {
            get { return m_heroes; }
            set { m_heroes = value; }
        }
    }
}
