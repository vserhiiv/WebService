using Application.Interfaces.Persistence;
using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.BirthdayClients;

public class BirthdayClientsQueryHandler :
    IRequestHandler<BirthdayClientsQuery, PaginatedListModel<ClientBithdayModel>>
{
    private readonly IClientRepository _clientRepository;

    public BirthdayClientsQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<PaginatedListModel<ClientBithdayModel>> Handle(
        BirthdayClientsQuery request,
        CancellationToken ct
    )
    {
        return await _clientRepository.GetBirthdayClientsAsync(request.Date, request.PageNumber, request.PageSize);
    }
}
