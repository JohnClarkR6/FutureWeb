using FutureWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FutureWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Database.Configure();  //lets the database configure method be run at the app start
        }

        protected void Application_BeginRequest()  
        {
            Database.OpenSession();         //tells the database to open up a session at the begining of every request
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();    //tells the database to close a session at the begining of every request
        }
    }
}
