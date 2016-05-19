using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagement;

namespace BusinessObjects
{
    /// <summary>
    /// Manages the processing and persistance of build benchmarks.
    /// Pattern: Singleton
    /// </summary>
    public class BuildMarkManager
    {
        private static BuildMarkManager _instance = null;
        private static object _lock = new object();
        private object _queue_sync = new object();
        private Queue<AC_UserHeroBuildMark> m_build_marks = null;
        bool m_isRunning = false;
        private DBManager m_manager = new DBManager();

        private BuildMarkManager()
        {
            m_build_marks = new Queue<AC_UserHeroBuildMark>();
        }

        public static BuildMarkManager GetInstance()
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new BuildMarkManager();
                    }
                }
            }
            return _instance;
        }

        public void Add(AC_User user, AC_Hero hero, AC_BuildSnapshot snapshot)
        {
            lock (_queue_sync)
            {
                m_build_marks.Enqueue(new AC_UserHeroBuildMark(user, hero, snapshot));
                if(!m_isRunning)
                {
                    m_isRunning = true;
                    Start();
                }
            }
        }
        private void Start()
        {
            while(m_build_marks.Count > 0)
            {
                AC_UserHeroBuildMark c_UHBM = m_build_marks.Dequeue();
                
                //ideally this calculate happens in another thread as it might eventually take a while,
                //and later it would be checked for completion before being added to the database
                //currently, it doesn't take long for the buildmark to calculate so this really isn't necessary
                c_UHBM.m_snapshot.BuildMark.Calculate();
                m_manager.UpdateBuildMarkScore(c_UHBM.m_user, c_UHBM.m_hero, c_UHBM.m_snapshot);
                
            }

            m_isRunning = false;
        }
        
        
        private class AC_UserHeroBuildMark
        {
            public AC_User m_user;
            public AC_Hero m_hero;
            public AC_BuildSnapshot m_snapshot;

            public AC_UserHeroBuildMark(AC_User user, AC_Hero hero, AC_BuildSnapshot snapshot)
            {
                m_user = user;
                m_hero = hero;
                m_snapshot = snapshot;
            }
        }
    }
}
