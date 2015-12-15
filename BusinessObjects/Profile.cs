using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Profile
    {
        private string m_battle_tag;
        private List<Hero> m_heroes;

        public Profile()
        {
            m_battle_tag = null;
            m_heroes = new List<Hero>();
        }

        public string BattleTag
        {
            get { return m_battle_tag; }
            set { m_battle_tag = value; }
        }
        public List<Hero> Heroes
        {
            get { return m_heroes; }
            set { m_heroes = value; }
        }
    }
}
