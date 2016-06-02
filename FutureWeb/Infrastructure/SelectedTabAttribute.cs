using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FutureWeb.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]  //attribute can only be used on classes and methods
    public class SelectedTabAttribute : ActionFilterAttribute   //lets it become an attribute
    {
        private readonly string _selectedTab;

        public SelectedTabAttribute(string selectedTab)   // constrcutor which assigns it to _selectedTab field
        {
            _selectedTab = selectedTab;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SelectedTab = _selectedTab;
        }
    }
}
