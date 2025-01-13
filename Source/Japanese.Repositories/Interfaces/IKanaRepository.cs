using Japanese.Models;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IKanaRepository : IAppRepository<KanaModel>
{
    Task<List<KanaModel>> GetListAsync(string kanaType);
    Task<KanaModel> GetByCharacterAsync(string character);
    Task UpdateAsync(KanaModel model);
}