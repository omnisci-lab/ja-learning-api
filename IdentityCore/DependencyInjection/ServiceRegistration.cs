using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
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
