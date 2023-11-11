namespace Japanese.Core.CommonModels;

public class Pagination
{
    public string? PaginationToken { get; set; } = default;

    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? FilterBy { get; set; }
    public string? FilterValue { get; set; }
    public string? Keyword { get; set; }
}