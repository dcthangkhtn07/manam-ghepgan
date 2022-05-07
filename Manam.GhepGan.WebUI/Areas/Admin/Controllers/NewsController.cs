using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class NewsController : Controller
    {
        private readonly INewsBusiness _newsBusiness;

        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        public IActionResult Index(long? id)
        {
            var newsId = id ?? 0;
            var model = new NewsViewModel();
            if (newsId != 0)
            {
                model = _newsBusiness.GetNewsData(newsId);
            }

            if (string.IsNullOrEmpty(model.Avatar))
            {
                model.Avatar = "news.png";
            }

            return View(model);
        }

        public IActionResult List()
        {
            NewsListViewModel model = new NewsListViewModel();
            model.NewsList = _newsBusiness.GetNewsList(0, 1000);
            return View(model);
        }
    }
}
