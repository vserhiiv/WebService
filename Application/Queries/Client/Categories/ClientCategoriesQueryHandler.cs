using Application.Interfaces.Persistence;
using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.Categories;

public class ClientCategoriesQueryHandler :
    IRequestHandler<ClientCategoriesQuery, PaginatedListModel<ClientCategoriesModel>>
{
    private readonly IClientRepository _clientRepository;

    public ClientCategoriesQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<PaginatedListModel<ClientCategoriesModel>> Handle(
        ClientCategoriesQuery request,
        CancellationToken ct
    )
    {
        return await _clientRepository.GetClientCategoriesAsync(request.Id, request.PageNumber, request.PageSize);
    }
}
