using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Impara()
        {
            ViewBag.Message = "Your programming languages list page.";

            return View();
        }

        public ActionResult Certificati()
        {
            ViewBag.Message = "Your cerfificates page.";

            return View();
        }
        public ActionResult ChiSiamo()
        {
            ViewBag.Message = "About page.";

            return View();
        }
    }
}