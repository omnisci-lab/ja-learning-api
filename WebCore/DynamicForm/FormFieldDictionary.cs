using System.Reflection;

namespace WebCore.DynamicForm;

public class FormFieldDictionary : Dictionary<string, object?>
{
    public void From(List<DynamicFormField> formFields, Type type, object data)
    {
        foreach (DynamicFormField formField in formFields)
        {
            PropertyInfo? property = type.GetProperty(formField.MapToProperty!);
            object? propertyValue = (property is null) ? null : property.GetValue(data);

            Add(formField.Name!, propertyValue);
        }
    }
}
