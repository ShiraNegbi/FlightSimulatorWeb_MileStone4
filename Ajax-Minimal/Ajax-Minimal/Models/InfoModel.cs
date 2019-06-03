﻿namespace Ajax_Minimal.Models
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
        public string ip { get; set; }
        public string port { get; set; }
        public int time { get; set; }

        private LocationReadModel LocationReadModel { get; set; }

        public InfoModel()
        {
            Location = new Location();
            LocationReadModel = new LocationReadModel();
        }

        /// <summary>
        /// Connect to the server, read the Lat and the Lon, and disconnect. 
        /// Save them in the Location property
        /// </summary>
        /// <param name="ip">The ip of the socket of communication with the FlightGear server</param>
        /// <param name="port">The port of the socket of communication</param>
        public void ReadLocationData(string ip, int port)
        {
            LocationReadModel.ReadLocationData(ip, port);
            Location = LocationReadModel.Location;
        }



    }
}