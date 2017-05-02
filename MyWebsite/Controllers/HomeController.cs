using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.Models.DAO;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductDAO pro = new ProductDAO();
            ViewBag.p = pro.ListProductFeatured();
            ViewBag.listArrivals = pro.ListNewArrivals();
            ViewBag.listRandom = pro.ListRandom();
            ViewBag.listCheapest = pro.ListCheapest();
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}