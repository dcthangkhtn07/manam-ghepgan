namespace Manam.GhepGan.Model
{
    public class NewsDetailViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CreatedDate { get; set; } = string.Empty;

        public long ViewCount { get; set; }

        public List<NewsItem> NewsRelated { get; set; } = new List<NewsItem>();
    }
}
