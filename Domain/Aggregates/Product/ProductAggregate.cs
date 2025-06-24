using Domain.Aggregates.Purchase;

namespace Domain.Aggregates.Product;

public class ProductAggregate
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string SKU { get; set; } = null!;
    public decimal Price { get; set; }

    public ICollection<PurchaseItemAggregate> PurchaseItems { get; set; } = new List<PurchaseItemAggregate>();
}
