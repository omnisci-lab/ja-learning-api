using Japanese.Core.CommonModels;

namespace Japanese.Core.RepositoryBase;

public interface IRepository<TModel> where TModel : EntityBase
{
    PagedResult<TModel> GetPaged(Pagination pagination);
    List<TModel> GetList(int limit);
    TModel? Get(object? key);
    Task Save(TModel item);
    Task Delete(object? key);
    int Count();
}