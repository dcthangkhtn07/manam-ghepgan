using Microsoft.AspNetCore.Mvc;

namespace Manam.GhepGan.WebUI.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Procedure")]
    public class ProcedureViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("Index");
        }

    }
}
