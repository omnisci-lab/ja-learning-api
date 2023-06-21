using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities.CommonWordGroup;

[Table("CommonWords")]
public class CommonWord : EntityBase<string>
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Word { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Kana { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Romaji { get; set; }
}
