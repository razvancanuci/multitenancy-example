using Microsoft.EntityFrameworkCore;
using Multitenancy.Database.User;

namespace Multitenancy;

public static class MigrationExtensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        
        using var context = serviceScope.ServiceProvider.GetRequiredService<UserDbContext>();
        
        context.Database.Migrate();
        
        return app;
    }

}