namespace BookStore.Domain.Sales.Models.Customers;

using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Customer : Entity<int>, IAggregateRoot
{
    internal Customer(string name, string userId)
    {
        this.Validate(name);

        this.Name = name;
        this.UserId = userId;
    }

    public string Name { get; private set; }

    public string UserId { get; private set; }

    public Address? Address { get; private set; }

    public Customer UpdateName(string name)
    {
        this.Validate(name);

        this.Name = name;

        return this;
    }

    public Customer UpdateAddress(Address address)
    {
        this.Address = address;

        return this;
    }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidCustomerException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}