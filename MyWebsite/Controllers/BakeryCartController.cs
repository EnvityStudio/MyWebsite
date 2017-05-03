using MyWebsite.Models.DAO;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class BakeryCartController : Controller
    {
        public ActionResult Add(int id)
        {
            BakeryCart Cart = (BakeryCart)Session["cart"];
            if (Cart == null)
                Cart = new BakeryCart();
            ProductDAO dao = new ProductDAO();
            SAN_PHAM sp = dao.FindProductByID(id);
            Cart.AddItem(sp.MaDM, sp.TenSP, 1, sp.DonGia);

            Session["cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult List()
        {
            BakeryCart Cart = (BakeryCart)Session["cart"];
            List<ItemCart> ls = new List<ItemCart>();
            if(Cart != null)
            {

                ls = Cart.list;
            }
            return View(ls);
        }
        public ActionResult UpdateAmount()
        {
            return View();
        }
        public ActionResult Delete(int ID)
        {
            BakeryCart Cart = (BakeryCart)Session["cart"];
            if (Cart != null)
            {
                Cart.Delete(ID);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}