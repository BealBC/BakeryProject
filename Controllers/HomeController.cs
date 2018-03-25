using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BakeryProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is the About page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is the Contact page.";
            return View();
        }
    }
}