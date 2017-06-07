using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string name, string password)
        {
            if("admin".Equals(name)&&"admin".Equals(password))
                {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}