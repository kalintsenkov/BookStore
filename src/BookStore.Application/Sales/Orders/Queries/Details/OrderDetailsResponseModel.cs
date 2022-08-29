namespace BookStore.Application.Sales.Orders.Queries.Details;

using System.Collections.Generic;
using Common;

public class OrderDetailsResponseModel : OrderResponseModel
{
    public decimal TotalPrice { get; private set; } = default!;

    public IEnumerable<OrderedBookResponseModel> OrderedBooks { get; private set; } = default!;
}