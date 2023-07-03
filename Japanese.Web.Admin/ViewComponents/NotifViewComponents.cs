using Microsoft.AspNetCore.Mvc;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "Notif")]
public class NotifViewComponents : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}