namespace BookStore.Domain.Sales.Factories.Orders;

using Common;
using Models.Customers;
using Models.Orders;

public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory ForCustomer(Customer customer);
}