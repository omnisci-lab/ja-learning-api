using Amazon;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon.S3;

namespace Japanese.Core.AWS;

public class AmazonConfiguration
{
    public string? AwsAccessKeyId { get; set; }
    public string? AwsSecretAccessKey { get; set; }

    public string? DynamoDBRegionEndpoint { get; set; }
    public string? PollyRegionEndpoint { get; set; }
    public string? S3RegionEndpoint { get; set; }

    private BasicAWSCredentials? _basicAWSCredentials;

    public BasicAWSCredentials BasicAwsCredentials
    {
        get
        {
            if (_basicAWSCredentials is not null)
                return _basicAWSCredentials;

            _basicAWSCredentials = new BasicAWSCredentials(AwsAccessKeyId, AwsSecretAccessKey);

            return _basicAWSCredentials;
        }
    }

    private AmazonPollyConfig? _pollyConfig;

    public AmazonPollyConfig PollyConfig
    {
        get
        {
            if (_pollyConfig is not null)
                return _pollyConfig;

            _pollyConfig = new AmazonPollyConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(PollyRegionEndpoint) };

            return _pollyConfig;
        }
    }

    private AmazonS3Config? _s3Config;

    public AmazonS3Config S3Config
    {
        get
        {
            if (_s3Config is not null)
                return _s3Config;

            _s3Config = new AmazonS3Config { RegionEndpoint = RegionEndpoint.GetBySystemName(S3RegionEndpoint) };

            return _s3Config;
        }
    }
}
