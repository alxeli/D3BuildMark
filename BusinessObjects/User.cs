using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        private Guid m_id;
        private string m_name;
        private Profile m_profile;

        public User()
        {
            m_name = null;
            m_profile = new Profile();
        }
        public User(string name)
        {
            m_name = name;
            m_profile = new Profile();
        }
        public User(Guid id, string name)
        {
            m_id = id;
            m_name = name;
            m_profile = new Profile();
        }

        public Guid GUID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public Profile Profile
        {
            get { return m_profile; }
            set { m_profile = value; }
        }
    }
}
