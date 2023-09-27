using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Vitrin
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.value1 = db.TblKitap.ToList();
            cs.value2 = db.TblHakkimizda.ToList();
            //var kitaplar = db.TblKitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TblIletisim p)
        {
            db.TblIletisim.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}