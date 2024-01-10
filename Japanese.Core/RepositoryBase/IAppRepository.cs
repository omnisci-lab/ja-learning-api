using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Japanese.Core.RepositoryBase;
using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.RepositoryBase;

public interface IAppRepository<TModel> : IAsyncRepository<TModel> where TModel : class
{
    DynamoDBHelper Helper { get; }
    IAmazonDynamoDB DynamoClient { get; }
    IDynamoDBContext Context { get; }
}