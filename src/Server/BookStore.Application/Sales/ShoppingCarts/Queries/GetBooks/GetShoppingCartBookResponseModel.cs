namespace BookStore.Application.Sales.ShoppingCarts.Queries.GetBooks;

using Common.Mapping;
using Domain.Sales.Models.ShoppingCarts;

public class GetShoppingCartBookResponseModel : IMapFrom<ShoppingCartBook>
{
    public string BookTitle { get; private set; } = default!;

    public decimal BookPrice { get; private set; }

    public string BookImageUrl { get; private set; } = default!;

    public int Quantity { get; private set; }
}