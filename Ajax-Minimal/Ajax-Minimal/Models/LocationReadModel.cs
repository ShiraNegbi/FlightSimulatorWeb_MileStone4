using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models
{
    public class LocationReadModel
    {
        private static string GET_LAT = "get position/latitude-deg \r\n";
        private static string GET_LON = "get position/longitude-deg \r\n";

        public Location Location { get; private set; }

        public void ReadLocationData(string ip, int port)
        {
            string latString = Client.Instance.DoMessage(ip, port, GET_LAT);
            string lonString = Client.Instance.DoMessage(ip, port, GET_LON);

            double lat = resultStringToDouble(latString);
            double lon = resultStringToDouble(lonString);

            Location location = new Location
            {
                Lat = lat,
                Lon = lon
            };

            this.Location = location;
        }

        private static double resultStringToDouble(string resultString)
        {
            /*
             * The result string comes in the following format:
             * [ Received: {Path to variable} = '{The value}' (double) ]
             * For example:
             * Received: controls/engines/current-engine/throttle = '0' (double)
             * 
             * We would like to extract the value of the variable.
             * Therefore, we take a substring of the number between the two apostrophes,
             * and convert it to double.
             */

            //the char of apostrophe (')
            char apostrophe = '\'';

            // get the index of the beginning of the number, one char after the apostrophe
            int startIndex = resultString.IndexOf(apostrophe) + 1;
            // get the index of the apostrophe, after end of the number
            int endIndex = resultString.LastIndexOf(apostrophe);

            int length = endIndex - startIndex;

            double result = double.Parse(resultString.Substring(startIndex, length));

            return result;
        }
    }
}