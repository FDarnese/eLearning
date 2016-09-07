using System.Web.Mvc;
using System.Linq;
using eLearning.Db;
using eLearning.Models.Articles;
using System.Web;

namespace eLearning.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ArticlesRepository repo = new ArticlesRepository();

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

        // GET: Articles
        public ActionResult Index()
        {
            var all = repo.AllArticles.ToArray();
            return View();
        }

        public ActionResult Article(string id)
        {
            var article = repo.AllArticles.FirstOrDefault(x => x.Uid == id);
            if (article == null)
                throw new HttpException(404, "Article not found");

            var vm = new ArticleVM()
            {
                Uid = article.Uid,
                Display = article.Display,
                Description = article.Description
            };

            return View(vm);
        }

        public ActionResult Chapter(string id, string chapterId)
        {
            var article = repo.AllArticles.FirstOrDefault(x => x.Uid == id);
            if (article == null)
                throw new HttpException(404, "Article not found");

            var chapter = article.Chapters.FirstOrDefault(x => x.Uid == chapterId);
            if (chapter == null)
                throw new HttpException(404, "Chapter not found");

            var index = article.Chapters.ToList().IndexOf(chapter);
            var vm = new ChapterVM()
            {
                Uid = chapter.Uid,
                ArticleUid = article.Uid,
                Display = chapter.Display,
                ContentHtml = Db.Chapter.GetHtmlContent(HttpContext, chapter),
                PreviousUid = index > 0 ? article.Chapters[index - 1].Uid : string.Empty,
                NextUid = index < article.Chapters.Length - 1 ? article.Chapters[index + 1].Uid : string.Empty
            };
            return View(vm);
        }

        public PartialViewResult _Dictionary()
        {
            var vm = new DictionaryVM()
            {
                Categories = repo.AllCategories.Select(x => new DictionaryCategoryItemVM()
                {
                    Uid = x.Uid,
                    Display = x.Display,
                    Articles = x.Articles.Select(y => new DictionaryArticleItemVM()
                    {
                        Uid = y.Uid,
                        Display = y.Display,
                        Description = y.Description
                    }).ToArray()
                })
                .ToArray()
            };

            return PartialView("~/Views/Articles/Partials/Dictionary.cshtml", vm);
        }

        public PartialViewResult _Contents(string id)
        {
            var article = repo.AllArticles.FirstOrDefault(x => x.Uid == id);
            if (article == null)
                throw new HttpException(404, "Article not found");

            var vm = new ContentsVM()
            {
                ArticleUid = article.Uid,
                ArticleDisplay = article.Display,
                Contents = article.Chapters.Select(x => new ContentsItemVM()
                {
                    Uid = x.Uid,
                    Display = x.Display,
                    Content = x.Content
                })
                .ToArray()
            };

            return PartialView("~/Views/Articles/Partials/Contents.cshtml", vm);
        }
    }
}