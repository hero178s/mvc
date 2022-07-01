using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTA.Models;
using PagedList;

namespace QLTA.Controllers
{
    public class TinTucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TinTucs
        public ActionResult Index(/*string sortOrder, string searchString, int? page, string currentFilter*/)
        {
            return View(db.TinTucs.ToList());
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}
            //ViewBag.CurrentFilter = searchString;

            ////var monAns = db.MonAns.Include(m => m.LoaiThucAn);

            //var tinTucs = db.TinTucs.AsQueryable();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    tinTucs = tinTucs.Where(s => s.TieuDe.Contains(searchString));

            //}
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        tinTucs = tinTucs.OrderByDescending(s => s.TieuDe);
            //        break;
            //    default:
            //        tinTucs = tinTucs.OrderBy(s => s.TieuDe);
            //        break;
            //}

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(tinTucs.ToPagedList(pageNumber, pageSize));
        }

        // GET: TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: TinTucs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TinTucs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,TieuDe,TacGia,Hinh,GioDang,NoiDung")] TinTuc tinTuc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TinTucs.Add(tinTuc);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tinTuc);
        //}

        //// GET: TinTucs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TinTuc tinTuc = db.TinTucs.Find(id);
        //    if (tinTuc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tinTuc);
        //}

        //// POST: TinTucs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,TieuDe,TacGia,Hinh,GioDang,NoiDung")] TinTuc tinTuc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tinTuc).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tinTuc);
        //}

        //// GET: TinTucs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TinTuc tinTuc = db.TinTucs.Find(id);
        //    if (tinTuc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tinTuc);
        //}

        //// POST: TinTucs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TinTuc tinTuc = db.TinTucs.Find(id);
        //    db.TinTucs.Remove(tinTuc);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
