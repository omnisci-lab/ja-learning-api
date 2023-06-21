using System.ComponentModel.DataAnnotations;

namespace Japanese.Application.Features.Hiragana.Queries;

public class HiraganaOutput
{
    [Required]
    public string? Characters { get; set; }
}
