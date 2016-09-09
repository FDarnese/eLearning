using System.Web.Mvc;
using System.Web.Routing;

namespace eLearning
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LibArticles",
                url: "lib",
                defaults: new { controller = "Articles", action = "Index" }
            );
            
            routes.MapRoute(
                name: "LibChapter",
                url: "lib/{id}/{chapterId}",
                defaults: new { controller = "Articles", action = "Article", chapterId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
