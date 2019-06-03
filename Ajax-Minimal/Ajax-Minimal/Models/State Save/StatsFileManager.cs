using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models.State_Save
{
    public class StatsFileManager
    {
        public StatsFileManager(string path)
        {
            this.path = path;
        }

        private string path;
        public void SaveLine(FlightStats stats)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.Write(stats.Location.Lat);
                Console.Write(" ");
                file.WriteLine(stats.Location.Lon);
                Console.Write(" ");
                file.WriteLine(stats.Rudder);
                Console.Write(" ");
                file.WriteLine(stats.Throttle);
                Console.WriteLine();
            }
        }
        public IList<FlightStats> ReadLines()
        {
            string[] lines = System.IO.File.ReadAllLines(path);// reading all the lines of the file
            List<FlightStats> flightStatsList = new List<FlightStats>(lines.Length);

            foreach (string line in lines)
            {
                string[] values = line.Split(' ');

                FlightStats stats = new FlightStats();
                stats.Location = new Location();
                stats.Location.Lat = double.Parse(values[0]);
                stats.Location.Lon = double.Parse(values[1]);
                stats.Rudder = double.Parse(values[2]);
                stats.Throttle = double.Parse(values[3]);

                flightStatsList.Add(stats);
            }
            return flightStatsList;
        }
    }
}