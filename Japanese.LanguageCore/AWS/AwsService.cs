using Japanese.LanguageCore.AWS.Helpers;

namespace Japanese.LanguageCore.AWS;

public class AwsService : IAwsService
{
    private readonly AmazonConfiguration _amazonConfiguration;
    private bool disposedValue;

    private DynamoDBHelper? _dynamoDBHelper;
    private PollyHelper? _pollyHelper;
    private S3Helper? _s3Helper;

    public AwsService(AmazonConfiguration amazonConfiguration)
    {
        _amazonConfiguration = amazonConfiguration;
    }

    public DynamoDBHelper CreateDynamoDBHelper()
    {
        if(_dynamoDBHelper is null)
            _dynamoDBHelper = new DynamoDBHelper(_amazonConfiguration.BasicAwsCredentials, _amazonConfiguration.DynamoDBConfig);

        return _dynamoDBHelper;
    }

    public PollyHelper CreatePollyHelper()
    {
        if(_pollyHelper is null)
            _pollyHelper = new PollyHelper(_amazonConfiguration.BasicAwsCredentials, _amazonConfiguration.PollyConfig);

        return _pollyHelper;
    }

    public S3Helper CreateS3Helper()
    {
        if(_s3Helper is null)
            _s3Helper = new S3Helper(_amazonConfiguration.BasicAwsCredentials, _amazonConfiguration.S3Config);

        return _s3Helper;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (_dynamoDBHelper is not null)
                    _dynamoDBHelper.Dispose();

                if (_pollyHelper is not null)
                    _pollyHelper.Dispose();

                if (_s3Helper is not null)
                    _s3Helper.Dispose();
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