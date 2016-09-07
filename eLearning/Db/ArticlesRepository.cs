using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web;

namespace eLearning.Db
{
    public class ArticlesRepository
    {
        public IQueryable<Category> AllCategories
        {
            get
            {
                var categories = HttpContext.Current.Items["AllCategories"] as Category[];

                if (categories == null)
                {

                    var srcFile = HttpContext.Current.Server.MapPath("~/App_Data/dictionary.json");
                    var json = File.ReadAllText(srcFile);
                    categories = JsonConvert.DeserializeObject<Category[]>(json);

                    HttpContext.Current.Items["AllCategories"] = categories;
                }

                return categories.AsQueryable();
            }
        }

        public IQueryable<Article> AllArticles
        {
            get
            {
                return AllCategories.SelectMany(x => x.Articles).AsQueryable();
            }
        }
    }
}