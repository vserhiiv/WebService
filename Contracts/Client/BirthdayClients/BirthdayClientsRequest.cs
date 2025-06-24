using Contracts.Common;
using System.ComponentModel;

namespace Contracts.Client.BirthdayClients;

public class BirthdayClientsRequest : ListRequest
{
    [DefaultValue("1980-07-31")]
    public DateOnly Date { get; set; }
}
