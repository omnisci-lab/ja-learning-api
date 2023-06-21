using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities.CommonWordGroup;

[Table("CommonWords.ViMeanings")]
public class CommonWordViMeaning : EntityBase
{
    [Key]
    public string? WordId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string? Meaning { get; set; }
}
