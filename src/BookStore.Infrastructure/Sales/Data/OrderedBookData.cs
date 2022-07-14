namespace BookStore.Infrastructure.Sales.Data;

using Application.Common.Mapping;
using AutoMapper;
using Catalog.Data;
using Domain.Sales.Models.Orders;

internal class OrderedBookData : IMapFrom<OrderedBook>
{
    public int Id { get; private set; }

    public int OrderId { get; private set; }

    public OrderData Order { get; private set; } = default!;

    public int BookId { get; private set; }

    public BookData Book { get; private set; } = default!;

    public int Quantity { get; private set; }

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<
                OrderedBookData,
                BookData>();
}