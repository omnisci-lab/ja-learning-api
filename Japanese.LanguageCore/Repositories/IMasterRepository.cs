using Japanese.LanguageCore.AWS.Helpers;

namespace Japanese.LanguageCore.Repositories;

public interface IMasterRepository : IDisposable
{
    DynamoDBHelper DynamoDBHelper { get; }
}