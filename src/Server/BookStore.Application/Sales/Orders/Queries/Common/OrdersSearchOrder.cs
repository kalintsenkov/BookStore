namespace BookStore.Application.Sales.Orders.Queries.Common;

using System;
using System.Linq.Expressions;
using Application.Common;
using Domain.Sales.Models.Orders;

public class OrdersSearchOrder : SortOrder<Order>
{
    public OrdersSearchOrder(string? sortBy, string? order)
        : base(sortBy, order)
    {
    }

    public override Expression<Func<Order, object>> ToExpression()
        => this.SortBy switch
        {
            "date" => order => order.Date,
            "status" => order => order.Status.Name,
            "customer" => order => order.Customer.Name,
            _ => order => order.Id
        };
}