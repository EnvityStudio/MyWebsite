using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;

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
            ViewBag.a = Category.getAll();
            ViewBag.b = Category.getAll2();
            ViewBag.p = Product.getList();
            Product x = Product.getProduct(id);
            return View(x);
        }
        public ActionResult List(int id)
        {
            ViewBag.a = Category.getAll();
            ViewBag.b = Category.getAll2();
            ViewBag.p = Product.getList();
            List<Product> x = Product.getList(id);
            
            return View(x);
        }
    }
}