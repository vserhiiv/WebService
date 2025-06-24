using Contracts.Common;

namespace Contracts.Client.RecentPurchases;

public class RecentPurchasesRequest : ListRequest
{
    public int Days { get; set; }
}
