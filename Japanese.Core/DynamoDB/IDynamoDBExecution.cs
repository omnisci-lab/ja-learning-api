using Japanese.Core.CommonModels;

namespace Japanese.Core.DynamoDB;

public interface IDynamoDBExecution<TModel> where TModel : EntityBase
{
    Task<Pagination<TModel>> GetPagedAsync(Pagination pagination);
    Task<List<TModel>> GetListAsync(int limit);
    Task<TModel?> GetAsync(object? key);
    Task SaveItemAsync(TModel item);
    Task DeleteItemAsync(object? key);
    Task<int> CountItemsAsync();
}