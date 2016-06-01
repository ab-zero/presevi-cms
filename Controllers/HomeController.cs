﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using presevi_cms.Models.DataLayer;
using presevi_cms.Models;

namespace presevi_cms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Business business = new Business();
            ViewBag.BannerList = business.GetContent("banner");
            ViewBag.ProductCategoryList = business.GetContent("product-category");
            ViewBag.ClientileList = business.GetContent("clientile");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        


        
        




    }
}
