using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Domain.Common;

namespace Japanese.Core.RepositoryBase;

public interface IAsyncRepository<TModel> where TModel : EntityBase
{
    Task<List<TModel>> GetListAsync(int count);
    Task<TModel?> GetAsync(Primitive key);
    Task AddAsync(TModel entity);
    Task UpdateAsync(TModel entity);
    Task BatchDeleteAsync(Primitive key);
    Task ForceDeleteAsync(Primitive key);
}