using Newtonsoft.Json;

namespace eLearning.Db
{
    public class Category
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("display")]
        public string Display { get; set; }
        [JsonProperty("articles")]
        public Article[] Articles { get; set; }

        public Category()
        {
            Articles = new Article[] { };
        }
    }
}