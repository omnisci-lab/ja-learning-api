using WebCore.Attributes;
using WebCore.DynamicForm;

namespace Japanese.Web.Admin;

public class CreateSentenceCommandMetadata
{
    [DynamicView(FieldType = FormFieldType.TextArea)]
    public string? Text { get; set; }

    [DynamicView(FieldType = FormFieldType.Text)]
    public string? Structure { get; set; }

    [DynamicView(FieldType = FormFieldType.Text)]
    public int Jlpt { get; set; }

    [DynamicView(FieldType = FormFieldType.TextArea)]
    public string? EnMeanings { get; set; }

    [DynamicView(FieldType = FormFieldType.TextArea)]
    public string? ViMeanings { get; set; }

    [DynamicView(FieldType = FormFieldType.Text)]
    public string? References { get; set; }
}
