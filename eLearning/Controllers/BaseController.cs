using eLearning.Db;
using eLearning.Models.Articles;
using System.Linq;
using System.Web.Mvc;

namespace eLearning.Controllers
{
    public class BaseController : Controller
    {
        private readonly DataRepository repo = new DataRepository();
        public DataRepository DataRepo
        {
            get { return repo; }
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.FeaturedArticles = repo.AllArticles.Where(x => x.Featured).Select(x => new ArticleVM()
            {
                Uid = x.Uid,
                Display = x.Display,
                Description = x.Description
            }).ToArray();

            base.OnResultExecuting(filterContext);
        }
    }
}