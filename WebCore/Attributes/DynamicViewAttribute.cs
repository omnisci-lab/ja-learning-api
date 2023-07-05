
using WebCore.DynamicForm;

namespace WebCore.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DynamicViewAttribute : Attribute
{
    public bool Table { get; set; } = false;
    public bool Detail { get; set; } = true;
    public bool IsTitleOnDetail { get; set; } = false;
    public FormFieldType FieldType { get; set; } = FormFieldType.Text;
}
