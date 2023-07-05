using System.ComponentModel.DataAnnotations;
using WebCore.Attributes;

namespace Japanese.Web.Admin.Models;

public class SentenceOutputMetadata
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

