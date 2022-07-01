using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTA.Models;

namespace QLTA.Controllers
{
    public class LoaiThucAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoaiThucAns
        public ActionResult Index()
        {
            return View(db.LoaiThucAns.ToList());
        }

        // GET: LoaiThucAns/Details/5
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

     
    }
}
