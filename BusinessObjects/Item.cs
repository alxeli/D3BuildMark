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
using System.Drawing;

namespace BusinessObjects
{
    /// <summary>
    /// Stores the name and a list of attributes for an item.
    /// Used by: BuildSnapshot.
    /// Uses: n/a.
    /// </summary>
    
    public class AC_Item
    {
        private string m_name;
        private List<string> m_attributes;
        private byte[] m_image;

        public AC_Item()
        {
            m_name = null;
            m_attributes = new List<string>();
        }
        public AC_Item(string name)
        {
            m_name = name;
            m_attributes = new List<string>();
        }
        public AC_Item(string name, List<string> attributes)
        {
            m_name = name;
            m_attributes = attributes;
        }
        public AC_Item(string name, ZTn.BNet.D3.Items.ItemTextAttributes attributes)
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
                    if (text == "Primary: " || text == "Secondary: " || text == "Passive: ")
                    {
                        attributes.Append("\n\n" + text);
                    }
                    else
                    {
                        attributes.Append("\n" + text);
                    }
                }

                return attributes.ToString();
            }
            //set { m_attributes = value; }
        }
        public byte[] Image
        {
            get { return m_image; }
            set { m_image = value; }
        }
    }
}
