using Ajax_Minimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Drawing;
namespace Ajax_Minimal.Controllers
{
    public class FirstController : Controller
    {
        private static Random rnd = new Random();

        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult display(string ip, int port, int time)
        {
            InfoModel.Instance.ip = ip;
            InfoModel.Instance.port = port.ToString();
            InfoModel.Instance.time = time;

            //InfoModel.Instance.ReadLocationData(ip,port);

            Session["time"] = time;

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
        public string GetLocation(string ip, int port)
        {
            InfoModel.Instance.ReadLocationData(ip,port);
            Location location = InfoModel.Instance.Location;
            return ToXml(location);
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
        private string ToXml(Employee employee)
        {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Employess");

            employee.ToXml(writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }


        // POST: First/Search
        //Is it needed? Maybe delete this
        [HttpPost]
        public string Search(string ip, int port)
        {
            InfoModel.Instance.ReadLocationData(ip, port);
            return ToXml(InfoModel.Instance.Location);
        }

    }
}