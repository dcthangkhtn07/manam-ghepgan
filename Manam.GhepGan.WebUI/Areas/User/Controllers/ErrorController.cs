using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ErrorController : Controller
    {
        [Route("error/404")]
        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}
