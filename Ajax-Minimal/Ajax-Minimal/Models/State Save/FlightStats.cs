using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models.State_Save
{
    public class FlightStats
    {
        public Location Location { get; set; }
        public double Throttle { get; set; }
        public double Rudder { get; set; }
    }
}