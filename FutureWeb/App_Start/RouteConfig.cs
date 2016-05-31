using FutureWeb.Controllers;
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
            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home","", new { controller = "Home", action = "Index" });

            routes.MapRoute("Blog", "blog", new { controller = "Posts", action = "Index" });

            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" });

            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });

            routes.MapRoute("Cover", "cover", new { controller = "Home", action = "Cover" });
        }
    }
}
