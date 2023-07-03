using Japanese.Web.Admin.Common.DynamicTable;
using System.ComponentModel.DataAnnotations;

namespace Japanese.Web.Admin.Models;

public class SentenceOutputMetadata
{
    [Display(Name = "Sentence Id")]
    [DynamicTableColumn]
    public string? SentenceId { get; set; }

    [Display(Name = "Text")]
    [DynamicTableColumn]
    public string? Text { get; set; }

    public string? Structure { get; set; }

    [Display(Name = "JLPT")]
    [DynamicTableColumn]
    public int Jlpt { get; set; }

    public string? EnMeanings { get; set; }

    [Display(Name = "Vi Meanings")]
    [DynamicTableColumn]
    public string? ViMeanings { get; set; }

    public string? References { get; set; }
}

