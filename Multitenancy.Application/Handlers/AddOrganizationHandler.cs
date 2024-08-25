using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Multitenancy.Application.Requests;
using Multitenancy.Database.Tenant;

namespace Multitenancy.Application.Handlers;

public class AddOrganizationHandler : IRequestHandler<AddOrganizationRequest>
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;
    public AddOrganizationHandler(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }
    public Task Handle(AddOrganizationRequest request, CancellationToken cancellationToken)
    {
        var tenant = _serviceProvider.GetRequiredService<Tenant>();
        var connectionStringTemplate = _configuration.GetConnectionString("TenantDatabaseTemplate");
        var connectionString = $"Database={request.Organization};{connectionStringTemplate}";
        tenant.ConnectionString = connectionString;
        
        var tenantDbContext = _serviceProvider.GetRequiredService<TenantDbContext>();
        tenantDbContext.Database.Migrate();
        return Task.CompletedTask;
    }
}