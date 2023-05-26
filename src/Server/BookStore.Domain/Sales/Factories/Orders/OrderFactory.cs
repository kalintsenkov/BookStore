namespace BookStore.Domain.Sales.Factories.Orders;

using System;
using Exceptions;
using Models.Customers;
using Models.Orders;

internal class OrderFactory : IOrderFactory
{
    private DateTime orderDate = default!;
    private Customer orderCustomer = default!;

    private bool isDateSet = false;
    private bool isCustomerSet = false;

    public IOrderFactory WithDate(DateTime date)
    {
        this.orderDate = date;
        this.isDateSet = true;

        return this;
    }

    public IOrderFactory ForCustomer(Customer customer)
    {
        this.orderCustomer = customer;
        this.isCustomerSet = true;

        return this;
    }

    public Order Build()
    {
        if (!this.isDateSet || !this.isCustomerSet)
        {
            throw new InvalidOrderException("Date and customer must have a value.");
        }

        return new Order(this.orderDate, this.orderCustomer);
    }
}