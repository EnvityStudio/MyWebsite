using MyWebsite.Areas.Admin.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Index()
        {
            Session.Remove(CommonConstant.ADMIN_SESSION);
            return RedirectToAction("Index","Login");
        }
    }
}