namespace BookStore.Domain.Sales.Factories.ShoppingCarts;

using Common;
using Models.Customers;
using Models.ShoppingCarts;

public interface IShoppingCartFactory : IFactory<ShoppingCart>
{
    IShoppingCartFactory ForCustomer(Customer customer);
}