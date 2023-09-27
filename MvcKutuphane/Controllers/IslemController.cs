using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var islemler = db.TblHareket.Where(x => x.ISLEMDURUM == true).ToList();
            return View(islemler);
        }
    }
}