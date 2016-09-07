using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearning.Db
{
    public class Article
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("display")]
        public string Display { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("featured")]
        public bool Featured { get; set; }
        [JsonProperty("chapters")]
        public Chapter[] Chapters { get; set; }
    }
}