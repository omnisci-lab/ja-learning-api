using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class KanjiRepository : AppRepository<KanjiModel>, IKanjiRepository
{
    internal KanjiRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<PagedResult<KanjiModel>> SearchByEnMeaningAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("en_meanings", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByJlptAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.Keyword, out jlptLevel))
            throw new InvalidCastException();

        ScanFilter scanFilter = new ScanFilter();

        scanFilter.AddCondition("jlpt", ScanOperator.Equal, jlptLevel);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByKunReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("kun_readings", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByNameReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("name_readings", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByOnReadingAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("on_readings", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchBySinoVietnameseAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("sino_vietnamese", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByStrokeCountAsync(Pagination pagination)
    {
        int strokeCount = 0;
        if (!int.TryParse(pagination.Keyword, out strokeCount))
            throw new InvalidCastException();

        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("stroke_count", ScanOperator.Equal, strokeCount);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<KanjiModel>> SearchByViMeaningAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("vi_meanings", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }
}
