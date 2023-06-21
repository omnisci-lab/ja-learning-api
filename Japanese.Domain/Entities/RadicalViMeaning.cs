using Japanese.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Japanese.Domain.Entities;

public class RadicalViMeaning : EntityBase
{
    [Key]
    [Required]
    public string? RadicalId { get; set; }

    public string? SinoVietnamese { get; set; }

    public string? Vietnamese { get; set; }
}
