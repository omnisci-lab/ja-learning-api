using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities.KanjiGroup;

[Table("Kanji")]
public class Kanji : EntityBase<int>
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public int Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Character { get; set; }

    [Required]
    public int StrokeCount { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Onyomi_Ja { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Onyomi { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Kunyomi_Ja { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Kunyomi { get; set; }
}