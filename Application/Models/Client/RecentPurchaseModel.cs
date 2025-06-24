namespace Application.Models.Client;

public class RecentPurchaseModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime LastPurchaseDate{ get; set; }
}
