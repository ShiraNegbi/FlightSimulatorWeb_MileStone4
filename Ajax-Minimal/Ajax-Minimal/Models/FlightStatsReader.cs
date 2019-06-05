
using Ajax_Minimal.Models.State_Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models
{
    public class FlightStatsReader : LocationReader
    {
        private static string GET_THROTTLE = "get /controls/engines/current-engine/throttle \r\n";
        private static string GET_RUDDER = "get /controls/flight/rudder \r\n";

        public FlightStats FlightStats { get; private set; }
        public void ReadFlightStatsData(string ip, int port)
        {
            base.ReadLocationData(ip, port);
            string throttleString = Client.Instance.DoMessage(ip, port, GET_THROTTLE);
            string lonString = Client.Instance.DoMessage(ip, port, GET_RUDDER);

            double throttle = ResultStringToDouble(throttleString);
            double rudder = ResultStringToDouble(lonString);

            FlightStats stats = new FlightStats
            {
                Location = base.Location,
                Throttle = throttle,
                Rudder = rudder
            };

            this.FlightStats = stats;
        }
    }
}
