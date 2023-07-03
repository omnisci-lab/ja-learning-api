using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "Detail")]
public class DetailViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, object data)
    {
        PropertyInfo[] properties = type.GetProperties();

        ViewData["Properties"] = properties;
        ViewData["Data"] = data;

        return View();
    }
}