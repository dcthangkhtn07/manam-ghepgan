using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Manam.GhepGan.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}