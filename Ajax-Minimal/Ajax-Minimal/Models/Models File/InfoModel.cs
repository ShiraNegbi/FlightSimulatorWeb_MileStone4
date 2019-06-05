
using Ajax_Minimal.Models.State_Save;

namespace Ajax_Minimal.Models
{
    public class InfoModel
    {
        private static InfoModel s_instace = null;

        public static InfoModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new InfoModel();
                }
                return s_instace;
            }
        }

        public Location Location { get; private set; }
        public FlightStats FlightStats { get; private set; }
        public string Ip { get; set; }
        public int Port { get; set; }


        private LocationReader LocationReader { get; set; }
        private FlightStatsReader FlightStatsReader { get; set; }

        public InfoModel()
        {
            Location = new Location();
            LocationReader = new LocationReader();
            FlightStatsReader = new FlightStatsReader();
        }

        /// <summary>
        /// Connect to the server, read the Lat and the Lon, and disconnect. 
        /// Save them in the Location property
        /// </summary>
        public void ReadLocationData()
        {
            LocationReader.ReadLocationData(Ip, Port);
            Location = LocationReader.Location;
        }

        /// <summary>
        /// Connect to the server, read the Lat, Lon, Throttle, Rudder and disconnect. 
        /// Save them in the Location property
        /// </summary>
        public void ReadStatsData()
        {
            FlightStatsReader.ReadFlightStatsData(Ip, Port);
            this.FlightStats = FlightStatsReader.FlightStats;
            this.Location = FlightStats.Location;
        }
    }
}