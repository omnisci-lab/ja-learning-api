using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Japanese.Repositories.Interfaces;
using Amazon.Runtime;
using Japanese.Repositories.Implements;
using Amazon.DynamoDBv2;

namespace Japanese.Repositories;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection awsDynamoDBSection = configuration.GetSection("AWS_DynamoDB");
        string? accessKeyId = awsDynamoDBSection.GetSection("AwsAccessKeyId").Value;
        string? secretAccessKey = awsDynamoDBSection.GetSection("AwsSecretAccessKey").Value;

        services.AddScoped(s => new BasicAWSCredentials(accessKeyId, secretAccessKey));
        services.AddScoped(s => new AmazonDynamoDBConfig { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 });
        services.AddScoped<IJapaneseRepository, JapaneseRepository>();

        return services;
    }
}
