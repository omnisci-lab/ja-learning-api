using Amazon.Runtime;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.AWS.Polly;
using Japanese.LanguageCore.AWS.S3;

namespace Japanese.LanguageCore.AWS;

public class AwsService : IAwsService
{
    private readonly BasicAWSCredentials _basicAWSCredentials;
    private readonly AmazonServiceConfig _awsServiceConfig;
    private bool disposedValue;

    private IDynamoDBHelper? _dynamoDBHelper;
    private IPollyHelper? _pollyHelper;
    private IS3Helper? _s3Helper;

    public AwsService(BasicAWSCredentials basicAWSCredentials, AmazonServiceConfig awsServiceConfig)
    {
        _basicAWSCredentials = basicAWSCredentials;
        _awsServiceConfig = awsServiceConfig;
    }

    public IDynamoDBHelper CreateDynamoDBHelper()
    {
        if (_awsServiceConfig.DynamoDBConfig is null)
            throw new NullReferenceException();

        if(_dynamoDBHelper is null)
            _dynamoDBHelper = new DynamoDBHelper(_basicAWSCredentials, _awsServiceConfig.DynamoDBConfig);

        return _dynamoDBHelper;
    }

    public IPollyHelper CreatePollyHelper()
    {
        if (_awsServiceConfig.PollyConfig is null)
            throw new NullReferenceException();

        if(_pollyHelper is null)
            _pollyHelper = new PollyHelper(_basicAWSCredentials, _awsServiceConfig.PollyConfig);

        return _pollyHelper;
    }

    public IS3Helper CreateS3Helper()
    {
        if(_awsServiceConfig.S3Config is null)
            throw new NullReferenceException();

        if(_s3Helper is null)
            _s3Helper = new S3Helper(_basicAWSCredentials, _awsServiceConfig.S3Config);

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