using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRadicalRepository : IDynamoDBService<KanjiRadicalModel>
{
}