namespace BookStore.Domain.Sales.Factories.ShoppingCarts;

using Exceptions;
using Models.Customers;
using Models.ShoppingCarts;

internal class ShoppingCartFactory : IShoppingCartFactory
{
    private Customer shoppingCartCustomer = default!;

    private bool isCustomerSet = false;

    public IShoppingCartFactory ForCustomer(Customer customer)
    {
        this.shoppingCartCustomer = customer;
        this.isCustomerSet = true;

        return this;
    }

    public ShoppingCart Build()
    {
        if (!this.isCustomerSet)
        {
            throw new InvalidShoppingCartException("Customer must have a value.");
        }

        return new ShoppingCart(this.shoppingCartCustomer);
    }
}