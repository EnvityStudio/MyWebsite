using MyWebsite.Models.DAO;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace MyWebsite.Controllers
{
    public class BakeryCartController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Add(int id)
        {

            BakeryCart Cart = (BakeryCart)Session["cart"];
            if (Cart == null)
                Cart = new BakeryCart();
            ProductDAO dao = new ProductDAO();
            SAN_PHAM sp = dao.FindProductByID(id);
            Cart.AddItem(sp.MaSP, sp.TenSP, 1, sp.DonGia, sp.HinhAnh);

            Session["cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult List()
        {
            BakeryCart Cart = (BakeryCart)Session["cart"];
            List<ItemCart> ls = new List<ItemCart>();
            if (Cart != null)
            {

                ls = Cart.list;
            }
            return View(ls);
        }
        public ActionResult UpdateAmount(int id, int quanity)
        {
            BakeryCart cart = (BakeryCart)Session["cart"];
            if (cart != null)
            {
                cart.addAmount(id, quanity);
            }
            return Redirect(Request.UrlReferrer.ToString());
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
        public ActionResult Pay()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay([Bind(Include = "TenKH,DiaChi,SDT,TrangThai")] KHACH_HANG kHACH_HANG)

        {
            if (ModelState.IsValid)
            {
                Object[] kh =
                {
                    new SqlParameter ("@tenKH",kHACH_HANG.TenKH),
                    new SqlParameter ("@diaChi",kHACH_HANG.DiaChi),
                    new SqlParameter ("@sdt",kHACH_HANG.SDT)
                };
                int? res = db.Database.SqlQuery<int>("GetLastMaKH @tenKH, @diaChi, @sdt",kh).SingleOrDefault();
                if (res == null)
                {

                }
               
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(kHACH_HANG);
        }
    }
}