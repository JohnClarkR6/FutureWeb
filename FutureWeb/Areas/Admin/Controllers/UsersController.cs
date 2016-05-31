using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")] //only lets users with admin role view
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}