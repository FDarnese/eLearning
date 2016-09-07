namespace eLearning.Models.Articles
{
    public class ChapterVM
    {
        public string ArticleUid { get; set; }
        public string Uid { get; set; }
        public string Display { get; set; }
        public string ContentHtml { get; set; }

        public string NextUid { get; set; }
        public string PreviousUid { get; set; }
    }
}