namespace Application.Models.Client;

public class RecentPurchaseModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime LastPurchaseDate{ get; set; }
}
