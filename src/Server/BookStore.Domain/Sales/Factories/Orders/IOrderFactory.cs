namespace BookStore.Domain.Sales.Factories.Orders;

using System;
using Common;
using Models.Customers;
using Models.Orders;

public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithDate(DateTime date);

    IOrderFactory ForCustomer(Customer customer);
}