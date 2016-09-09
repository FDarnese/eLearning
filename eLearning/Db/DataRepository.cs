using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web;

namespace eLearning.Db
{
    public class DataRepository
    {
        public IQueryable<NavBarItem> AllNavBarItems
        {
            get
            {
                var items = HttpContext.Current.Items["AllNavBarItems"] as NavBarItem[];

                if (items == null)
                {

                    var srcFile = HttpContext.Current.Server.MapPath("~/App_Data/nav-bar.json");
                    var json = File.ReadAllText(srcFile);
                    items = JsonConvert.DeserializeObject<NavBarItem[]>(json);

                    HttpContext.Current.Items["AllNavBarItems"] = items;
                }

                return items.AsQueryable();
            }
        }

        public IQueryable<NavTile> AllNavTiles
        {
            get
            {
                var tiles = HttpContext.Current.Items["AllNavTiles"] as NavTile[];

                if (tiles == null)
                {

                    var srcFile = HttpContext.Current.Server.MapPath("~/App_Data/nav-tiles.json");
                    var json = File.ReadAllText(srcFile);
                    tiles = JsonConvert.DeserializeObject<NavTile[]>(json);

                    HttpContext.Current.Items["AllNavTiles"] = tiles;
                }

                return tiles.AsQueryable();
            }
        }

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