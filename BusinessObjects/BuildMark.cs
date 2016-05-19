using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class AC_BuildMark
    {
        private int m_score_single;
        private int m_score_multiple;
        private int m_strength;
        private int m_dexterity;
        private int m_intelligence;
        private int m_vitality;
        private int m_damage;
        private int m_toughness;
        private int m_recovery;
        private int m_life;
        private bool m_is_calculated;
        private DateTime m_date_last_calculated;
        private ZTn.BNet.D3.Heroes.HeroStats m_stats;
        private int difficulty = 1;
        private float c_health = 2.0F;
        private float c_damage = 1.3F;
        private Int64 toughness = 0;
        private const float DAMAGE_MULT = 0.132F;
        private const float HEALTH_MULT = 0.17F;

        public AC_BuildMark()
        {
            m_score_single = 0;
            m_score_multiple = 0;
            m_strength = 0;
            m_dexterity = 0;
            m_intelligence = 0;
            m_vitality = 0;
            m_damage = 0;
            m_toughness = 0;
            m_recovery = 0;
            m_life = 0;
            m_is_calculated = false;
            m_stats = null;
        }
        public AC_BuildMark(ZTn.BNet.D3.Heroes.HeroStats stats, string hero_class)
        {
            m_score_single = 0;
            m_score_multiple = 0;

            m_strength = stats.Strength;
            m_dexterity = stats.Dexterity;
            m_intelligence = stats.Intelligence;
            m_vitality = stats.Vitality;

            m_damage = (int)Math.Round(stats.Damage);
            m_toughness = (int)Math.Round(stats.Toughness);
            m_recovery = (int)Math.Round(stats.Healing);

            m_life = (int)stats.Life;

            //if (hero_class == "Monk" || hero_class == "DemonHunter")
            //{
            //    m_primary = stats.Dexterity;
            //}
            //else if (hero_class == "Crusader" || hero_class == "Barbarian")
            //{
            //    m_primary = stats.Strength;
            //}
            //else
            //{
            //    m_primary = stats.Intelligence;
            //}

            m_is_calculated = false;
            m_stats = stats;
        }
        public AC_BuildMark(int damage, int toughness, int recovery)
        {
            m_score_single = 0;
            m_score_multiple = 0;
            m_damage = damage;
            m_toughness = toughness;
            m_recovery = recovery;
            m_is_calculated = false;
            m_stats = null;
        }

        private void ResetCalculationVariables()
        {
            difficulty = 1;
            c_health = 2.0F;
            c_damage = 1.3F;
            toughness = (Int64)m_toughness;
        }

        public void Calculate()
        {
            //temporary over-simplified algorithm
            float basic_score = (float)(((((m_damage / 100000) * m_toughness)/10000) * (((m_damage / 100000) * m_recovery)/100000))/100000)/100;

            //real algorithm
            ResetCalculationVariables();

            //single target simulation
            while (toughness > 0) //while hero is alive
            {
                Int64 enemy_health = (Int64)(c_health * 6500);
                Int64 enemy_damage = (Int64)(c_damage * 1000);

                while (enemy_health > 0 && toughness > 0) //while enemy is alive and the hero is alive
                {
                    //enemy attacks
                    toughness -= enemy_damage;

                    //heal to no higher than full health
                    toughness = ((toughness + m_recovery) > m_toughness) ? m_toughness : (toughness + m_recovery);

                    //hero attacks enemy
                    enemy_health -= m_damage;
                }

                if(toughness > 0)
                {
                    difficulty++;
                    c_damage += c_damage * DAMAGE_MULT;
                    c_health += c_health * HEALTH_MULT;
                }
            }

            m_score_single = (int)(difficulty * 1.333F) - (int)(((2F - basic_score)/3.4F) * difficulty) - 10;

            ResetCalculationVariables();

            //multiple target simulation
            while (toughness > 0) //while hero is alive
            {
                Int64 enemy_health = (Int64)(c_health * 6000);
                Int64 enemy_damage = (Int64)(c_damage * 1000);

                while (enemy_health > 0 && toughness > 0) //while enemy is alive and the hero is alive
                {
                    //enemy attacks
                    toughness -= enemy_damage * 5;

                    //heal to no higher than full health
                    toughness = ((toughness + m_recovery) > m_toughness) ? m_toughness : (toughness + m_recovery);

                    //hero attacks enemy
                    enemy_health -= m_damage;
                }

                if (toughness > 0)
                {
                    difficulty++;
                    c_damage += c_damage * DAMAGE_MULT;
                    c_health += c_health * HEALTH_MULT;
                }
            }

            m_score_multiple = difficulty;

            //set the date upon completion of calculation
            m_date_last_calculated = DateTime.Now;
        }

        public int ScoreSingle
        {
            get { return m_score_single; }
            set { m_score_single = value; }
        }
        public int ScoreMultiple
        {
            get { return m_score_multiple; }
            set { m_score_multiple = value; }
        }
        public int Strength
        {
            get { return m_strength; }
            set { m_strength = value; }
        }
        public int Dexterity
        {
            get { return m_dexterity; }
            set { m_dexterity = value; }
        }
        public int Intelligence
        {
            get { return m_intelligence; }
            set { m_intelligence = value; }
        }
        public int Vitality
        {
            get { return m_vitality; }
            set { m_vitality = value; }
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
        public int Life
        {
            get { return m_life; }
            set { m_life = value; }
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
