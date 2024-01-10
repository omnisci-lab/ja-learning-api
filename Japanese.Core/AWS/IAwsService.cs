using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.AWS;

public interface IAwsService : IDisposable
{
    DynamoDBHelper CreateDynamoDBHelper();
    PollyHelper CreatePollyHelper();
    S3Helper CreateS3Helper();
}