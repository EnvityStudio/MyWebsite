using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models.Entities;

namespace MyWebsite.Areas.Admin.Controllers
{
    public class LienHeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/LienHe
        public ActionResult Index()
        {
            return View(db.LIEN_HE.ToList());
        }

        // GET: Admin/LienHe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // GET: Admin/LienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LienHe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,TieuDe,NoiDung,TenKH,SDT,TrangThai,NgayDang")] LIEN_HE lIEN_HE)
        {
            if (ModelState.IsValid)
            {
                db.LIEN_HE.Add(lIEN_HE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIEN_HE);
        }

        // GET: Admin/LienHe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // POST: Admin/LienHe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,TieuDe,NoiDung,TenKH,SDT,TrangThai,NgayDang")] LIEN_HE lIEN_HE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIEN_HE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIEN_HE);
        }

        // GET: Admin/LienHe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // POST: Admin/LienHe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            db.LIEN_HE.Remove(lIEN_HE);
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
