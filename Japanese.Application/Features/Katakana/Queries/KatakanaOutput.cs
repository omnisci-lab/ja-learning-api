using System.ComponentModel.DataAnnotations;

namespace Japanese.Application.Features.Katakana.Queries;

public class KatakanaOutput
{
    [Required]
    public string? Id { get; set; }

    [Required]
    public string? Characters { get; set; }
}
