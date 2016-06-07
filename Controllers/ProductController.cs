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
            List<ProductDetailModel> productDetailList = business.GetProductDetailDataAll("product-detail");
            if (productDetailList != null)
            {
                ViewBag.isSuccess = true;
                ViewBag.CategoryData = productDetailList;
                ViewBag.ProductDetailList = productDetailList;
            }
            else
            {
                ViewBag.isSuccess = false;
                ViewBag.PageContent = "No data Found";
            }

            return View();
        }

        public ActionResult Detail(string name)
        {
            ProductDetailModel productDetail = business.GetProductDetailDataFiltered("product-detail", name);
            if (productDetail != null)
            {
                ViewBag.isSuccess = true;
                ViewBag.ProductDetail = productDetail;
            }
            else
            {
                ViewBag.isSuccess = false;
                ViewBag.PageContent = "No data Found";
            }
            
            return View(); ;
        }

        public ActionResult Category(string name)
        {
            ViewBag.Category = name;
            ProductCategoryModel productCategoryData = business.GetProdcutCategoryDataFiltered("product-category",name);
            List<ProductDetailModel> productDetailList = business.GetProductDetailDataCategory("category", name);
            if (productCategoryData != null)
            {
                ViewBag.isSuccess = true;
                ViewBag.CategoryData = productCategoryData;
                ViewBag.ProductDetailList = productDetailList;
            }
            else
            {
                ViewBag.isSuccess = false;
                ViewBag.PageContent = "No data Found";
            }
            
            return View();
        }


    }
}
