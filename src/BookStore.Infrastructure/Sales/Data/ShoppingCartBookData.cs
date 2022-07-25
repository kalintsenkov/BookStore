namespace BookStore.Infrastructure.Sales.Data;

using Application.Common.Mapping;
using AutoMapper;
using Catalog.Data;
using Domain.Sales.Models.ShoppingCarts;

internal class ShoppingCartBookData : IMapFrom<ShoppingCartBook>
{
    public int Id { get; private set; }

    public int ShoppingCartId { get; private set; }

    public ShoppingCartData ShoppingCart { get; private set; } = default!;

    public int BookId { get; private set; }

    public BookData Book { get; private set; } = default!;

    public int Quantity { get; private set; }

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<
                ShoppingCartBookData,
                ShoppingCartBook>();
}