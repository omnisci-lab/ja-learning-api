using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface ISentenceRepository : IDynamoDBService<SentenceModel>
{
    Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination);
    Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination);
}