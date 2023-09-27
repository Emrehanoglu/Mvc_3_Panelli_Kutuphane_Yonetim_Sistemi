﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            var bilgiler = db.TblAdmin.FirstOrDefault(x => x.Sifre == p.Sifre);
            if (bilgiler != null){
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici,false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return View();
            }
            
        }
    }
}