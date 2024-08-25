using MediatR;
using Multitenancy.Application.Requests;

namespace Multitenancy.Endpoints;

public static class OrganizationEndpoints
{
    public static IEndpointRouteBuilder MapOrganizationEndpoints(this IEndpointRouteBuilder app)
    {
        var organizationGroup = app.MapGroup("/organizations");
        organizationGroup.MapPost("/", async (AddOrganizationRequest organization, ISender sender) =>
        {
            await sender.Send(organization);
            return Results.Created();
        });
        return app;
    }
}