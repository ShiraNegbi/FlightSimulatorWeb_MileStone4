﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ajax_Minimal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("display", "display/{ip}/{port}/{time}",
            defaults: new { controller = "First", action = "display" });

            routes.MapRoute("index", "display/{ip}/{port}",
            defaults: new { controller = "First", action = "index" });

            routes.MapRoute("displaySave", "save/{ip}/{port}/{time}/{duration}/{fileName}",
            defaults: new { Controller = "First", action = "displaySave" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "First", action = "None", id = UrlParameter.Optional }
            );
        }
    }
}
