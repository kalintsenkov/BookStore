namespace BookStore.Application.Sales.Orders.Queries.Details;

using Application.Common.Mapping;
using Domain.Sales.Models.Orders;

public class OrderedBookResponseModel : IMapFrom<OrderedBook>
{
    public int BookId { get; private set; }

    public string BookTitle { get; private set; } = default!;

    public int Quantity { get; private set; }
}