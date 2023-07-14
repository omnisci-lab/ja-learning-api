namespace Japanese.Core.CommonModels;

public class PagedResult<TModel> : Pagination
{
    public List<TModel> Items { get; set; } = new List<TModel>();
}