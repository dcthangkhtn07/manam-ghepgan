using Manam.GhepGan.Model;

namespace Manam.GhepGan.Business.Interfaces
{
    public interface INewsBusiness
    {
        List<NewsItem> GetNewsList(int offset, int limit);

        NewsDetailViewModel? GetNewsDetail(string urlAlias);

        int GetNewsCount();
    }
}
