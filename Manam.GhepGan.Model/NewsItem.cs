namespace Manam.GhepGan.Model
{
    public class NewsItem
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CreatedDate { get; set; } = string.Empty;

        public long ViewCount { get; set; }

        public long CommentCount { get; set; }
    }
}
