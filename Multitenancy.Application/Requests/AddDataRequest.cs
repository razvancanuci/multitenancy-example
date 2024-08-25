using MediatR;

namespace Multitenancy.Application.Requests;

public record AddDataRequest(string Attribute, string Field): IRequest;