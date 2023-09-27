using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var personeller = db.TblPersonel.ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TblPersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var pers = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(pers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var pers = db.TblPersonel.Find(id);
            return View("PersonelGetir",pers);
        }
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var pers = db.TblPersonel.Find(p.ID);
            pers.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}