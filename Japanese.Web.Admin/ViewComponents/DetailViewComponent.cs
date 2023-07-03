using Japanese.Web.Admin.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "Detail")]
public class DetailViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, Type metadataType, object data, UrlInfo listUrl, UrlInfo editUrl, UrlInfo deleteUrl)
    {
        Dictionary<string, object?> keyValuePairs = metadataType.GetProperties().Select(s =>
        {
            DisplayAttribute? displayAttribute = s.GetCustomAttribute<DisplayAttribute>();

            PropertyInfo? property = type.GetProperty(s.Name);
            object? propertyValue = (property is null) ? null : property.GetValue(data);

            if (displayAttribute is not null && !string.IsNullOrEmpty(displayAttribute.Name))
                return new { Name = displayAttribute.Name, Value = propertyValue };
            else
                return new { Name = s.Name, Value = propertyValue };

        }).ToDictionary(d => d.Name, d => d.Value);

        ViewData["ListUrl"] = Url.Action(listUrl.ActionName, listUrl.ControllerName);

        RouteValueDictionary edit_RouteValueDict = new RouteValueDictionary();
        foreach(RouteValueObject edit_RouteValueObject in editUrl.RouteValues!)
        {
            PropertyInfo? property = type.GetProperty(edit_RouteValueObject.MapToProperty!);
            object? propertyValue = (property is null) ? null : property.GetValue(data);

            edit_RouteValueDict.Add(edit_RouteValueObject.RouteProperty!, propertyValue);
        }

        ViewData["EditUrl"] = Url.Action(editUrl.ActionName, editUrl.ControllerName, edit_RouteValueDict);

        RouteValueDictionary delete_RouteValueDict = new RouteValueDictionary();
        foreach (RouteValueObject delete_RouteValueObject in editUrl.RouteValues!)
        {
            PropertyInfo? property = type.GetProperty(delete_RouteValueObject.MapToProperty!);
            object? propertyValue = (property is null) ? null : property.GetValue(data);

            delete_RouteValueDict.Add(delete_RouteValueObject.RouteProperty!, propertyValue);
        }

        ViewData["DeleteUrl"] = Url.Action(editUrl.ActionName, deleteUrl.ControllerName);

        return View(keyValuePairs);
    }
}