using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class Kanjidic2ExtensionRepository : AppRepository<Kanjidic2ExtensionModel>, IKanjidic2ExtensionRepository
{
    public Kanjidic2ExtensionRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {

    }

    public async Task<List<Kanjidic2ExtensionModel>> GetItemsByLiteralsAsync(List<string> literals)
    {
        return await Helper.GetItemsAsync<Kanjidic2ExtensionModel>(literals.Select(s => (object)s).ToList());
    }
}