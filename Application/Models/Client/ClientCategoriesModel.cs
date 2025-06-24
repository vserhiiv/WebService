using Domain.Enums;

namespace Application.Models.Client;

public class ClientCategoriesModel
{
    public CategoryEnum Category { get; set; }
    public int Quantity { get; set; }
}
