namespace BookStore.Domain.Sales.Factories.Customers;

using Exceptions;
using Models.Customers;

internal class CustomerFactory : ICustomerFactory
{
    private string customerName = default!;
    private string customerUserId = default!;

    private bool isNameSet = false;
    private bool isUserIdSet = false;

    public ICustomerFactory WithName(string name)
    {
        this.customerName = name;
        this.isNameSet = true;

        return this;
    }

    public ICustomerFactory FromUser(string userId)
    {
        this.customerUserId = userId;
        this.isUserIdSet = true;

        return this;
    }

    public Customer Build()
    {
        if (!this.isNameSet || !this.isUserIdSet)
        {
            throw new InvalidCustomerException("Name and user id must have a value.");
        }

        return new Customer(this.customerName, this.customerUserId);
    }
}