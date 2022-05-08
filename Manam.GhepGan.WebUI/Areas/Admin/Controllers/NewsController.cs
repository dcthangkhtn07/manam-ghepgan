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

        [HttpGet]
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

        [HttpPost]
        public IActionResult Index(NewsViewModel model)
        {
            string avatarId = Guid.NewGuid().ToString();
            if (model.File != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/news");
                FileInfo fileInfo = new FileInfo(model.File.FileName);
                string fileName = avatarId + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
                model.Avatar = fileName;
            }

            model.CreatedBy = Guid.NewGuid();

            if (model.Id == 0)
            {
                _newsBusiness.InsertNews(model);
            }
            else
            {
                _newsBusiness.UpdateNews(model);
            }    

            return Json(new
            {
                Status = "OK"
            });
        }

        public IActionResult Delete(long id)
        {
            _newsBusiness.DeleteNews(id);

            return Json(new
            {
                Status = "OK"
            });
        }

        public IActionResult List()
        {
            NewsListViewModel model = new NewsListViewModel();
            model.NewsList = _newsBusiness.GetNewsList(0, 1000);
            return View(model);
        }
    }
}
