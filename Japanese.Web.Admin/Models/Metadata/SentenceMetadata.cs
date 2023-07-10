using System.ComponentModel.DataAnnotations;
using WebCore.Attributes;
using WebCore.DynamicForm;

namespace Japanese.Web.Admin.Models.Metadata;

public class SentenceMetadata
{
    public class SentenceOutput
    {
        [Display(Name = "Sentence Id")]
        [DynamicView(Table = true, Detail = true)]
        public string? SentenceId { get; set; }

        [Display(Name = "Text")]
        [DynamicView(Table = true, Detail = true, IsTitleOnDetail = true)]
        public string? Text { get; set; }

        [DynamicView(Table = true, Detail = true)]
        public string? Structure { get; set; }

        [Display(Name = "JLPT")]
        [DynamicView(Table = true, Detail = true)]
        public int Jlpt { get; set; }

        public string? EnMeanings { get; set; }

        [Display(Name = "Vi Meanings")]
        [DynamicView(Table = true, Detail = true)]
        public string? ViMeanings { get; set; }

        public string? References { get; set; }
    }

    public class CreateSentenceCommand
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

    public class UpdateSentenceCommand
    {
        [DynamicView(FieldType = FormFieldType.Hidden)]
        public string? SentenceId { get; set; }

        [DynamicView(FieldType = FormFieldType.TextArea, IsTitleOnEdit = true)]
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
}