using Japanese.Core.CommonModels;

namespace Japanese.Core.RepositoryBase;

public interface IAsyncRepository<TModel> where TModel : EntityBase
{
    Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination);
    Task<List<TModel>> GetListAsync(int limit);
    Task<TModel?> GetAsync(object? key);
    Task SaveAsync(TModel item);
    Task DeleteAsync(object? key);
    Task<int> CountAsync();
}