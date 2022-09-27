using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MVCSTOK2Entities db = new MVCSTOK2Entities();
        // GET: Müşteri
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMusteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMusteriler.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMusteriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMusteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMusteriler.Find(id);
            db.TBLMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMusteriler.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(TBLMusteriler p1)
        {
            var mus = db.TBLMusteriler.Find(p1.MusteriID);
            mus.MusteriAd = p1.MusteriAd;
            mus.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}