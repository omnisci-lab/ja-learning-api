using Amazon.DynamoDBv2;
using Japanese.Core.CommonModels;
using Japanese.Core.DynamoDB;

namespace Japanese.Core.RepositoryBase;

public class AsyncRepository<TModel> : DynamoDBExecution<TModel>, IAsyncRepository<TModel> 
    where TModel : EntityBase
{
    private readonly DynamoDBExecution<TModel> _dynamoDBExecution;

    public AsyncRepository(AmazonDynamoDBClient client)
        : base(client)
    {
        _dynamoDBExecution = new DynamoDBExecution<TModel>(client);
    }
}