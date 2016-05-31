using System;
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
            ViewBag.BannerList = business.GetContent("BANNER");

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

        public ActionResult ContentManage()
        {
            ViewBag.isAuthenticated = false;
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult _LoginPartial()
        {
            LoginModel model = new LoginModel();
            return PartialView(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult _LoginPartial(LoginModel model)
        {
            Business business = new Business();
            ViewBag.isAuthenticated = false;
            if (ModelState.IsValid && business.AuthenticateUser(model.UserName, model.Password))
            {
                ViewBag.isAuthenticated = true;
                return PartialView("_contentPartial");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return PartialView(model);
            }
            
            
        }

        


    }
}
