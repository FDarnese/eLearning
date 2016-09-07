namespace eLearning.Models.Articles
{
    public class ContentsVM
    {
        public string ArticleUid { get; set; }
        public string ArticleDisplay { get; set; }

        public ContentsItemVM[] Contents { get; set; }
        public ContentsVM()
        {
            Contents = new ContentsItemVM[] { };
        }
    }
}