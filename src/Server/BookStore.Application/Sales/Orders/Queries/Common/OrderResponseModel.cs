namespace BookStore.Application.Sales.Orders.Queries.Common;

using Application.Common.Mapping;
using Domain.Sales.Models.Orders;

public class OrderResponseModel : IMapFrom<Order>
{
    public int Id { get; private set; }

    public string Date { get; private set; } = default!;

    public string Status { get; private set; } = default!;
}