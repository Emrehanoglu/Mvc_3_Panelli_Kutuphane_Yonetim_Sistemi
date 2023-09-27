using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}