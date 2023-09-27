using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Panel
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            //var uyebilgi = db.TblUyeler.FirstOrDefault(x => x.MAIL == mail);
            var duyurular = db.TblDuyurular.ToList();

            var deger1 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = deger1;
            var deger2 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = deger2;
            var deger3 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d3 = deger3;
            var deger4 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d4 = deger4;
            var deger5 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d5 = deger5;
            var deger6 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d6 = deger6;
            var deger7 = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = deger7;
            var id = db.TblUyeler.Where(x => x.MAIL == mail).Select(y => y.ID).FirstOrDefault();
            var deger8 = db.TblHareket.Where(x => x.UYE == id).Count();
            ViewBag.d8 = deger8;
            var deger9 = db.TblMesajlar.Where(x => x.ALICI == mail).Count();
            ViewBag.d9 = deger9;
            var deger10 = db.TblDuyurular.Count();
            ViewBag.d10 = deger10;
            return View(duyurular);
        }
        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var bilgiler = (string)Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x => x.MAIL == bilgiler);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
        public ActionResult Kitaplarim()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x => x.MAIL == mail.ToString()).Select(y => y.ID).FirstOrDefault();
            var kitaplar = db.TblHareket.Where(y => y.UYE == id).ToList();
            return View(kitaplar);
        }
        public ActionResult Duyurular()
        {
            var duyurular = db.TblDuyurular.ToList();
            return View(duyurular);
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var mail = (string)Session["MAIL"];
            var uye = db.TblUyeler.Where(x => x.MAIL == mail).FirstOrDefault();
            return PartialView(uye);
        }
    }
}