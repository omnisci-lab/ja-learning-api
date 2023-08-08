using Amazon.DynamoDBv2;
using Amazon.Polly;
using Amazon.S3;

namespace Japanese.LanguageCore.AWS;

public class AmazonServiceConfig
{
    public AmazonDynamoDBConfig? DynamoDBConfig { get; set; }
    public AmazonPollyConfig? PollyConfig { get; set; }
    public AmazonS3Config? S3Config { get; set; }
}
