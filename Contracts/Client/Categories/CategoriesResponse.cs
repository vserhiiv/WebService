using Contracts.Common;

namespace Contracts.Client.Categories;

public class CategoriesResponse : ListResponse
{
    public List<CategoriesItemResponse> Items { get; set; } = null!;
}

public record CategoriesItemResponse(
    int Id,
    string FirstName,
    string SecondName,
    string LastName
);
