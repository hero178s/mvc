using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTA.Models;

namespace QLTA.Areas.Admin.Controllers
{
    [Authorize]
    public class adLoaiThucAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/adLoaiThucAns
        public ActionResult Index()
        {
            return View(db.LoaiThucAns.ToList());
        }

        // GET: Admin/adLoaiThucAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucAn loaiThucAn = db.LoaiThucAns.Find(id);
            if (loaiThucAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiThucAn);
        }

        // GET: Admin/adLoaiThucAns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/adLoaiThucAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenTL")] LoaiThucAn loaiThucAn)
        {
            if (ModelState.IsValid)
            {
                db.LoaiThucAns.Add(loaiThucAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiThucAn);
        }

        // GET: Admin/adLoaiThucAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucAn loaiThucAn = db.LoaiThucAns.Find(id);
            if (loaiThucAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiThucAn);
        }

        // POST: Admin/adLoaiThucAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenTL")] LoaiThucAn loaiThucAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiThucAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiThucAn);
        }

        // GET: Admin/adLoaiThucAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucAn loaiThucAn = db.LoaiThucAns.Find(id);
            if (loaiThucAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiThucAn);
        }

        // POST: Admin/adLoaiThucAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiThucAn loaiThucAn = db.LoaiThucAns.Find(id);
            db.LoaiThucAns.Remove(loaiThucAn);
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
