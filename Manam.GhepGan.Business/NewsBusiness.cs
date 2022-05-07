using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.DAL;
using Manam.GhepGan.Model;
using System.Linq;

namespace Manam.GhepGan.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly GhepGanDbContext _dbContext;

        public NewsBusiness(GhepGanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public NewsDetailViewModel? GetNewsDetail(string urlAlias)
        {
            var newsDetail = _dbContext.News.FirstOrDefault(f => !f.IsDeleted && f.UrlAlias == urlAlias);

            if (newsDetail == null)
            {
                return null;
            }

            var model = new NewsDetailViewModel
            {
                Id = newsDetail.Id,
                Title = newsDetail.Title,
                Content = newsDetail.Content,
                CreatedDate = newsDetail.CreatedDate.ToString("dd-MM-yyyy"),
                ViewCount = newsDetail.ViewCount,
                Description = newsDetail.Description,
            };

            return model;
        }

        public List<NewsItem> GetNewsList(int offset, int limit)
        {
            var query = (from n in _dbContext.News
                         where !n.IsDeleted
                         orderby n.Id descending
                         select new NewsItem
                         {
                             Id = n.Id,
                             Title = n.Title,
                             Description = n.Description,
                             CreatedDate = n.CreatedDate.ToString("dd-MM-yyyy"),
                             ViewCount = n.ViewCount,
                             Avatar = n.Avatar,
                             UrlAlias = n.UrlAlias
                         });

            var newsList = query.Skip(offset).Take(limit).ToList();

            return newsList;
        }

        public int GetNewsCount()
        {
            var count = _dbContext.News.Select(s => !s.IsDeleted).Count();
            return count;
        }

        public NewsViewModel GetNewsData(long id)
        {
            var news = _dbContext.News.FirstOrDefault(f => f.Id == id);
            if(news != null)
            {
                NewsViewModel response = new NewsViewModel
                {
                    Id = news.Id,
                    Title = news.Title,
                    Content = news.Content,
                    Description = news.Description,
                    Avatar = news.Avatar,
                };

                return response;
            }

            return new NewsViewModel();
        }
    }
}
