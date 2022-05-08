using Manam.GhepGan.Model;

namespace Manam.GhepGan.Business.Interfaces
{
    public interface INewsBusiness
    {
        List<NewsItem> GetNewsList(int offset, int limit);

        NewsDetailViewModel? GetNewsDetail(string urlAlias);

        int GetNewsCount();

        NewsViewModel GetNewsData(long id);

        long InsertNews(NewsViewModel news);

        long UpdateNews(NewsViewModel news);

        bool DeleteNews(long id);
    }
}
