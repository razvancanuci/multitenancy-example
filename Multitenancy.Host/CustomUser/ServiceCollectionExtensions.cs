using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Multitenancy.Database.User;

namespace Multitenancy.CustomUser;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomUserProperties(this IServiceCollection services)
    {
        var claimsPrincipalDescriptor =
            new ServiceDescriptor(
                typeof(IUserClaimsPrincipalFactory<User>),
                typeof(OrganizationClaimsPrincipalFactory),
                ServiceLifetime.Scoped);
        services.Replace(claimsPrincipalDescriptor);
        
        return services;
    }
}