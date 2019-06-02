using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Ajax_Minimal.Models
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Location");
            writer.WriteElementString("Lat", this.Lat.ToString());
            writer.WriteElementString("Lon", this.Lon.ToString());
            writer.WriteEndElement();
        }
    }
}