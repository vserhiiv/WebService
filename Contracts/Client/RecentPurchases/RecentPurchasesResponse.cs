using Contracts.Common;

namespace Contracts.Client.RecentPurchases;

public class RecentPurchasesResponse : ListResponse
{
    public List<RecentPurchasesResponseItem> Items { get; set; } = null!;
}