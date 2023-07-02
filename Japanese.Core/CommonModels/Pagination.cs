namespace Japanese.Core.CommonModels;

public class Pagination
{
    public string? PaginationToken { get; set; }
    public int PageSize { get; set; }
    //public int TotalItemCount { get; set; }
    //public string? OrderBy { get; set; }
    //public OrderOptions OrderOptions { get; set; }
    //public string? SearchBy { get; set; }
    //public string? Keyword { get; set; }
}

public class Pagination<TModel> : Pagination
{
    public List<TModel>? Items { get; set; }

    public List<T> ToList<T>()
    {
        return null;
    }
}