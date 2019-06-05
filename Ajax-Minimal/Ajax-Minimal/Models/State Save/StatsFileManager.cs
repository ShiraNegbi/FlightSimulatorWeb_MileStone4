
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models.State_Save
{
    public class StatsFileManager
    {
        public const string SCENARIO_FILE = "~/App_Data/{0}.txt";   // The Path of the Secnario

        public StatsFileManager(/*string path*/)
        {
            //this.path = path;
        }

        //private string path;
        public void CreateFile(string path)
        {
       //     System.IO.File.WriteAllText($"~/App_Data/{path}.txt", string.Empty);
        }
        public void SaveLine(string path, FlightStats stats)
        {
            string appDataPath = HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, path));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(appDataPath, true))
            {
                file.Write(stats.Location.Lat);
                file.Write(" ");
                file.Write(stats.Location.Lon);
                file.Write(" ");
                file.Write(stats.Rudder);
                file.Write(" ");
                file.Write(stats.Throttle);
                file.WriteLine();
            }
        }
        public IList<FlightStats> ReadLines(string path)
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

