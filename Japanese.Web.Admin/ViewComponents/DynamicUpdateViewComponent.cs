using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebCore;
using WebCore.Attributes;
using WebCore.DynamicForm;
using WebCore.Extensions;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicUpdateView")]
public class DynamicUpdateViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, object data, Type metadataType, UrlInfo formUrl, UrlInfo detailUrl, UrlInfo listUrl, DynamicForm deletionForm)
    {
        DynamicForm form = new DynamicForm();
        form.ActionName = formUrl.ActionName;
        form.ControllerName = formUrl.ControllerName;

        if (metadataType is null || formUrl is null || detailUrl is null || listUrl is null)
            throw new NullReferenceException();

        RouteValueDictionary routeValueDict = new RouteValueDictionary();
        routeValueDict.From(listUrl.RouteValues, type, data);

        ViewData["ListUrl"] = Url.Action(listUrl.ActionName, listUrl.ControllerName, routeValueDict);

        RouteValueDictionary detail_RouteValueDict = new RouteValueDictionary();
        detail_RouteValueDict.From(detailUrl.RouteValues, type, data);

        ViewData["DetailUrl"] = Url.Action(detailUrl.ActionName, detailUrl.ControllerName, detail_RouteValueDict);

        FormFieldDictionary deletionFormFieldDict = new FormFieldDictionary();
        deletionFormFieldDict.From(deletionForm.FormFields, type, data);

        ViewData["DeleteUrl"] = Url.Action(deletionForm.ActionName, deletionForm.ControllerName);
        ViewData["DeletionFormFieldDict"] = deletionFormFieldDict;

        string? titleOnEdit = null;

        if (type is null || data is null)
        {
            foreach(PropertyInfo metadataType_property in metadataType.GetProperties())
            {
                DynamicFormField formField = new DynamicFormField { Name = metadataType_property.Name };

                DynamicViewAttribute? dynamicViewAttribute = metadataType_property.GetCustomAttribute<DynamicViewAttribute>();
                if (dynamicViewAttribute is null)
                {
                    formField.FieldType = FormFieldType.Text;
                }
                else
                {
                    formField.FieldType = dynamicViewAttribute.FieldType;
                    if (dynamicViewAttribute.IsTitleOnEdit && titleOnEdit is null)
                        titleOnEdit = "...";
                }

                form.FormFields.Add(formField);
            }
        }
        else
        {
            foreach (PropertyInfo metadataType_property in metadataType.GetProperties())
            {
                DynamicFormField formField = new DynamicFormField { Name = metadataType_property.Name };

                PropertyInfo? property = type.GetProperty(metadataType_property.Name);
                formField.Value = property?.GetValue(data);

                DynamicViewAttribute? dynamicViewAttribute = metadataType_property.GetCustomAttribute<DynamicViewAttribute>();
                if (dynamicViewAttribute is null)
                {
                    formField.FieldType = FormFieldType.Text;
                }
                else
                {
                    formField.FieldType = dynamicViewAttribute.FieldType;
                    if (dynamicViewAttribute.IsTitleOnEdit && titleOnEdit is null)
                        titleOnEdit = $"{formField.Value}";
                }

                form.FormFields.Add(formField);
            }
        }

        ViewData["TitleOnEdit"] = titleOnEdit;

        return View(form);
    }
}