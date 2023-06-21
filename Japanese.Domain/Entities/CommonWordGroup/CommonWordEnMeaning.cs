using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Japanese.Domain.Common;

namespace Japanese.Domain.Entities.CommonWordGroup;

[Table("CommonWords.EnMeanings")]
public class CommonWordEnMeaning : EntityBase
{
    [Key]
    public string? WordId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string? Meaning { get; set; }
}
