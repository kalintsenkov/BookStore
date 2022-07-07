namespace BookStore.Domain.Sales.Factories.Customers;

using Common;
using Models.Customers;

public interface ICustomerFactory : IFactory<Customer>
{
    ICustomerFactory WithName(string firstName);

    ICustomerFactory FromUser(string userId);
}