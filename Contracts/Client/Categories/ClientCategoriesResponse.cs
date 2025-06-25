using Contracts.Common;

namespace Contracts.Client.Categories;

public class ClientCategoriesResponse : ListResponse
{
    public List<CategoriesResponseItem> Items { get; set; } = null!;
}