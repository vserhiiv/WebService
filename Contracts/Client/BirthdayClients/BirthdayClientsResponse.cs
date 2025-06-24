using Contracts.Common;

namespace Contracts.Client.BirthdayClients;

public class BirthdayClientsResponse : ListResponse
{
    public List<BirthdayClientsItemResponse> Items { get; set; } = null!;
}

public record BirthdayClientsItemResponse(
    int Id,
    string FirstName,
    string SecondName,
    string LastName
);
