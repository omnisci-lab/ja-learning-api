using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanaRepository : IAppRepository<KanaModel>
{
    Task<List<KanaModel>> GetListAsync(string kanaType);
    Task<KanaModel> GetByCharacterAsync(string character);
}