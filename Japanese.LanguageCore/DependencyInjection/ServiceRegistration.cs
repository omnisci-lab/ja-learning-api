using Amazon.AspNetCore.Identity.Cognito;
using Amazon.DynamoDBv2;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon.S3;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.AWS.Cognito;
using Japanese.LanguageCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Japanese.LanguageCore.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection awsSection = configuration.GetSection("AWS");
        string? accessKeyId = awsSection.GetSection("AwsAccessKeyId").Value;
        string? secretAccessKey = awsSection.GetSection("AwsSecretAccessKey").Value;

        services.AddSingleton(s => new BasicAWSCredentials(accessKeyId, secretAccessKey));
        services.AddSingleton(s => new AmazonServiceConfig
        {
            DynamoDBConfig = new AmazonDynamoDBConfig { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 },
            PollyConfig = new AmazonPollyConfig { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 },
            S3Config = new AmazonS3Config { RegionEndpoint = Amazon.RegionEndpoint.APNortheast3 }
        });

        services.AddScoped<IAwsService, AwsService>();

        return services;
    }

    public static IServiceCollection AddAmazonCognito(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCognitoIdentity();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Authority = configuration["AWSCognito:Authority"];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false
            };
        });

        services.AddTransient<CognitoSignInManager<CognitoUser>>();
        services.AddTransient<CognitoUserManager<CognitoUser>>();

        services.AddScoped<CognitoHelper>();

        services.AddScoped<IIdentityManager, IdentityManager>();

        return services;
    }
}