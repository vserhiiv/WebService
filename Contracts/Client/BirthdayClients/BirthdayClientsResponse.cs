using Contracts.Common;

namespace Contracts.Client.BirthdayClients;

public class BirthdayClientsResponse : ListResponse
{
    public List<BirthdayClientsResponseItem> Items { get; set; } = null!;
}