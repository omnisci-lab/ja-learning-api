using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.AWS;

public interface IAwsService : IDisposable
{
    PollyHelper CreatePollyHelper();
    S3Helper CreateS3Helper();
}