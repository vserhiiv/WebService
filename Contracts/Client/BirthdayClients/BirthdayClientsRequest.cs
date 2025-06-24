using Contracts.Common;

namespace Contracts.Client.BirthdayClients;

public class BirthdayClientsRequest : ListRequest
{
    public DateOnly Date { get; set; }
}
