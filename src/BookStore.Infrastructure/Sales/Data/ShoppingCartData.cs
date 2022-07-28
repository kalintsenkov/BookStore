namespace BookStore.Infrastructure.Sales.Data;

using System.Collections.Generic;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Sales.Models.ShoppingCarts;

internal class ShoppingCartData : IMapFrom<ShoppingCart>
{
    public int Id { get; private set; }

    public int CustomerId { get; private set; }

    public CustomerData Customer { get; private set; } = default!;

    public ICollection<ShoppingCartBookData> Books { get; } = new HashSet<ShoppingCartBookData>();

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<
                ShoppingCartData,
                ShoppingCart>()
            .ForMember(m => m.Books, cfg => cfg.ExplicitExpansion());
}