using Domain.Aggregates.Product;

namespace Domain.Aggregates.Purchase;

public class PurchaseItemAggregate
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public PurchaseAggregate Purchase { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductAggregate Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => Quantity * UnitPrice;
}
