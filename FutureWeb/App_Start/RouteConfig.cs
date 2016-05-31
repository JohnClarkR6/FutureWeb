using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FutureWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("","", new { controller = "Home", action = "Index" });
            routes.MapRoute("Login", "Login", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Cover", "Cover", new { controller = "Home", action = "Cover" });
        }
    }
}
