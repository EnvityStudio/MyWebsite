using MyWebsite.Models.DAO;
using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class SearchController : Controller
    {

       private MyDbContext db;
        // GET: Search
        public SearchController ()
        {
            db = new MyDbContext();
        }
        public ActionResult Search(string name)
        {
            List<SAN_PHAM> list;
            string a = "'%"+name+"%'";
            
                    list = db.SAN_PHAM.SqlQuery("select *from SAN_PHAM where TenSP like " + a + "").ToList();
                    return View(list);
            
               
            
        }
        
    }
}