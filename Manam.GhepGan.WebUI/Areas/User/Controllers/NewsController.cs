using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.Model;
using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class NewsController : Controller
    {
        private readonly INewsBusiness _newsBusiness;

        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        [Route("/tin-tuc/{urlAlias}")]
        public IActionResult Index(string urlAlias)
        {
            var model = _newsBusiness.GetNewsDetail(urlAlias);
            if (model == null)
            {
                return NotFound();
            }

            model.NewsRelated = _newsBusiness.GetNewsList(0, 10);

            return View(model);
        }

        [Route("/tin-tuc")]
        public IActionResult List(int? page)
        {
            var pageIndex = page ?? 1;

            var itemsPerPage = 10;
            var offset = (pageIndex - 1) * itemsPerPage;

            NewsListViewModel model = new NewsListViewModel();
            model.NewsList = _newsBusiness.GetNewsList(offset, itemsPerPage);
            model.TotalItems = _newsBusiness.GetNewsCount();

            return View(model);
        }
    }
}
