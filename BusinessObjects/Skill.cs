using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name and description of a skill.
    /// Used by: BuildSnapshot.
    /// Uses: n/a.
    /// </summary>

    public class Skill
    {
        private string m_name;
        private string m_description;

        public Skill()
        {
            m_name = null;
            m_description = null;
        }
        public Skill(string name, string description)
        {
            m_name = name;
            m_description = description;
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
