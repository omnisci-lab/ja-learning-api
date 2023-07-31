using WebCore.Attributes;
using WebCore.DynamicForm;

namespace Japanese.Web.Admin.Models.Metadata;

public class KanjiMetadata
{
    public class KanjiDetailOutput
    {
        [DynamicView(Table = true, Detail = true, IsTitleOnDetail = true)]
        public string? Kanji { get; set; }

        [DynamicView(Table = true, Detail = true)]
        public int StrokeCount { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public int? Grade { get; set; }

        [DynamicView(Table = true, Detail = true)]
        public List<string>? OnReadings { get; set; }

        [DynamicView(Table = true, Detail = true)]
        public List<string>? KunReadings { get; set; }

        [DynamicView(Table = true, Detail = true)]
        public List<string>? NameReadings { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public List<string>? EnMeanings { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public List<string>? SinoVietnamese { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public List<string>? ViMeanings { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public int? Jlpt { get; set; }

        [DynamicView(Table = false, Detail = true)]
        public string? Unicode { get; set; }
    }

    public class CreateKanjiCommand
    {
        [DynamicView(FieldType = FormFieldType.Text)]
        public string? Kanji { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int StrokeCount { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int? Grade { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? OnReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? KunReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? NameReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? EnMeanings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? SinoVietnamese { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? ViMeanings { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int? Jlpt { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public string? Unicode { get; set; }
    }

    public class UpdateKanjiCommand
    {
        [DynamicView(FieldType = FormFieldType.Text)]
        public string? Kanji { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int StrokeCount { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int? Grade { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? OnReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? KunReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? NameReadings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? EnMeanings { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? SinoVietnamese { get; set; }

        [DynamicView(FieldType = FormFieldType.List)]
        public List<string>? ViMeanings { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public int? Jlpt { get; set; }

        [DynamicView(FieldType = FormFieldType.Text)]
        public string? Unicode { get; set; }
    }
}
