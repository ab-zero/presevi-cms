using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using presevi_cms.Models;
using presevi_cms.Models.DataLayer;

namespace presevi_cms.Controllers
{
    public class ContentController : Controller
    {
        public PreseviDataModel imageModel = new PreseviDataModel();
        public static Business business = new Business();
        [Authorize]
        public ActionResult ContentManage()
        {


            ViewBag.Mode = "fresh";
            return View();
        }

        public PartialViewResult GetData(string name)
        {
            return PartialView(imageModel);
        }

        public PartialViewResult Create(string name)
        {
            return PartialView(imageModel);
        }


        //
        // POST: /Content/Create

        [HttpPost]
        public ActionResult Create(string contentType, PreseviDataModel newImage)
        {

            try
            {
                newImage.ContentType = contentType;
                var result = business.CreateImageContent(newImage);

                ViewBag.ModelContent = newImage;
                ViewBag.ActionMessage = "This " + contentType + " is Created and is inserted in Content Management Database";
                ViewBag.Mode = "return";
                //return Redirect("/contentManage?mode=return");
                return View("ContentManage");
            }
            catch
            {
                return View(imageModel);
            }
        }

        //
        // GET: /Content/Edit/5

        public ActionResult Edit(string contentType)
        {
            return View(imageModel);
        }

        //
        // POST: /Content/Edit/5

        [HttpPost]
        public ActionResult Edit(string contentType, FormCollection collection)
        {
            try
            {


                return View(imageModel);
            }
            catch
            {
                return View(imageModel);
            }
        }



        public ActionResult Delete(string contentType)
        {
            return View(imageModel);
        }

        //
        // POST: /Content/Delete/5

        [HttpPost]
        public ActionResult Delete(string contentType, FormCollection collection)
        {
            try
            {


                return View(imageModel);
            }
            catch
            {
                return View(imageModel);
            }
        }
    }
}
