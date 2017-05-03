using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.Models.DAO;

namespace MyWebsite.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            ProductDAO pro = new ProductDAO();
            return View(pro.FindProductByID(id));
        }
        public ActionResult List(int id)
        {
            ProductDAO dao = new ProductDAO();
            return View(dao.ListProductByCatID(id));
        }
        
    }
}