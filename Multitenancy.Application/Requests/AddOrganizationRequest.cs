using MediatR;

namespace Multitenancy.Application.Requests;

public record AddOrganizationRequest(string Organization) : IRequest;