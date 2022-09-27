using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MVCSTOK2Entities db = new MVCSTOK2Entities();
        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBLUrunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKAtegoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoryAd,
                                                 Value = i.KategoryID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLUrunler p1)
        {
            var ktg = db.TBLKAtegoriler.Where(m => m.KategoryID == p1.TBLKAtegoriler.KategoryID).FirstOrDefault();
            p1.TBLKAtegoriler = ktg;
            db.TBLUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLUrunler.Find(id);
            db.TBLUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBLUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKAtegoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoryAd,
                                                 Value = i.KategoryID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urn);
        }
        public ActionResult Guncelle(TBLUrunler p1)
        {
            var urun = db.TBLUrunler.Find(p1.UrunID);
            urun.UrunAd = p1.UrunAd;
            urun.Marka = p1.Marka;
            var ktg = db.TBLKAtegoriler.Where(m => m.KategoryID == p1.TBLKAtegoriler.KategoryID).FirstOrDefault();
            urun.UrunKategori = ktg.KategoryID;
            //urun.UrunKategori = p1.UrunKategori;
            urun.Fiyat = p1.Fiyat;
            urun.Stok = p1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}