namespace WebCore.DynamicForm;

public class DynamicForm
{
    public string? ActionName { get; set; }
    public string? ControllerName { get; set; }

    public List<DynamicFormField> FormFields { get; set; } = new List<DynamicFormField>();
}
