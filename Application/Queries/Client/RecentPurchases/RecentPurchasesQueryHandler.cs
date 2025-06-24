using Application.Interfaces.Persistence;
using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.RecentPurchases;

public class RecentPurchasesQueryHandler :
    IRequestHandler<RecentPurchasesQuery, PaginatedListModel<RecentPurchaseModel>>
{
    private readonly IClientRepository _clientRepository;

    public RecentPurchasesQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<PaginatedListModel<RecentPurchaseModel>> Handle(
        RecentPurchasesQuery request,
        CancellationToken ct
    )
    {
        return await _clientRepository.GetRecentPurchasesAsync(request.Days, request.PageNumber, request.PageSize);
    }
}
