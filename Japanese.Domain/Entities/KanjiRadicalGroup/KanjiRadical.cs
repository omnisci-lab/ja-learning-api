using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities.KanjiRadicalGroup;

[Table("KanjiRadicals")]
public class KanjiRadical : EntityBase<string>
{
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    [MaxLength(20)]
    public string? Radical { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    [MaxLength(20)]
    public string? Reading { get; set; }

    [Required]
    public int StrokeCount { get; set; }

    public string? Notes { get; set; }
}