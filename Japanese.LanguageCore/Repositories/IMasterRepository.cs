using Japanese.LanguageCore.AWS.DynamoDB;

namespace Japanese.LanguageCore.Repositories;

public interface IMasterRepository : IDisposable
{
    IDynamoDBHelper DynamoDBHelper { get; }
}