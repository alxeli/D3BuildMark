using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BuildMark
    {
        private string m_score;
        private string m_damage;
        private string m_toughness;
        private string m_recovery;
        private bool m_is_calculated;
        private DateTime m_date_last_calculated;

        public BuildMark()
        {
            m_score = null;
            m_damage = null;
            m_toughness = null;
            m_recovery = null;
            m_is_calculated = false;
        }

        public void Calculate()
        {

            //set the date upon completion of calculation
            m_date_last_calculated = DateTime.Now;
        }

        public string Score
        {
            get { return m_score; }
            set { m_score = value; }
        }
        public string Damage
        {
            get { return m_damage; }
            set { m_damage = value; }
        }
        public string Toughness
        {
            get { return m_toughness; }
            set { m_toughness = value; }
        }
        public string Recovery
        {
            get { return m_recovery; }
            set { m_recovery = value; }
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
