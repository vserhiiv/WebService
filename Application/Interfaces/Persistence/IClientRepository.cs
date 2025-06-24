using Application.Models;
using Application.Models.Client;

namespace Application.Interfaces.Persistence;

public interface IClientRepository
{
    Task<PaginatedListModel<ClientBithdayModel>> GetBirthdayClientsAsync(DateOnly date, int PageNumber, int PageSize);
    Task<PaginatedListModel<RecentPurchaseModel>> GetRecentPurchasesAsync(int days, int PageNumber, int PageSize);
    Task<PaginatedListModel<ClientCategoriesModel>> GetClientCategoriesAsync(int clientId, int PageNumber, int PageSize);
}
