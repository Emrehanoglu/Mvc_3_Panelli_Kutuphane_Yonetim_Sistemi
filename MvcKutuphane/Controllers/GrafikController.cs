﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;                       

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                deger = "Ay",
                sayi = 25
            });
            cs.Add(new Class1()
            {
                deger = "Güneş",
                sayi = 25
            });
            cs.Add(new Class1()
            {
                deger = "Yıldız",
                sayi = 25
            });
            return cs;
        }
    }
}