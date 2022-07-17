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

    public Customer UpdateAddress(
        string city,
        string state,
        string postalCode,
        string description,
        string phoneNumber)
    {
        if (this.Address is not null)
        {
            this.Address
                .UpdateCity(city)
                .UpdateState(state)
                .UpdatePostalCode(postalCode)
                .UpdateDescription(description)
                .UpdatePhoneNumber(phoneNumber);
        }
        else
        {
            this.Address = new Address(
                city,
                state,
                postalCode,
                description,
                phoneNumber);
        }

        return this;
    }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidCustomerException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}