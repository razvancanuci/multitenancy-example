using Microsoft.Extensions.DependencyInjection;
using Multitenancy.Database.Tenant.Repositories.Implementations;
using Multitenancy.Database.Tenant.Repositories.Interfaces;

namespace Multitenancy.Database.Tenant;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMultitenancyDatabase(this IServiceCollection services)
    {
        services.AddScoped<Tenant>();
        services.AddDbContext<TenantDbContext>();

        services.AddScoped<IDataRepository, DataRepository>();
        return services;
    }
}