using Amazon.DynamoDBv2;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon.S3;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.SynthesizeSpeech;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Japanese.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection awsSection = configuration.GetSection("AWS");
        string? accessKeyId = awsSection.GetSection("AwsAccessKeyId").Value;
        string? secretAccessKey = awsSection.GetSection("AwsSecretAccessKey").Value;

        services.AddScoped(s => new BasicAWSCredentials(accessKeyId, secretAccessKey));
        services.AddScoped(s => new AmazonPollyConfig { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 });
        services.AddScoped(s => new AmazonDynamoDBConfig { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 });
        services.AddScoped(s => new AmazonS3Config { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 });

        services.AddScoped<PollyService>();
        services.AddScoped<SimpleStorageService>();

        return services;
    }
}