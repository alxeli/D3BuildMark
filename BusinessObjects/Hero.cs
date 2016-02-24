using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name, class, and build snapshots for a hero.
    /// Used by: Profile.
    /// Uses: BuildSnapshot.
    /// </summary>

    public class AC_Hero
    {
        private string m_name;
        private string m_class;
        private List<AC_BuildSnapshot> m_build_snapshots;
        private bool m_is_stored;

        public AC_Hero()
        {
            m_name = null;
            m_class = null;
            m_build_snapshots = new List<AC_BuildSnapshot>();
        }
        public AC_Hero(string name, string class_name)
        {
            m_name = name;
            m_class = class_name;
            m_build_snapshots = new List<AC_BuildSnapshot>();
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string Class
        {
            get { return m_class; }
            set { m_class = value; }
        }
        public List<AC_BuildSnapshot> BuildSnapshots
        {
            get { return m_build_snapshots; }
            set { m_build_snapshots = value; }
        }
        public bool IsStored
        {
            get { return m_is_stored; }
            set { m_is_stored = value; }
        }
    }
}
