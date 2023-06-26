using Japanese.Core.CommonModels;

namespace Japanese.Core.DynamoDB;

public interface IDynamoDBExecution<TModel> where TModel : EntityBase
{
    Task<List<TModel>> GetPagedItems(int pageSize);
    Task<List<TModel>> GetListAsync(int limit);
    Task<TModel?> GetAsync(object? key);
    Task SaveItem(TModel item);
    Task DeleteItem(object? key);
    Task<int> CountItems();
}
