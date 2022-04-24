using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Solution")]
    public class SolutionViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("Index");
        }

    }
}
