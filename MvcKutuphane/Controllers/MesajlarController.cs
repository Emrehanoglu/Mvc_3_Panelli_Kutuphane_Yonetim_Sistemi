using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var alıcı = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.ALICI == alıcı.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesaj()
        {
            var gonderen = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.GONDEREN == gonderen.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar t)
        {
            var gönderen = (string)Session["Mail"].ToString();
            t.GONDEREN = gönderen.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"].ToString();
            var gelenmsjsayisi = db.TblMesajlar.Where(x => x.ALICI == mail).Count();
            var gidennmsjsayisi = db.TblMesajlar.Where(x => x.GONDEREN == mail).Count();
            ViewBag.d1 = gelenmsjsayisi;
            ViewBag.d2 = gidennmsjsayisi;
            return PartialView();
        }
    }
}