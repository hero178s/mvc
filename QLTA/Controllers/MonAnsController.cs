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
using PagedList.Mvc;

namespace QLTA.Controllers
{
    public class MonAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MonAns
        public ActionResult Index(string sortOrder,string searchString, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            //var monAns = db.MonAns.Include(m => m.LoaiThucAn);

            var monAns = db.MonAns.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                monAns = monAns.Where(s => s.TenMA.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "name_desc":
                    monAns = monAns.OrderByDescending(s => s.TenMA);
                    break;
                default:
                    monAns = monAns.OrderBy(s => s.TenMA);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(monAns.ToPagedList(pageNumber, pageSize));
        }

        // GET: MonAns/Details/5
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

       
    }
}
