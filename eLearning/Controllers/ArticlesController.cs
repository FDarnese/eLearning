using System.Web.Mvc;
using System.Linq;
using eLearning.Db;
using eLearning.Models.Articles;
using System.Web;

namespace eLearning.Controllers
{
    public class ArticlesController : BaseController
    {
        // GET: Articles
        public ActionResult Index()
        {
            var all = DataRepo.AllArticles.ToArray();
            return View();
        }

        public ActionResult Article(string id, string chapterId)
        {
            var article = DataRepo.AllArticles.FirstOrDefault(x => x.Uid == id);
            if (article == null)
                throw new HttpException(404, "Article not found");

            if (string.IsNullOrWhiteSpace(chapterId))
                chapterId = article.Chapters.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.Separator))?.Uid;

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
                Categories = DataRepo.AllCategories.Select(x => new DictionaryCategoryItemVM()
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
            var article = DataRepo.AllArticles.FirstOrDefault(x => x.Uid == id);
            if (article == null)
                throw new HttpException(404, "Article not found");

            var vm = new ContentsVM()
            {
                ArticleUid = article.Uid,
                ArticleDisplay = article.Display,
                Contents = article.Chapters.Select(x => new ContentsItemVM()
                {
                    Uid = x.Uid,
                    Separator = x.Separator,
                    Display = x.Display,
                    Content = x.Content
                })
                .ToArray()
            };

            return PartialView("~/Views/Articles/Partials/Contents.cshtml", vm);
        }
    }
}