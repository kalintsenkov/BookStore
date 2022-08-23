namespace BookStore.Domain.Sales.Factories.Orders;

using Exceptions;
using Models.Customers;
using Models.Orders;

internal class OrderFactory : IOrderFactory
{
    private Customer orderCustomer = default!;

    private bool isCustomerSet = false;

    public IOrderFactory ForCustomer(Customer customer)
    {
        this.orderCustomer = customer;
        this.isCustomerSet = true;

        return this;
    }

    public Order Build()
    {
        if (!this.isCustomerSet)
        {
            throw new InvalidOrderException("Customer must have a value.");
        }

        return new Order(this.orderCustomer);
    }
}