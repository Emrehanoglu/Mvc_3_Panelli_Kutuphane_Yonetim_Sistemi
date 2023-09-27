using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TblKategori.Where(b => b.DURUM==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            //db.TblKategori.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TblKategori.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(TblKategori p)
        {
            var kategori = db.TblKategori.Find(p.ID);
            kategori.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilinenKategoriler()
        {
            var silinen = db.TblKategori.Where(t => t.DURUM == false).ToList();
            return View(silinen);
        }
        public ActionResult KategoriDöndür(TblKategori p)
        {
            var ktg = db.TblKategori.Find(p.ID);
            ktg.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("SilinenKategoriler");
        }
    }
}