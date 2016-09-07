namespace eLearning.Models.Articles
{
    public class DictionaryCategoryItemVM
    {
        public string Uid { get; set; }
        public string Display { get; set; }

        public DictionaryArticleItemVM[] Articles { get; set; }

        public DictionaryCategoryItemVM()
        {
            Articles = new DictionaryArticleItemVM[] { };
        }
    }
}