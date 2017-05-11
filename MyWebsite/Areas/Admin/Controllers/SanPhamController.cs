using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models.Entities;
using System.IO;

namespace MyWebsite.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.DANH_MUC);
            return View(sAN_PHAM.ToList());
        }

        // GET: Admin/SanPham/Details/5
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

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DonGia,TrangThai,NoiBat,HinhAnh,MoTa,ChiTiet,MaDM")] SAN_PHAM sAN_PHAM,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(file.FileName).ToLower() == ".jpeg"
                        || Path.GetExtension(file.FileName).ToLower() == ".gif"
                        || Path.GetExtension(file.FileName).ToLower() == ".png")
                    {
                        string NameFile = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/images/products"), NameFile);
                        file.SaveAs(path);
                        sAN_PHAM.HinhAnh = "/Content/images/products/" + file.FileName;
                    }

                    db.SAN_PHAM.Add(sAN_PHAM);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM", sAN_PHAM.MaDM);
            return View(sAN_PHAM);
        }

        // GET: Admin/SanPham/Edit/5
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

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DonGia,TrangThai,NoiBat,HinhAnh,MoTa,ChiTiet,MaDM")] SAN_PHAM sAN_PHAM, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(file.FileName).ToLower() == ".jpeg"
                        || Path.GetExtension(file.FileName).ToLower() == ".gif"
                        || Path.GetExtension(file.FileName).ToLower() == ".png")
                    {
                        string NameFile = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/images/products"), NameFile);
                        file.SaveAs(path);
                        sAN_PHAM.HinhAnh = "/Content/images/products/" + file.FileName;
                    }

                    db.Entry(sAN_PHAM).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MaDM = new SelectList(db.DANH_MUC, "MaDM", "TenDM", sAN_PHAM.MaDM);
            return View(sAN_PHAM);
        }
        [HttpPost]
        public ActionResult File(HttpPostedFileBase file, SAN_PHAM sp)
        {
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(file.FileName).ToLower() == ".jpeg"
                        || Path.GetExtension(file.FileName).ToLower() == ".png"
                        || Path.GetExtension(file.FileName).ToLower() == ".gif")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images/products"), file.FileName);
                        file.SaveAs(path);
                        sp.HinhAnh= "~/Content/images/products/" + file.FileName;
                    }
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.SAN_PHAM.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(sp);
                }
            }
            catch
            {
                return View(sp);
            }
        }

        // GET: Admin/SanPham/Delete/5
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

        // POST: Admin/SanPham/Delete/5
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
