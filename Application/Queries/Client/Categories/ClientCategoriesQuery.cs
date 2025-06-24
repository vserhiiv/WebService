using Application.Models;
using Application.Models.Client;
using MediatR;

namespace Application.Queries.Client.Categories;

public record ClientCategoriesQuery(
    int PageNumber,
    int PageSize,
    int Id
) : IRequest<PaginatedListModel<ClientCategoriesModel>>;
