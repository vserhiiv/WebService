using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.RecentPurchases;

public record RecentPurchasesQuery(
    int PageNumber,
    int PageSize,
    int Days
) : IRequest<PaginatedListModel<RecentPurchaseModel>>;
