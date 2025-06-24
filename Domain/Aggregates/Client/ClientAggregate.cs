using Domain.Aggregates.Purchase;

namespace Domain.Aggregates.Client;

public class ClientAggregate
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }

    public ICollection<PurchaseAggregate> Purchases { get; set; } = new List<PurchaseAggregate>();
}
