using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebCore;
using WebCore.Attributes;
using WebCore.DynamicForm;
using WebCore.Extensions;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicCreateView")]
public class DynamicCreateViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, object data, Type metadataType, UrlInfo formUrl, UrlInfo listUrl)
    {
        DynamicForm form = new DynamicForm();
        form.ActionName = formUrl.ActionName;
        form.ControllerName = formUrl.ControllerName;

        if (metadataType is null || formUrl is null || listUrl is null)
            throw new NullReferenceException();

        RouteValueDictionary routeValueDict = new RouteValueDictionary();
        routeValueDict.From(listUrl.RouteValues, type, data);

        ViewData["ListUrl"] = Url.Action(listUrl.ActionName, listUrl.ControllerName, routeValueDict);

        if (type is null || data is null)
        {
            form.FormFields = metadataType.GetProperties().Select(s =>
            {
                DynamicFormField formField = new DynamicFormField { Name = s.Name };

                DynamicViewAttribute? dynamicViewAttribute = s.GetCustomAttribute<DynamicViewAttribute>();
                if (dynamicViewAttribute is null)
                    formField.FieldType = FormFieldType.Text;
                else
                    formField.FieldType = dynamicViewAttribute.FieldType;

                return formField;

            }).ToList();

            return View(form);
        }

        form.FormFields = metadataType.GetProperties().Select(s =>
        {
            DynamicFormField formField = new DynamicFormField { Name = s.Name };

            PropertyInfo? property = type.GetProperty(s.Name);
            formField.Value = property?.GetValue(data);

            DynamicViewAttribute? dynamicViewAttribute = s.GetCustomAttribute<DynamicViewAttribute>();
            if (dynamicViewAttribute is null)
                formField.FieldType = FormFieldType.Text;
            else
                formField.FieldType = dynamicViewAttribute.FieldType;

            return formField;

        }).ToList();

        return View(form);
    }
}