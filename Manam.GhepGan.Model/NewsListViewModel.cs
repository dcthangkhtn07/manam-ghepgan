namespace Manam.GhepGan.Model
{
    public class NewsListViewModel
    {
        public List<NewsItem> NewsList { get; set; } = new List<NewsItem>();

        public int TotalItems { get; set; } = 0;
    }
}