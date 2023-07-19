using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase;

namespace Japanese.LanguageCore.AWS.DynamoDB;

public interface IDynamoDBService<TModel> : IAsyncRepository<TModel> where TModel : EntityBase
{

}