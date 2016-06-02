using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace presevi_cms.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Category = "ALl";
            ViewBag.ProductName = "not defined";
            return View();
        }

        public ActionResult Detail(string name)
        {
            ViewBag.ProductName = name;
            return View();
        }

        public ActionResult Category(string category)
        {
            ViewBag.Category = category;
            ViewBag.ProductName = "not defined";
            return View();
        }

        
    }
}
