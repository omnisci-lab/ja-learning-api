using Japanese.Domain.Common;

namespace Japanese.Domain.Entities;

public class KanjiType : EntityBase<string>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}