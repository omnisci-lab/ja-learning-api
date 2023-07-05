
namespace WebCore;

public class UrlInfo
{
    public string? ActionName { get; set; }
    public string? ControllerName { get; set; }

    public List<RouteValueObject> RouteValues { get; set; } = new List<RouteValueObject>();
}
