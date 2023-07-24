using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRepository : IDynamoDBService<KanjiModel>
{
    Task<PagedResult<KanjiModel>> SearchByStrokeCountAsync(Pagination pagination);
    Task<PagedResult<KanjiModel>> SearchByJlptAsync(Pagination pagination);
    Task<PagedResult<KanjiModel>> SearchByOnReadingAsync(Pagination pagination);
    Task<PagedResult<KanjiModel>> SearchByKunReadingAsync(Pagination pagination);
    Task<PagedResult<KanjiModel>> SearchByNameReadingAsync(Pagination pagination);
}
