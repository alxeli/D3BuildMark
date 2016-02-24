using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class AC_BuildMark
    {
        private int m_score;
        private int m_damage;
        private int m_toughness;
        private int m_recovery;
        private int m_primary;
        private bool m_is_calculated;
        private DateTime m_date_last_calculated;
        private ZTn.BNet.D3.Heroes.HeroStats m_stats;

        public AC_BuildMark()
        {
            m_score = 0;
            m_damage = 0;
            m_toughness = 0;
            m_recovery = 0;
            m_primary = 0;
            m_is_calculated = false;
            m_stats = null;
        }
        public AC_BuildMark(ZTn.BNet.D3.Heroes.HeroStats stats, string hero_class)
        {
            m_score = 0;
            m_damage = (int)Math.Round(stats.Damage);
            m_toughness = (int)Math.Round(stats.Toughness);
            m_recovery = (int)Math.Round(stats.Healing);

            if (hero_class == "Monk" || hero_class == "DemonHunter")
            {
                m_primary = stats.Dexterity;
            }
            else if (hero_class == "Crusader" || hero_class == "Barbarian")
            {
                m_primary = stats.Strength;
            }
            else
            {
                m_primary = stats.Intelligence;
            }
            m_is_calculated = false;
            m_stats = stats;
        }
        public AC_BuildMark(int damage, int toughness, int recovery)
        {
            m_score = 0;
            m_damage = damage;
            m_toughness = toughness;
            m_recovery = recovery;
            m_is_calculated = false;
            m_stats = null;
        }

        public void Calculate()
        {
            //TODO: implement benchmark algorithm

            //set the date upon completion of calculation
            m_date_last_calculated = DateTime.Now;
        }

        public int Score
        {
            get { return m_score; }
            set { m_score = value; }
        }
        public int Damage
        {
            get { return m_damage; }
            set { m_damage = value; }
        }
        public int Toughness
        {
            get { return m_toughness; }
            set { m_toughness = value; }
        }
        public int Recovery
        {
            get { return m_recovery; }
            set { m_recovery = value; }
        }
        public int Primary
        {
            get { return m_primary; }
            set { m_primary = value; }
        }
        public bool isCalculated
        {
            get { return m_is_calculated; }
            set { m_is_calculated = value; }
        }
        public DateTime DateLastCalculated
        {
            get
            {
                if(m_is_calculated)
                {
                    return m_date_last_calculated;
                }
                else
                {
                    return new DateTime(2015, 12, 14, 15, 49, 15, DateTimeKind.Local);
                }
            }
            set{ m_date_last_calculated = value; }
        }
    }
}
