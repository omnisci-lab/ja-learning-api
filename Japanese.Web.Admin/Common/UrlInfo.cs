
namespace Japanese.Web.Admin.Common;

public class UrlInfo
{
    public string? ActionName { get; set; }
    public string? ControllerName { get; set; }

    public List<RouteValueObject>? RouteValues { get; set; }
}
