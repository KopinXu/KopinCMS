using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Kopin.Core
{
    public class SiteSettings
    {
        private string _SiteUrl;
        private string _SiteName;

        public SiteSettings(string siteUrl)
        {
            this.SiteUrl = siteUrl;
            this.SiteName = "";
        }


        public static SiteSettings FromXml(XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode("Settings");
            SiteSettings settings2 = new SiteSettings(node.SelectSingleNode("SiteUrl").InnerText);
            settings2.SiteName = node.SelectSingleNode("SiteName").InnerText;
            return settings2;
        }
        public void WriteToXml(XmlDocument doc)
        {
            XmlNode root = doc.SelectSingleNode("Settings");

            SetNodeValue(doc, root, "SiteUrl", this.SiteUrl);
            SetNodeValue(doc, root, "SiteName", this.SiteName);
        }

        private static void SetNodeValue(XmlDocument doc, XmlNode root, string nodeName, string nodeValue)
        {
            XmlNode newChild = root.SelectSingleNode(nodeName);
            if (newChild == null)
            {
                newChild = doc.CreateElement(nodeName);
                root.AppendChild(newChild);
            }
            newChild.InnerText = nodeValue;
        }




        public string SiteUrl
        {
            get
            {
                return this._SiteUrl;
            }
            set
            {
                this._SiteUrl = value;
            }
        }
        public string SiteName
        {
            get
            {
                return this._SiteName;
            }
            set
            {
                this._SiteName = value;
            }
        }

    }
}
