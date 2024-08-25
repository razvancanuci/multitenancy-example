using MediatR;
using Multitenancy.Application.Requests;
using Multitenancy.Database.Tenant.Repositories.Interfaces;

namespace Multitenancy.Application.Handlers;

public class AddDataHandler : IRequestHandler<AddDataRequest>
{
    private readonly IDataRepository _dataRepository;
    public AddDataHandler(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }
    public async Task Handle(AddDataRequest request, CancellationToken cancellationToken)
    {
       await _dataRepository.AddData(request.ToData());
    }
}