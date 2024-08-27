using Multitenancy.Database.Tenant;

namespace Multitenancy.Middlewares;

public class MultitenancyMiddleware : IMiddleware
{
    private readonly Tenant _tenant;
    private readonly IConfiguration _configuration;
    public MultitenancyMiddleware(Tenant tenant, IConfiguration configuration)
    {
        _tenant = tenant;
        _configuration = configuration;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Path.HasValue || !context.Request.Path.Value.Contains("/tenant"))
        {
            await next(context);
            return;
        }

        var organizationClaim = context.User.Claims.FirstOrDefault(c => c.Type == "organization");
        if (organizationClaim is null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var connectionStringTemplate = _configuration.GetConnectionString("TenantDatabaseTemplate");
        var connectionString = $"Database={organizationClaim.Value};{connectionStringTemplate}";
        _tenant.ConnectionString = connectionString;
        await next(context);
    }
}