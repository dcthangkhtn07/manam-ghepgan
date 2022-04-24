using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly INewsBusiness _newsBusiness;

        public HomeController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        [Route("/")]
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.NewsList = _newsBusiness.GetNewsList(0, 2);

            return View(model);
        }
    }
}
