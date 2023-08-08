using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.AWS.DynamoDB;

namespace Japanese.LanguageCore.Repositories;

public class MasterRepository : IMasterRepository
{
    private readonly IAwsService _awsService;
    private bool disposedValue;

    public IDynamoDBHelper DynamoDBHelper => _awsService.CreateDynamoDBHelper();

    public MasterRepository(IAwsService awsService)
    {
        _awsService = awsService;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _awsService.Dispose();  
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}