using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.DynamoDB;
using Japanese.Domain.Common;

namespace Japanese.Core.RepositoryBase;

public class AsyncRepository<TModel> : IAsyncRepository<TModel> where TModel : EntityBase
{
    private readonly DynamoDBExecution<TModel> _dynamoDBExecution;

    public AsyncRepository(AmazonDynamoDBClient client, string tableName)
    {
        _dynamoDBExecution = new DynamoDBExecution<TModel>(client, tableName);
    }

    public async Task AddAsync(TModel entity)
    {
        await _dynamoDBExecution.CreateAsync(entity);
    }

    public Task BatchDeleteAsync(Primitive key)
    {
        throw new NotImplementedException();
    }

    public async Task ForceDeleteAsync(Primitive key)
    {
        await _dynamoDBExecution.DeleteAsync(key);
    }

    public async Task<TModel?> GetAsync(Primitive key)
    {
        return await _dynamoDBExecution.GetAsync(key);
    }

    public async Task<List<TModel>> GetListAsync(int count)
    {
        return await _dynamoDBExecution.GetListAsync();
    }

    public async Task UpdateAsync(TModel entity)
    {
        await _dynamoDBExecution.UpdateAsync(entity);
    }
}
