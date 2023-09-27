using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblYazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(TblYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TblYazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int p)
        {
            var yazar = db.TblYazar.Find(p);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TblYazar.Find(id);
            return View("YazarGetir",yazar);
        }
        public ActionResult YazarGuncelle(TblYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarGetir");
            }
            var yazar = db.TblYazar.Find(p.ID);
            yazar.AD = p.AD;
            yazar.SOYAD = p.SOYAD;
            yazar.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var deger1 = db.TblYazar.Where(x => x.ID == id).Select(c => c.AD).FirstOrDefault();
            var deger2 = db.TblYazar.Where(x => x.ID == id).Select(c => c.SOYAD).FirstOrDefault();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            var yazar = db.TblKitap.Where(x => x.YAZAR == id).ToList();
            return View(yazar);
        }
    }
}