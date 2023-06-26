using Japanese.Core.CommonModels;
using Japanese.Core.DynamoDB;

namespace Japanese.Core.RepositoryBase;

public interface IAsyncRepository<TModel> : IDynamoDBExecution<TModel> where TModel : EntityBase
{
    
}