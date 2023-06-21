using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Japanese.Domain.Entities;

public class Katakana : EntityBase<string>
{
    [Required]
    public string? Characters { get; set; }

    [Required]
    public string? Romaji { get; set; }

    public string? IPA { get; set; }
    public string? Unicode { get; set; }
    public string? Manyogana { get; set; }
    public string? Row { get; set; }
    public string? Col { get; set; }

    public bool IsDakuon { get; set; }
    public bool IsSmallTsu { get; set; }
    public bool IsLongvowels { get; set; }
    public string? Notes { get; set; }
}