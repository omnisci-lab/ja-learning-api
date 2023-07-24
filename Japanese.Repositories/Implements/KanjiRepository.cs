using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRepository : DynamoDBService<KanjiModel>, IKanjiRepository
{
    private readonly AmazonDynamoDBClient _client;

    internal KanjiRepository(AmazonDynamoDBClient client) 
        : base(client)
    {
        _client = client;
    }

    public async Task<PagedResult<KanjiModel>> SearchByJlptAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.Keyword, out jlptLevel))
            throw new InvalidCastException();

        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("jlpt", ScanOperator.IsNotNull);
        scanFilter.AddCondition("jlpt", ScanOperator.Equal, jlptLevel);

        return await GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByKunReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("kun_readings", ScanOperator.Contains, pagination.Keyword);

        return await GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByNameReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("name_readings", ScanOperator.Contains, pagination.Keyword);

        return await GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByOnReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("on_readings", ScanOperator.Contains, pagination.Keyword);

        return await GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByStrokeCountAsync(Pagination pagination)
    {
        int strokeCount = 0;
        if (!int.TryParse(pagination.Keyword, out strokeCount))
            throw new InvalidCastException();

        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("stroke_count", ScanOperator.Equal, strokeCount);

        return await GetPagedAsync(pagination, scanFilter);
    }
}
