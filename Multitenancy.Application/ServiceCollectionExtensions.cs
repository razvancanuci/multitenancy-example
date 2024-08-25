using Microsoft.Extensions.DependencyInjection;
using Multitenancy.Application.Handlers;

namespace Multitenancy.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddOrganizationHandler).Assembly));
        return services;
    }
}