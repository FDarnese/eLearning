using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace eLearning.Db
{
    public class Chapter
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("display")]
        public string Display { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }

        public static string GetHtmlContent(HttpContextBase context, Chapter chapter)
        {
            var root = context.Server.MapPath("~/Content/articles/");
            var fullPath = Path.Combine(root, chapter.Content);
            return File.ReadAllText(fullPath);
        }
    }
}