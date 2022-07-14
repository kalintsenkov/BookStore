namespace BookStore.Infrastructure.Sales.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Sales.Models.Orders;

internal class OrderData : IMapFrom<Order>
{
    public int Id { get; private set; } = default!;

    public DateTime Date { get; private set; } = default!;

    public State State { get; private set; } = default!;

    public int CustomerId { get; private set; }

    public CustomerData Customer { get; private set; } = default!;

    public decimal TotalPrice => this.OrderedBooks.Sum(o => o.Quantity * o.Book.Price);

    public ICollection<OrderedBookData> OrderedBooks { get; } = new HashSet<OrderedBookData>();

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<
                OrderData,
                Order>();
}