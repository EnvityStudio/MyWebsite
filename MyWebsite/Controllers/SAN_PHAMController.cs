using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models.Entities;
using MyWebsite.Models.DAO;
using MyWebsite.Models.DTO;

namespace MyWebsite.Controllers
{
    public class San_PhamController : Controller
    {
        private MyDbContext db = new MyDbContext();
        ProductDAO dao;
        CategoryDAO daoCat;
        // GET: SAN_PHAM
        public ActionResult Index()
        {
            //var sAN_PHAM = db.SAN_PHAM.Include(s => s.DANH_MUC);

            //return View(sAN_PHAM.ToList());
            dao = new ProductDAO();
            IQueryable<ProductDTO> spList = dao.ListProductFields();
            return View(spList);
        }
        public ActionResult Add()
        {
            daoCat = new CategoryDAO();
            IQueryable<DANH_MUC> ls = daoCat.ListCategory();
            return View(ls);
        }

        // GET: SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM");
            return View();
        }

        // POST: SAN_PHAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DonGia,TrangThai,NoiBat,HinhAnh,MoTa,ChiTiet,MaDM")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM", sAN_PHAM.MaDM);
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM", sAN_PHAM.MaDM);
            return View(sAN_PHAM);
        }

        // POST: SAN_PHAM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DonGia,TrangThai,NoiBat,HinhAnh,MoTa,ChiTiet,MaDM")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM", sAN_PHAM.MaDM);
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
