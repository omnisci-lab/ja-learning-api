using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class Kanjidic2Repository : AppRepository<Kanjidic2Model>, IKanjidic2Repository
{
    public Kanjidic2Repository(IDynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }

    public async Task<List<Kanjidic2Model>> GetItemsByLiteralsAsync(List<string> literals)
    {
        return await Helper.GetItemsAsync<Kanjidic2Model>(literals.Select(s => (object)s).ToList());
    }
}