﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Item
    {
        private string m_name;
        private List<string> m_attributes;

        public Item()
        {
            m_name = null;
            m_attributes = new List<string>();
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public List<string> Attributes
        {
            get { return m_attributes; }
            set { m_attributes = value; }
        }
    }
}
