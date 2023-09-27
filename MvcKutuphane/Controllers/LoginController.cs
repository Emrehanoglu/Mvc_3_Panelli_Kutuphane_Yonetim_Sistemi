using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblUyeler p)
        {
            var bilgiler = db.TblUyeler.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                TempData["Ad"] = bilgiler.AD.ToString();
                TempData["ID"] = bilgiler.ID.ToString();
                TempData["Soyad"] = bilgiler.SOYAD.ToString();
                TempData["KulanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                TempData["Şifre"] = bilgiler.SIFRE.ToString();
                TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}