namespace eLearning.Models.Articles
{
    public class DictionaryVM
    {
        public DictionaryCategoryItemVM[] Categories { get; set; }

        public DictionaryVM()
        {
            Categories = new DictionaryCategoryItemVM[] { };
        }
    }
}