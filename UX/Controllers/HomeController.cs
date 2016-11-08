using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Order()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserList()
        {
            if (User.Identity.IsAuthenticated) return View();
            return RedirectToAction("Index");
        }

        public ActionResult Chat()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.user = User.Identity.Name;
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Messages()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.user = User.Identity.Name;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}