using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebCore.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class PageTitleAttribute : ActionFilterAttribute
{
    public string? Title { get; set; }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        Controller? controller = filterContext.Controller as Controller;
        if (controller is not null)
            controller.ViewData["PageTitle"] = Title;
    }
}