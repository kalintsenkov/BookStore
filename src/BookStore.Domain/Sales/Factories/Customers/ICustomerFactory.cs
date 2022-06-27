namespace BookStore.Domain.Sales.Factories.Customers;

using Common;
using Models.Customers;

public interface ICustomerFactory : IFactory<Customer>
{
    ICustomerFactory WithFirstName(string firstName);

    ICustomerFactory WithLastName(string lastName);

    ICustomerFactory WithAddress(string billingAddress, string deliveryAddress);

    ICustomerFactory WithPhoneNumber(string phoneNumber);

    ICustomerFactory FromUser(string userId);
}