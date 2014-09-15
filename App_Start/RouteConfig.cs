using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace INAB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapPageRoute("Default","","~/Productpage/Index.html");


            //Serve html files
            routes.IgnoreRoute("{file}.html/{*pathInfo}");
            routes.IgnoreRoute("");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "Productpage/index.html",
            //    defaults: new { controller = "", action = "", id = UrlParameter.Optional }
            //);
        }
    }
}
