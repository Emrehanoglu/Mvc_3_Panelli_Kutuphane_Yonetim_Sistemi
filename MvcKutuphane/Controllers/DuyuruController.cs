using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Duyuru
        public ActionResult Index()
        {
            var duyuru = db.TblDuyurular.ToList();
            return View(duyuru);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TblDuyurular dyr)
        {
            db.TblDuyurular.Add(dyr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGetir(int id)
        {
            var duyuru = db.TblDuyurular.Find(id);
            return View("DuyuruGetir",duyuru);
        }
        public ActionResult DuyuruGuncelle(TblDuyurular dyr)
        {
            var duyuru = db.TblDuyurular.Find(dyr.ID);
            duyuru.KATEGORI = dyr.KATEGORI;
            duyuru.ICERİK = dyr.ICERİK;
            duyuru.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}