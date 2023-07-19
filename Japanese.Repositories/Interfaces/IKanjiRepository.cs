using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRepository : IDynamoDBService<KanjiModel>
{
    Task<List<KanjiModel>> GetListByJlptAsync(int? jlpt);
}
