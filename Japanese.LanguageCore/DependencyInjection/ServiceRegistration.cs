using Amazon.AspNetCore.Identity.Cognito;
using Amazon.CognitoIdentityProvider;
using Amazon.DynamoDBv2;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon.S3;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.AWS.Cognito;
using Japanese.LanguageCore.SynthesizeSpeech;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        return services;
    }
}