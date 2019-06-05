using Ajax_Minimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Drawing;
using Ajax_Minimal.Models.Models_File;
using Ajax_Minimal.Models.State_Save;

namespace Ajax_Minimal.Controllers
{
    public class FirstController : Controller
    {
        private static Random rnd = new Random();

        //// GET: First
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult index(string ip, int port)
        {
            InfoModel.Instance.Ip = ip;
            InfoModel.Instance.Port = port;
            return View();
        }
        [HttpGet]
        public ActionResult display(string ip, int port, int time)
        {
            InfoModel.Instance.Ip = ip;
            InfoModel.Instance.Port = port;
            //InfoModel.Instance.time = time;

            //InfoModel.Instance.ReadLocationData(ip,port);

            Session["time"] = time;

            return View();
        }
        [HttpGet]
        public ActionResult displaySave(string ip, int port, int time, int duration, string fileName)
        {
            InfoModel.Instance.Ip = ip;
            InfoModel.Instance.Port = port;
            Session["time"] = time;
            Session["duration"] = duration;
            FileManagerModel.Instance.Path = fileName;
            FileManagerModel.Instance.CreateFile();

            /*after delete this immediatly after you know it works*/
            FlightStats flightStats;
            //FileManagerModel.Instance.SaveLine(flightStats);
            /*till here thanks*/
            return View();
        }





        //[HttpPost]
        //public string GetEmployee()
        //{
        //    var emp = InfoModel.Instance.Employee;

        //    emp.Salary = rnd.Next(1000);

        //    return ToXml(emp);
        //}

        [HttpPost]
        public string GetLocation()
        {
            InfoModel.Instance.ReadLocationData();
            Location location = InfoModel.Instance.Location;
            return ToXml(location);
        }

        [HttpPost]
        public string GetAndSaveStats()
        {
            InfoModel.Instance.ReadStatsData();
            FlightStats stats = InfoModel.Instance.FlightStats;
            FileManagerModel.Instance.SaveLine(stats);
            return ToXml(stats);
        }

        private string ToXml(Location loc)
        {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Locations");

            loc.ToXml(writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }
        private string ToXml(FlightStats stats)
        {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("FlightStats");

            stats.ToXml(writer);


            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }




        //// POST: First/Search
        ////Is it needed? Maybe delete this
        //[HttpPost]
        //public string Search(string ip, int port)
        //{
        //    InfoModel.Instance.ReadLocationData(ip, port);
        //    return ToXml(InfoModel.Instance.Location);
        //}

    }
}