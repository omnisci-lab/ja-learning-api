using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebCore;
using WebCore.Attributes;
using WebCore.DynamicForm;
using WebCore.Extensions;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicDetailView")]
public class DynamicDetailViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, Type metadataType, object data, UrlInfo listUrl, UrlInfo editUrl, DynamicForm deletionForm)
    {
        Dictionary<string, object?> keyValues = new Dictionary<string, object?>();
        string? titleOnDetail = null;
        foreach (PropertyInfo metadataType_property in metadataType.GetRuntimeProperties())
        {
            DisplayAttribute? displayAttribute = metadataType_property.GetCustomAttribute<DisplayAttribute>();
            PropertyInfo? property = type.GetProperty(metadataType_property.Name);

            object? propertyValue = property?.GetValue(data);

            if (displayAttribute is not null && !string.IsNullOrEmpty(displayAttribute.Name))
                keyValues.Add(displayAttribute.Name!, propertyValue);
            else
                keyValues.Add(metadataType_property.Name, propertyValue);

            if (titleOnDetail is null)
            {
                DynamicViewAttribute? dynamicViewAttribute = metadataType_property.GetCustomAttribute<DynamicViewAttribute>();
                if (dynamicViewAttribute is not null && dynamicViewAttribute.IsTitleOnDetail)
                    titleOnDetail = $"{propertyValue}";
            }
        }

        ViewData["TitleOnDetail"] = titleOnDetail;

        RouteValueDictionary list_RouteValueDict = new RouteValueDictionary();
        list_RouteValueDict.From(listUrl.RouteValues, type, data);

        ViewData["ListUrl"] = Url.Action(listUrl.ActionName, listUrl.ControllerName);

        RouteValueDictionary edit_RouteValueDict = new RouteValueDictionary();
        edit_RouteValueDict.From(editUrl.RouteValues, type, data);

        ViewData["EditUrl"] = Url.Action(editUrl.ActionName, editUrl.ControllerName, edit_RouteValueDict);

        FormFieldDictionary deletionFormFieldDict = new FormFieldDictionary();
        deletionFormFieldDict.From(deletionForm.FormFields, type, data);

        ViewData["DeleteUrl"] = Url.Action(deletionForm.ActionName, deletionForm.ControllerName);
        ViewData["DeletionFormFieldDict"] = deletionFormFieldDict;

        return View(keyValues);
    }
}