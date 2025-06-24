using Application.Interfaces.Persistence;
using Application.Models;
using Application.Models.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly WebServiceDbContext _context;

    public ClientRepository(WebServiceDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedListModel<ClientBithdayModel>> GetBirthdayClientsAsync(
        DateOnly date,
        int PageNumber,
        int PageSize)
    {
        var clients = await _context.Clients
            .AsNoTracking()
            .Where(c => c.BirthDate.Day == date.Day && c.BirthDate.Month == date.Month)
            .Select(c => new ClientBithdayModel { Id = c.Id, FullName = c.FirstName + " " + c.SecondName + " " + c.LastName })
            .Skip((PageNumber == 0 ? 1 : PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        int total = clients.Count;

        return new PaginatedListModel<ClientBithdayModel>(
            PageSize,
            PageNumber,
            total,
            clients
            );
    }

    public async Task<PaginatedListModel<RecentPurchaseModel>> GetRecentPurchasesAsync(
        int days,
        int PageNumber,
        int PageSize)
    {
        var dateLimit = DateTime.Now.AddDays(-days);

        var clients = await _context.Purchases
            .AsNoTracking()
            .Where(p => p.Date >= dateLimit.ToUniversalTime())
            .GroupBy(p => p.Client)
            .Select(g => new RecentPurchaseModel
            {
                Id = g.Key.Id,
                FullName = g.Key.FirstName,
                LastPurchaseDate = g.Max(p => p.Date)
            })
            .Skip((PageNumber == 0 ? 1 : PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        int total = clients.Count;

        return new PaginatedListModel<RecentPurchaseModel>(
            PageSize,
            PageNumber,
            total,
            clients
            );
    }

    public async Task<PaginatedListModel<ClientCategoriesModel>> GetClientCategoriesAsync(
        int clientId,
        int PageNumber,
        int PageSize)
    {
        var clientExists = await _context.Clients.AnyAsync(c => c.Id == clientId);
        if (!clientExists)
            throw new Exception("Client not found");


        var categories = await _context.PurchaseItems
            .AsNoTracking()
            .Where(pi => pi.Purchase.ClientId == clientId)
            .GroupBy(pi => pi.Product.Category)
            .Select(g => new ClientCategoriesModel
            {
                Category = g.Key,
                Quantity = g.Sum(x => x.Quantity)
            })
            .ToListAsync();

        int total = categories.Count;

        return new PaginatedListModel<ClientCategoriesModel>(
            PageSize,
            PageNumber,
            total,
            categories
            );
    }    
}
