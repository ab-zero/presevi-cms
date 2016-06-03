using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using presevi_cms.Models;
using presevi_cms.Models.DataLayer;
using System.Collections;

namespace presevi_cms.Controllers
{
    public class ContentController : Controller
    {
        public BannerClientileModel bannerClientModel = new BannerClientileModel();
        public ProductCategoryModel productCategoryModel = new ProductCategoryModel();
        public ProductDetailModel productDetailModel = new ProductDetailModel();
        public static Business business = new Business();
        [Authorize]
        public ActionResult ContentManage()
        {


            ViewBag.Mode = "fresh";
            return View();
        }

        public PartialViewResult GetData(string name)
        {
            return PartialView(bannerClientModel);
        }

        public PartialViewResult Create(string name)
        {
            //switch (name.ToUpper())
            //{
            //    case "BANNER":
            //        return PartialView(bannerClientModel);
            //    case "CLIENTILE":
            //        return PartialView(bannerClientModel);
            //    case "PRODUCT-CATEGORY":
            //        return PartialView(productCategoryModel);
            //    case "PRODUCT":
            //        return PartialView(productDetailModel);
            //    default:
            //        ViewBag.Mesage = "No View Found";
            //        return PartialView();
            //}

            ViewBag.ContentType = name;
            switch (name.ToUpper())
            {
                case "BANNER":
                    ViewBag.Model = bannerClientModel;
                    return PartialView();
                case "CLIENTILE":
                    ViewBag.Model = bannerClientModel;
                    return PartialView();
                case "PRODUCT-CATEGORY":
                    ViewBag.Model = productCategoryModel;
                    return PartialView();
                case "PRODUCT":
                    ViewBag.Model = productDetailModel;
                    return PartialView();
                default:
                    ViewBag.Mesage = "No View Found";
                    ViewBag.Model = null;
                    return PartialView();
            }

        }


        //
        // POST: /Content/Create

        [HttpPost]
        public ActionResult Create(string name, object obj)
        {

            try
            {
                // todo ajax call from client
                // post json
                // deserialize and update in controller

                switch (name.ToUpper())
                {
                    case "BANNER":
                        BannerClientileModel bcObj = new BannerClientileModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        bcObj.ContentType = name;
                        bcObj.Description = Request["Description"];
                        bcObj.ImageAltText = Request["ImageAltText"];
                        bcObj.ImageHeader = Request["ImageHeader"];
                        bcObj.ImageUrl = Request["ImageUrl"];
                        bcObj.Tags = Request["Tags"];
                        bcObj.TargetUrl = Request["TargetUrl"];

                        if (business.CreateBannerClientileContent(bcObj) == "OK")
                        {
                            ViewBag.ModelContent = bcObj;
                            ViewBag.ActionMessage = "This " + name + " is Created and is inserted in Content Management Database";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Creating. Contact administrator!";
                            ViewBag.Model = null;
                        }

                        return View("ContentManage");

                    case "CLIENTILE":
                        BannerClientileModel clObj = new BannerClientileModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        clObj.ContentType = name;
                        clObj.Description = Request["Description"];
                        clObj.ImageAltText = Request["ImageAltText"];
                        clObj.ImageHeader = Request["ImageHeader"];
                        clObj.ImageUrl = Request["ImageUrl"];
                        clObj.Tags = Request["Tags"];
                        clObj.TargetUrl = Request["TargetUrl"];

                        if (business.CreateBannerClientileContent(clObj) == "OK")
                        {
                            ViewBag.ModelContent = clObj;
                            ViewBag.ActionMessage = "This " + name + " is Created and is inserted in Content Management Database";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Creating. Contact administrator!";
                            ViewBag.Model = null;
                        }

                        return View("ContentManage");
                    case "PRODUCT-CATEGORY":
                        ProductCategoryModel pcObj = new ProductCategoryModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        pcObj.ContentType = name;
                        pcObj.Description = Request["Description"];
                        pcObj.ImageAltText = Request["ImageAltText"];
                        pcObj.ImageUrl = Request["ImageUrl"];
                        pcObj.PageContent = Request["PageContent"];
                        pcObj.ProductCategory = Request["ProductCategory"];
                        pcObj.Tags = Request["Tags"];

                        if (business.CreateProductCategory(pcObj) == "OK")
                        {
                            ViewBag.ModelContent = pcObj;
                            ViewBag.ActionMessage = "This " + name + " is Created and is inserted in Content Management Database";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Creating. Contact administrator!";
                            ViewBag.Model = null;
                        }

                        return View("ContentManage");
                    case "PRODUCT":
                        ProductDetailModel pdObj = new ProductDetailModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        pdObj.ContentType = name;
                        pdObj.Description = Request["Description"];
                        pdObj.ImageAltText = Request["ImageAltText"];
                        pdObj.ImageUrl = Request["ImageUrl"];
                        pdObj.PageContent = Request["PageContent"];
                        pdObj.ProductCategory = Request["ProductCategory"];
                        pdObj.ProductName = Request["ProductName"];
                        pdObj.Tags = Request["Tags"];

                        if (business.CreateProductDetail(pdObj) == "OK")
                        {
                            ViewBag.ModelContent = pdObj;
                            ViewBag.ActionMessage = "This " + name + " is Created and is inserted in Content Management Database";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Creating. Contact administrator!";
                            ViewBag.Model = null;
                        }

                        return View("ContentManage");
                    default:
                        ViewBag.ActionMessage = "No View Found";
                        ViewBag.Model = null;
                        return View("ContentManage");
                }
            }
            catch
            {
                return View(bannerClientModel);
            }
        }


        //
        // GET: /Content/Edit/5

        public ActionResult Edit(string contentType)
        {
            return View(bannerClientModel);
        }

        //
        // POST: /Content/Edit/5

        [HttpPost]
        public ActionResult Edit(string contentType, FormCollection collection)
        {
            try
            {


                return View(bannerClientModel);
            }
            catch
            {
                return View(bannerClientModel);
            }
        }



        public ActionResult Delete(string contentType)
        {
            return View(bannerClientModel);
        }

        //
        // POST: /Content/Delete/5

        [HttpPost]
        public ActionResult Delete(string contentType, FormCollection collection)
        {
            try
            {


                return View(bannerClientModel);
            }
            catch
            {
                return View(bannerClientModel);
            }
        }
    }
}
