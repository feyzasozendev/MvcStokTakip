using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MVCSTOK2Entities db = new MVCSTOK2Entities();
        // GET: Kategori
        public ActionResult Index(int? sayfa )
        {
            //var degerler = db.TBLKAtegoriler.ToList();
            var degerler = db.TBLKAtegoriler.ToList().ToPagedList(sayfa?? 1, 8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKAtegoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKAtegoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKAtegoriler.Find(id);
            db.TBLKAtegoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKAtegoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKAtegoriler p1)
        {
            var ktg = db.TBLKAtegoriler.Find(p1.KategoryID);
            ktg.KategoryAd = p1.KategoryAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}