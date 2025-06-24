using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.BirthdayClients;

public record BirthdayClientsQuery(
    int PageNumber,
    int PageSize,
    DateOnly Date
) : IRequest<PaginatedListModel<ClientBithdayModel>>;
