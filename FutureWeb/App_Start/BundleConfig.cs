using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace FutureWeb      
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/admin/styles")   //virtual path
                .Include("~/content/bootstrap.css")   //real path to files
                .Include("~/content/Admin.css"));

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/content/bootstrap.css")
                .Include("~/content/site.css"));

            bundles.Add(new ScriptBundle("~/admin/scripts")
                .Include("~/scripts/jquery-2.2.3.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js")
                .Include("~/areas/admin/scripts/Forms.js"));

            bundles.Add(new ScriptBundle("~/admin/post/scripts")
               .Include("~/areas/admin/scripts/posteditor.js"));

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/scripts/jquery-2.2.3.js")
                .Include("~/Scripts/JQuery.timeago.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js")
                .Include("~/scripts/Frontend.js"));
        }
    }
}
