using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.AWS;

public class AwsService : IAwsService
{
    private readonly AmazonConfiguration _amazonConfiguration;
    private bool disposedValue;

    private PollyHelper? _pollyHelper;
    private S3Helper? _s3Helper;

    public AwsService(AmazonConfiguration amazonConfiguration)
    {
        _amazonConfiguration = amazonConfiguration;
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