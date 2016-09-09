using Newtonsoft.Json;

namespace eLearning.Db
{
    public class NavBarItem
    {
        [JsonProperty("display")]
        public string Display { get; set; }
        [JsonProperty("article-uid")]
        public string ArticleUid { get; set; }

        [JsonProperty("items")]
        public NavBarItem[] Items { get; set; }

        public NavBarItem()
        {
            Items = new NavBarItem[] { };
        }
    }
}