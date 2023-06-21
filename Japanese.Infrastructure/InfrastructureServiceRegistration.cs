using Japanese.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Japanese.Infrastructure.Repositories;
using Japanese.Application.Contracts.Presistence;

namespace Japanese.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JapaneseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MainConnection")));

        services.AddScoped<IJapaneseRepository, JapaneseRepository>();

        return services;
    }
}
