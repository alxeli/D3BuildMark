using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name, class, and build snapshots for a hero
    /// Used by: Profile
    /// Uses: BuildSnapshot
    /// </summary>

    public class Hero
    {
        private string m_name;
        private string m_class;
        private List<BuildSnapshot> m_build_snapshots;

        public Hero()
        {
            m_name = null;
            m_class = null;
            m_build_snapshots = new List<BuildSnapshot>();
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string Class
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public List<BuildSnapshot> BuildSnapshots
        {
            get { return m_build_snapshots; }
            set { m_build_snapshots = value; }
        }
    }
}
