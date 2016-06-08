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
        public ActionResult Index()
        {


            ViewBag.Mode = "fresh";
            return View();
        }

        public PartialViewResult GetData(string name)
        {
            return PartialView(bannerClientModel);
        }

        public ActionResult Create(string name)
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
                    return View();
                case "CLIENTILE":
                    ViewBag.Model = bannerClientModel;
                    return View();
                case "PRODUCT-CATEGORY":
                    ViewBag.Model = productCategoryModel;
                    return View();
                case "PRODUCT":
                    ViewBag.Model = productDetailModel;
                    return View();
                default:
                    ViewBag.Mesage = "No View Found";
                    ViewBag.Model = null;
                    return View();
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
                ProductSlugGenerator slug = new ProductSlugGenerator();
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

                        return View();

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

                        return View();
                    case "PRODUCT-CATEGORY":
                        ProductCategoryModel pcObj = new ProductCategoryModel();
                        //IEnumerable enumerable = (IEnumerable)newObj;
                        pcObj.ContentType = name;
                        pcObj.Description = Request["Description"];
                        pcObj.ImageAltText = Request["ImageAltText"];
                        pcObj.ImageUrl = Request["ImageUrl"];
                        pcObj.PageContent = Uri.UnescapeDataString(Request["PageContent"]);
                        pcObj.ProductCategory = Request["ProductCategory"];
                        pcObj.Tags = Request["Tags"];
                        pcObj.CategorySlug = slug.GenerateSlug(Request["ProductCategory"]);

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

                        return View();
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
                        pdObj.ProductSlug = slug.GenerateSlug(Request["ProductName"]);

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

                        return View();
                    default:
                        ViewBag.ActionMessage = "No View Found";
                        ViewBag.Model = null;
                        return View();
                }
            }
            catch
            {
                return View(bannerClientModel);
            }
        }


        //
        // GET: /Content/Edit/5

        [HttpGet]
        public ActionResult edit(string name)
        {
            switch (name.ToUpper())
            {
                case "BANNER":
                    ViewBag.ContentType = "banner";
                    ViewBag.BannerList = business.GetBannerClientileData("banner");
                    break;
                case "PRODUCT-CATEGORY":
                    ViewBag.ContentType = "product-category";
                    ViewBag.ProductCategoryList = business.GetProdcutCategoryDataAll("product-category");
                    break;
                case "PRODUCT":
                    ViewBag.ContentType = "product";
                    ViewBag.ProductDetailList = business.GetProductDetailDataAll("product");
                    break;
                case "CLIENTILE":
                    ViewBag.ContentType = "clientile";
                    ViewBag.ClientileList = business.GetBannerClientileData("clientile");
                    break;

            }
            return View("edit");

        }

        //
        // POST: /Content/Edit/5

        [HttpPost]
        public ActionResult edit()
        {
            try
            {
                string ID = Request["Submit"];
                string ContentType = Request[ID + "-" + "ContentType"];
                switch (ContentType.ToUpper())
                {
                    case "BANNER":
                        BannerClientileModel bcObj = new BannerClientileModel();
                        bcObj.Id = int.Parse(ID);
                        bcObj.ContentType = ContentType;
                        bcObj.Description = Request[ID + "-" + "Description"];
                        bcObj.ImageAltText = Request[ID + "-" + "ImageAltText"];
                        bcObj.ImageHeader = Request[ID + "-" + "ImageHeader"];
                        bcObj.ImageUrl = Request[ID + "-" + "ImageUrl"];
                        bcObj.Tags = Request[ID + "-" + "Tags"];
                        bcObj.TargetUrl = Request[ID + "-" + "TargetUrl"];
                        if (business.UpdateBannerClientileContent(bcObj) == "OK")
                        {
                            ViewBag.ModelContent = bcObj;
                            ViewBag.ActionMessage = "This " + ContentType + " is Updated successfully";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Updating. Contact administrator!";
                            ViewBag.ModelContent = null;

                        }
                        return View();

                    case "PRODUCT-CATEGORY":
                        ProductCategoryModel pcObj = new ProductCategoryModel();
                        pcObj.Id = int.Parse(ID);
                        pcObj.ContentType = ContentType;
                        pcObj.Description = Request[ID + "-" + "Description"];
                        pcObj.ImageAltText = Request[ID + "-" + "ImageAltText"];
                        pcObj.ImageUrl = Request[ID + "-" + "ImageUrl"];
                        pcObj.PageContent = Uri.UnescapeDataString(ID + "-" + Request["PageContent"]);
                        pcObj.ProductCategory = Request[ID + "-" + "ProductCategory"];
                        pcObj.Tags = Request[ID + "-" + "Tags"];
                        if (business.UpdateProductCategory(pcObj) == "OK")
                        {
                            ViewBag.ModelContent = pcObj;
                            ViewBag.ActionMessage = "This " + ContentType + " is Updated Successfully";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Updating. Contact administrator!";
                            ViewBag.Model = null;
                        }
                        return View();
                    case "PRODUCT":
                        ProductDetailModel pdObj = new ProductDetailModel();
                        pdObj.Id = int.Parse(ID);
                        pdObj.ContentType = ContentType;
                        pdObj.Description = Request[ID + "-" + "Description"];
                        pdObj.ImageAltText = Request[ID + "-" + "ImageAltText"];
                        pdObj.ImageUrl = Request[ID + "-" + "ImageUrl"];
                        pdObj.PageContent = Request[ID + "-" + "PageContent"];
                        pdObj.ProductCategory = Request[ID + "-" + "ProductCategory"];
                        pdObj.ProductName = Request[ID + "-" + "ProductName"];
                        pdObj.Tags = Request[ID + "-" + "Tags"];
                        if (business.UpdateProductDetail(pdObj) == "OK")
                        {
                            ViewBag.ModelContent = pdObj;
                            ViewBag.ActionMessage = "This " + ContentType + " is Updated Successfully";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Updating. Contact administrator!";
                            ViewBag.Model = null;
                        }
                        return View();
                    case "CLIENTILE":
                        BannerClientileModel clObj = new BannerClientileModel();
                        clObj.Id = int.Parse(ID);
                        clObj.ContentType = ContentType;
                        clObj.Description = Request[ID + "-" + "Description"];
                        clObj.ImageAltText = Request[ID + "-" + "ImageAltText"];
                        clObj.ImageHeader = Request[ID + "-" + "ImageHeader"];
                        clObj.ImageUrl = Request[ID + "-" + "ImageUrl"];
                        clObj.Tags = Request[ID + "-" + "Tags"];
                        clObj.TargetUrl = Request[ID + "-" + "TargetUrl"];
                        if (business.UpdateBannerClientileContent(clObj) == "OK")
                        {
                            ViewBag.ModelContent = clObj;
                            ViewBag.ActionMessage = "This " + ContentType + " is Updated successfully";
                            ViewBag.Mode = "return";
                        }
                        else
                        {
                            ViewBag.ActionMessage = "Error While Updating. Contact administrator!";
                            ViewBag.ModelContent = null;

                        }
                        return View();
                    default:
                        break;
                }


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
