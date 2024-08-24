using Microsoft.Extensions.DependencyInjection;

namespace Multitenancy.Database.Tenant;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMultitenancyDatabase(this IServiceCollection services)
    {
        services.AddScoped<Tenant>();
        services.AddDbContext<TenantDbContext>();
        return services;
    }
}