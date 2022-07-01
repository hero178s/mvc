using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTA.Models;

namespace QLTA.Areas.Admin.Controllers
{
    [Authorize]

    public class adMonAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/adMonAns
        public ActionResult Index()
        {
            var monAns = db.MonAns.Include(m => m.LoaiThucAn);
            return View(monAns.ToList());
        }

        // GET: Admin/adMonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // GET: Admin/adMonAns/Create
        public ActionResult Create()
        {
            ViewBag.MaTL = new SelectList(db.LoaiThucAns, "Id", "TenTL");
            return View();
        }

        // POST: Admin/adMonAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenMA,NguoiNau,Hinh,Gio,Gia,SoLuong,MaTL")] MonAn monAn, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {

                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                    img.SaveAs(path);
                    monAn.Hinh = "/Content/images/" + filename; //Lưu ý

                }
                else
                {
                    monAn.Hinh = "a.jpg";
                }


                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTL = new SelectList(db.LoaiThucAns, "Id", "TenTL", monAn.MaTL);
            return View(monAn);
        }

        // GET: Admin/adMonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTL = new SelectList(db.LoaiThucAns, "Id", "TenTL", monAn.MaTL);
            return View(monAn);
        }

        // POST: Admin/adMonAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenMA,NguoiNau,Hinh,Gio,Gia,SoLuong,MaTL")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTL = new SelectList(db.LoaiThucAns, "Id", "TenTL", monAn.MaTL);
            return View(monAn);
        }

        // GET: Admin/adMonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: Admin/adMonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
