using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.AWS.Polly;
using Japanese.LanguageCore.AWS.S3;

namespace Japanese.LanguageCore.AWS;

public interface IAwsService : IDisposable
{
    IDynamoDBHelper CreateDynamoDBHelper();
    IPollyHelper CreatePollyHelper();
    IS3Helper CreateS3Helper();
}