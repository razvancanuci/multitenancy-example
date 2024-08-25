using MediatR;
using Multitenancy.Application.Requests;
using Multitenancy.Database.Tenant;
using Multitenancy.Database.Tenant.Repositories.Interfaces;

namespace Multitenancy.Endpoints;

public static class TenantEndpoints
{
    public static IEndpointRouteBuilder MapTenantEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var tenantGroup = endpoints.MapGroup("/tenant");
        
        tenantGroup.MapGet("/data", async (IDataRepository repository) =>
        {
            return Results.Ok(await repository.GetData());
        });

        tenantGroup.MapPost("/data", async (AddDataRequest request, ISender sender) =>
        {
            await sender.Send(request);
            return Results.Created();
        });

        return endpoints;
    }
}