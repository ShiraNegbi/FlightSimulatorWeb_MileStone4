
using Ajax_Minimal.Models.State_Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Minimal.Models.Models_File
{
    public class FileManagerModel
    {
        private static FileManagerModel s_instace = null;

        public static FileManagerModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new FileManagerModel();
                }
                return s_instace;
            }
        }


        private StatsFileManager statsFileManager;

        public string Path { get; set; }
        private StatsFileManager fileManager;
        public IList<FlightStats> StatsList { get; private set; }

        public FlightStats CurrentLine { get; private set; }
        public bool EndOfFile { get; private set; }
        private int linesIterIndex;

        public FileManagerModel()
        {
            this.statsFileManager = new StatsFileManager();
        }

        public FileManagerModel(string path)
        {
            this.statsFileManager = new StatsFileManager();
        }

        public void CreateFile()
        {
            //this.statsFileManager.CreateFile(Path);
            this.statsFileManager.ReadLines(Path);
        }
        public void SaveLine(FlightStats stats)
        {
            statsFileManager.SaveLine(Path, stats);
        }
        public void ReadLines()
        {
            StatsList = statsFileManager.ReadLines(Path);
            linesIterIndex = 0;
            EndOfFile = false;
        }

        public void GetNextLine()
        {
            CurrentLine = StatsList[linesIterIndex];
            linesIterIndex++;

            if (linesIterIndex > StatsList.Count)
            {
                EndOfFile = true;
            }
        }

    }
}
