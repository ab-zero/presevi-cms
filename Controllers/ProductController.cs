using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using presevi_cms.Models;
using presevi_cms.Models.DataLayer;

namespace presevi_cms.Controllers
{
    public class ProductController : Controller
    {
        Business business = new Business();
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

        public ActionResult Category(string name)
        {
            ViewBag.Category = name;
            List<ProductCategoryModel> productCategoryList = business.GetProdcutCategoryData("product-category");
            var dd = productCategoryList.Find(a => a.ProductCategory == name);
            if (dd != null)
            {
                ViewBag.PageContent = dd.PageContent;
            }
            else
            {
                ViewBag.PageContent = "No data Found";
            }
            ViewBag.ProductName = "not defined";
            return View();
        }

        
    }
}
