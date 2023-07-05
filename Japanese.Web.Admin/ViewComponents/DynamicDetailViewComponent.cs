using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebCore;
using WebCore.DynamicForm;
using WebCore.Extensions;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicDetail")]
public class DynamicDetailViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, Type metadataType, object data, UrlInfo listUrl, UrlInfo editUrl, DynamicForm deletionForm)
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
        edit_RouteValueDict.From(editUrl.RouteValues, type, data);

        ViewData["EditUrl"] = Url.Action(editUrl.ActionName, editUrl.ControllerName, edit_RouteValueDict);

        FormFieldDictionary deletionFormFieldDict = new FormFieldDictionary();
        deletionFormFieldDict.From(deletionForm.FormFields, type, data);

        ViewData["DeleteUrl"] = Url.Action(deletionForm.ActionName, deletionForm.ControllerName);
        ViewData["DeletionFormFieldDict"] = deletionFormFieldDict;

        return View(keyValuePairs);
    }
}