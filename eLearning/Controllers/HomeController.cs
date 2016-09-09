using System.Web.Mvc;
using System.Linq;
using eLearning.Db;
using eLearning.Models.Shared;
using System;

namespace eLearning.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HTML()
        {
            ViewBag.Message = "Impara HTML, il linguaggio per costruire pagine web.";

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

        public PartialViewResult _NavTiles()
        {
            var vm = DataRepo.AllNavTiles.Select(x => new NavTileVM()
            {
                Uid = x.Uid,
                ArticleUid = x.ArticleUid,
                ArticleDisplay = DataRepo.AllArticles.First(a => a.Uid == x.ArticleUid).Display,
                CertName = x.CertName,
                CertUid = x.CertUid,
                Display = x.Dispaly
            }).ToArray();

            return PartialView(@"~/Views/Shared/Partials/_NavTiles.cshtml", vm);
        }

        public PartialViewResult _NavBar()
        {
            Func<NavBarItem, NavBarItemVM> itemMapper = null;
            itemMapper = new Func<NavBarItem, NavBarItemVM>(item => new NavBarItemVM()
            {
                ArticleUid = item.ArticleUid,
                Display = item.Display,
                Items = item.Items.Select(itemMapper).ToArray()
            });

            var vm = DataRepo.AllNavBarItems.Select(itemMapper).ToArray();

            return PartialView("~/Views/Shared/Partials/_NavBar.cshtml", vm);
        }
    }
}