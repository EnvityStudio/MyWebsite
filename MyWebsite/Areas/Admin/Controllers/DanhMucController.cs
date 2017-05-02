using MyWebsite.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            var list = new CategoryDAO().ListCategory();
            return View(list);
        }

        // GET: Admin/DanhMuc/Details/5
        public ActionResult Details(int id)
        {
            var item = new CategoryDAO().FindCategoryByID(id);
            return View(item);
        }

        // GET: Admin/DanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMuc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DanhMuc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DanhMuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DanhMuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DanhMuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
