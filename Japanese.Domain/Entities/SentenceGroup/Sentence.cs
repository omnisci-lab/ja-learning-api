using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Japanese.Domain.Entities.SentenceGroup;

[Table("Sentences")]
public class Sentence : EntityBase<string>
{
    [Required]
    [Column(TypeName = "nvarchar(300)")]
    [MaxLength(300)]
    public string? Text { get; set; }
}
