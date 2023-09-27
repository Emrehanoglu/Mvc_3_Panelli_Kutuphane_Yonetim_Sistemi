using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [Authorize(Roles = "A")]
    public class OduncController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var liste = db.TblHareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from i in db.TblUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from i in db.TblKitap.Where(x => x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from i in db.TblPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PERSONEL,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket x)
        {
            var d1 = db.TblUyeler.Where(y => y.ID == x.TblUyeler.ID).FirstOrDefault();
            var d2 = db.TblKitap.Where(y => y.ID == x.TblKitap.ID).FirstOrDefault();
            var d3 = db.TblPersonel.Where(y => y.ID == x.TblPersonel.ID).FirstOrDefault();
            x.TblUyeler = d1;
            x.TblKitap = d2;
            x.TblPersonel = d3;
            db.TblHareket.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncIade(TblHareket p)
        {
            var iade = db.TblHareket.Find(p.ID);
            DateTime d1 = DateTime.Parse(iade.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;  
            return View("OduncIade", iade);
        }
        public ActionResult OduncGuncelle(TblHareket p)
        {
            var iade = db.TblHareket.Find(p.ID);
            iade.GERCEKLESENIADE = p.GERCEKLESENIADE;
            iade.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}