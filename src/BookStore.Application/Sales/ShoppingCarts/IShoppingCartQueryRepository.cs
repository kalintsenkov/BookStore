namespace BookStore.Application.Sales.ShoppingCarts;

using Common.Contracts;
using Domain.Sales.Models.ShoppingCarts;

public interface IShoppingCartQueryRepository : IQueryRepository<ShoppingCart>
{
    
}