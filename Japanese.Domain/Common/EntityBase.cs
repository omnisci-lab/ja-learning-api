using System.ComponentModel.DataAnnotations;

namespace Japanese.Domain.Common;

public abstract class EntityBase
{
    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool IsDeleted { get; set; }
}


public abstract class EntityBase<T_ID> : EntityBase
{
    [Key]
    [Required]
    public T_ID? Id { get; set; }
}
