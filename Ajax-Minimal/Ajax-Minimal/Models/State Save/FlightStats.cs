using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Ajax_Minimal.Models.State_Save
{
    public class FlightStats
    {
        public Location Location { get; set; }
        public double Throttle { get; set; }
        public double Rudder { get; set; }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("FlightStat");
            writer.WriteElementString("Lat", this.Location.Lat.ToString());
            writer.WriteElementString("Lon", this.Location.Lon.ToString());
            writer.WriteElementString("Throttle", this.Throttle.ToString());
            writer.WriteElementString("Rudder", this.Rudder.ToString());
            writer.WriteEndElement();
        }
    }
}