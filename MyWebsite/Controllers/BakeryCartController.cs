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

        private HoaDonDAO hoaDonDAO;
        private KhachHangDao khDao;
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
        public ActionResult Pay(string name,string address,string phone)
        {
            hoaDonDAO = new HoaDonDAO();
            khDao = new KhachHangDao();
           int a =  khDao.AddKH(name, address, phone);
            BakeryCart bakery = (BakeryCart)Session["cart"];

            List<ItemCart> list = new List<ItemCart>();
            int b = hoaDonDAO.AddHoaDon(a, decimal.Parse(bakery.getTotalCart().ToString()));
            if(bakery!=null)
            {
                list = bakery.List1();
            }
            foreach(var item in list)
            {
                hoaDonDAO.AddChiTietHoaDon(item.ID, b, item.Amount, int.Parse(item.Price.ToString()));
            }

            return View();
        }
        public ActionResult tt()
        {
            return View();
        }
        public ActionResult thanhtoan(string tenkh,string sdt)
        {   
            return View();
        }
        
    }
}