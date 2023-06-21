using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities;

[Table("KanjiLevels")]
public class KanjiLevel : EntityBase<string>
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
}