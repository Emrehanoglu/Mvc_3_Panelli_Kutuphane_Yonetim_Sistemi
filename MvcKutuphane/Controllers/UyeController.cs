using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {
            var uyeler = db.TblUyeler.ToList().ToPagedList(sayfa,3);
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("UyeGetir",uye);
        }
        public ActionResult UyeGuncelle(TblUyeler u)
        {
            var uye = db.TblUyeler.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.SIFRE = u.SIFRE;
            uye.TELEFON = u.TELEFON;
            uye.FOTOGRAF = u.FOTOGRAF;
            uye.OKUL = u.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var deger1 = db.TblUyeler.Where(x => x.ID == id).Select(c => c.AD).FirstOrDefault();
            var deger2 = db.TblUyeler.Where(x => x.ID == id).Select(c => c.SOYAD).FirstOrDefault();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            var ktp = db.TblHareket.Where(x => x.UYE == id).ToList();
            return View(ktp);
        }
    }
}