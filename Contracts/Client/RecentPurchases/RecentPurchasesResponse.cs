using Contracts.Common;

namespace Contracts.Client.RecentPurchases;

public class RecentPurchasesResponse : ListResponse
{
    public List<RecentPurchasesResponse> Items { get; set; } = null!;
}

public record RecentPurchasesItemResponse(
    int Id,
    string FirstName,
    string SecondName,
    string LastName
);
