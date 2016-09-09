namespace eLearning.Models.Shared
{
    public class NavBarItemVM
    {
        public string Display { get; set; }
        public string ArticleUid { get; set; }
        public NavBarItemVM[] Items { get; set; }

        public NavBarItemVM()
        {
            Items = new NavBarItemVM[] { };
        }
    }
}