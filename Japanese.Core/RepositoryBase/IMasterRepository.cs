using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.RepositoryBase;

public interface IMasterRepository : IDisposable
{
    DynamoDBHelper DynamoDBHelper { get; }
}