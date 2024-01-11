using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.RepositoryBase.DynamoDB;

public interface IMasterRepository : IDisposable
{
    DynamoDBHelper DynamoDBHelper { get; }
}