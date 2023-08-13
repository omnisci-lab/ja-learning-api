
using Japanese.LanguageCore.AWS.Helpers;

namespace Japanese.LanguageCore.AWS;

public interface IAwsService : IDisposable
{
    DynamoDBHelper CreateDynamoDBHelper();
    PollyHelper CreatePollyHelper();
    S3Helper CreateS3Helper();
}