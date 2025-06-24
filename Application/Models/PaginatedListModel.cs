namespace Application.Models;

public class PaginatedListModel<T>
{
    public PaginatedListModel(
        int pageSize,
        int pageNumber,
        int total,
        List<T> items
    )
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Total = total;
        Items = items;
    }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int Total { get; set; }
    public List<T> Items { get; set; } = null!;
}
