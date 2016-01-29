using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Helpers;
//using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Progresses;
using ZTn.BNet.D3.Skills;
using ZTn.Bnet.Portable;
using ZTn.Bnet.Portable.Windows;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name and a list of attributes for an item.
    /// Used by: BuildSnapshot.
    /// Uses: n/a.
    /// </summary>
    
    public class Item
    {
        private string m_name;
        private List<string> m_attributes;

        public Item()
        {
            m_name = null;
            m_attributes = new List<string>();
        }
        public Item(string name)
        {
            m_name = name;
            m_attributes = new List<string>();
        }
        public Item(string name, List<string> attributes)
        {
            m_name = name;
            m_attributes = attributes;
        }
        public Item(string name, ZTn.BNet.D3.Items.ItemTextAttributes attributes)
        {
            m_name = name;
            m_attributes = new List<string>();

            m_attributes.Add("Primary: ");
            foreach (ItemTextAttribute att in attributes.Primary)
            {
                m_attributes.Add(att.Text);
            }
            m_attributes.Add("Secondary: ");
            foreach (ItemTextAttribute att in attributes.Secondary)
            {
                m_attributes.Add(att.Text);
            }
            m_attributes.Add("Passive: ");
            foreach (ItemTextAttribute att in attributes.Passive)
            {
                m_attributes.Add(att.Text);
            }

        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string Attributes
        {
            get
            {
                StringBuilder attributes = new StringBuilder();

                foreach(string text in m_attributes)
                {
                    attributes.Append(text);
                }

                return attributes.ToString();
            }
            //set { m_attributes = value; }
        }
    }
}
