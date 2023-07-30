namespace Japanese.Core.CommonModels;

public class Pagination
{
    public string? PaginationToken { get; set; }

    public int PageSize { get; set; }
    public string? SearchBy { get; set; }
    public string? Keyword { get; set; }
}