namespace WebCore.DynamicForm;

public class DynamicFormField
{
    public string? Name { get; set; }
    public string? MapToProperty { get; set; }
    public FormFieldType FieldType { get; set; }
    public object? Value { get; set; }
}