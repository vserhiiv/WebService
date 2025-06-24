using Domain.Aggregates.Client;

namespace Domain.Aggregates.Purchase;

public class PurchaseAggregate
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }
    public int ClientId { get; set; }
    public ClientAggregate Client { get; set; } = null!;

    public ICollection<PurchaseItemAggregate> Items { get; set; } = new List<PurchaseItemAggregate>();
}
