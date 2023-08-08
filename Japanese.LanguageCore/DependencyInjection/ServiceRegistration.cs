using Amazon.CognitoIdentityProvider;
using Amazon.DynamoDBv2;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon.S3;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.SynthesizeSpeech;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;

namespace Japanese.LanguageCore.DependencyInjection;

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

        services.AddScoped<PollyHelper>();
        services.AddScoped<S3Helper>();

        //services.AddSingleton<IAmazonCognitoIdentityProvider>(s => new AmazonCognitoIdentityProviderConfig { } );
        //services.AddSingleton<CognitoUserPool>(s => new CognitoUserPool("", ""));

        //// Adds Amazon Cognito as Identity Provider
        //services.AddCognitoIdentity();

        return services;
    }
}