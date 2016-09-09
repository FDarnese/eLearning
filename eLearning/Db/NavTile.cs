using Newtonsoft.Json;

namespace eLearning.Db
{
    public class NavTile
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("display")]
        public string Dispaly { get; set; }
        [JsonProperty("article-uid")]
        public string ArticleUid { get; set; }
        [JsonProperty("cert-name")]
        public string CertName { get; set; }
        [JsonProperty("cert-uid")]
        public string CertUid { get; set; }
    }
}