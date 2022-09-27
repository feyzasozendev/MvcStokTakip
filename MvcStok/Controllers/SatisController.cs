using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcStok.Models.Entity;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MVCSTOK2Entities db = new MVCSTOK2Entities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatıs(TBLSatıslar p)
        {
            db.TBLSatıslar.Add(p);
            db.SaveChanges(); 
            return View("Index");
        }
    }
}