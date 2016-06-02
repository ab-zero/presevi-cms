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
                        BannerClientileModel newObj = new BannerClientileModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        IList collection = (IList)newObj;
                        int i = 0;
                        foreach (var prop in collection)
                        {
                            collection[i] = Request[prop];
                            i++;
                        }
                        var result = business.CreateBannerClientileContent(newImage);
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

                ViewBag.ModelContent = newImage;
                ViewBag.ActionMessage = "This " + name + " is Created and is inserted in Content Management Database";
                ViewBag.Mode = "return";
                //return Redirect("/contentManage?mode=return");
                return View("ContentManage");
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
