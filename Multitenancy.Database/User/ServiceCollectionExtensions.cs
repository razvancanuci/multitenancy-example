using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Multitenancy.Database.User;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddIdentityDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddIdentityCore<User>()
            .AddEntityFrameworkStores<UserDbContext>();

        serviceCollection.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("UserDatabase"));
        });
        return serviceCollection;
    }
}