using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Ayarlar
        public ActionResult Index()
        {
            var adminler = db.TblAdmin.ToList();
            return View(adminler);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin p)
        {
            db.TblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TblAdmin.Find(id);
            db.TblAdmin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminGetir(int id)
        {
            var admin = db.TblAdmin.Find(id);
            return View("AdminGetir", admin);
        }
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            var admin = db.TblAdmin.Find(p.ID);
            admin.Kullanici = p.Kullanici;
            admin.Sifre = p.Sifre;
            admin.Yetki = p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}