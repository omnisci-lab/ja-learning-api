namespace Japanese.Domain.Common;

public class Pagination
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItemCount { get; set; }
    public string? OrderBy { get; set; }
    public OrderOptions OrderOptions { get; set; }
    public string? SearchBy { get; set; }
    public string? Keyword { get; set; }

    public Pagination<TOutput> WithData<TOutput>(IReadOnlyList<TOutput> items, int totalItemCount)
    {
        return new Pagination<TOutput>
        {
            Page = Page,
            PageSize = PageSize,
            TotalItemCount = totalItemCount,
            OrderBy = OrderBy,
            OrderOptions = OrderOptions,
            SearchBy = SearchBy,
            Keyword = Keyword,
            Items = items
        };
    }
}

public class Pagination<TModel> : Pagination
{
    public IReadOnlyList<TModel>? Items { get; set; }
}