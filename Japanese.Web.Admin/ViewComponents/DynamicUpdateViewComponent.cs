using Microsoft.AspNetCore.Mvc;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicUpdateView")]
public class DynamicUpdateViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
