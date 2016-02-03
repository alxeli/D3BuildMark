using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Queue<AC_BuildMark> m_build_marks = null;

        private BuildMarkManager()
        {
            m_build_marks = new Queue<AC_BuildMark>();
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

        public void Add(AC_BuildMark build_mark)
        {
            lock (_queue_sync)
            {
                m_build_marks.Enqueue(build_mark);
            }
        }
        public void Start()
        {
            throw new NotImplementedException();
        }
        
        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
