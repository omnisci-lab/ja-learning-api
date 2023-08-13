using Amazon;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using IdentityCore.Cognito;
using Japanese.LanguageCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityCore.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddAmazonCognito(this IServiceCollection services, IConfiguration configuration)
    {
        CognitoConfiguration cognitoConfiguration = configuration.GetSection("AmazonCognito")
            .Get<CognitoConfiguration>();

        AmazonCognitoIdentityProviderConfig cognitoIdentityProviderConfig = new AmazonCognitoIdentityProviderConfig
        {
            RegionEndpoint = RegionEndpoint.GetBySystemName(cognitoConfiguration.Region)
        };

        AmazonCognitoIdentityProviderClient cognitoIdentityProvider = new AmazonCognitoIdentityProviderClient(cognitoIdentityProviderConfig);
        CognitoUserPool cognitoUserPool = new CognitoUserPool(cognitoConfiguration.UserPoolId, cognitoConfiguration.UserPoolClientId, cognitoIdentityProvider, clientSecret: cognitoConfiguration.UserPoolClientSecret);

        services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoIdentityProvider);
        services.AddSingleton(cognitoUserPool);

        services.AddCognitoIdentity();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            //options.Authority = configuration["AmazonCognito"];
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
