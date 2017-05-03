using MyWebsite.Areas.Admin.Models;
using MyWebsite.Areas.Admin.Session;
using MyWebsite.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginDTO model)
        {
            var res = new AdminDAO().Login(model.userName, model.passWord);
            if(res == true && ModelState.IsValid)
            {
                SessionHelper.setSessionUser(new UserSession() { userName = model.userName});
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không chính xác");
            }
            return View(model);
        }
    }
}