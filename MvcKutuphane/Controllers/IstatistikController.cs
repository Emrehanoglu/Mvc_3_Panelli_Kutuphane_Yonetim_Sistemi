using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.TblKitap.Count();
            var deger2 = db.TblKitap.Where(x => x.DURUM == false).Count();
            var deger3 = db.TblCezalar.Sum(x => x.PARA);
            var deger4 = db.TblUyeler.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TblKitap.Count();
            var deger2 = db.TblUyeler.Count();
            var deger3 = db.TblCezalar.Sum(x => x.PARA);
            var deger4 = db.TblKitap.Where(x => x.DURUM == false).Count();
            var deger5 = db.TblKategori.Count();
            var deger6 = db.enAktifUye().FirstOrDefault();
            var deger7 = db.enCokOkunanKitap().FirstOrDefault();
            var deger8 = db.enCokKitapYazar().FirstOrDefault();
            var deger9 = db.enIyiYayinEvi().FirstOrDefault();
            var deger10 = db.enIyiPersonel().FirstOrDefault();
            var deger11 = db.TblIletisim.Count();
            var deger12 = db.TblHareket.Where(x => x.ISLEMDURUM == false).Select(y => y.KITAP).Count();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            return View();
        }
    }
}