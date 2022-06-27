namespace BookStore.Domain.Orders.Models.Customers;

using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Customer : Entity<int>, IAggregateRoot
{
    internal Customer(
        string firstName,
        string lastName,
        string userId,
        Address address,
        string phoneNumber)
    {
        this.Validate(firstName, lastName);

        this.FirstName = firstName;
        this.LastName = lastName;
        this.UserId = userId;
        this.Address = address;
        this.PhoneNumber = phoneNumber;
    }

    private Customer(
        string firstName,
        string lastName,
        string userId)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.UserId = userId;

        this.Address = default!;
        this.PhoneNumber = default!;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string UserId { get; private set; }

    public Address Address { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public Customer UpdateFirstName(string firstName)
    {
        this.ValidateFirstName(firstName);

        this.FirstName = firstName;

        return this;
    }

    public Customer UpdateLastName(string lastName)
    {
        this.ValidateLastName(lastName);

        this.LastName = lastName;

        return this;
    }

    public Customer UpdateAddress(string billingAddress, string deliveryAddress)
    {
        this.Address = new Address(billingAddress, deliveryAddress);

        return this;
    }

    public Customer UpdatePhoneNumber(string phoneNumber)
    {
        this.PhoneNumber = phoneNumber;

        return this;
    }

    private void Validate(string firstName, string lastName)
    {
        this.ValidateFirstName(firstName);
        this.ValidateLastName(lastName);
    }

    private void ValidateFirstName(string firstName)
        => Guard.ForStringLength<InvalidCustomerException>(
            firstName,
            MinNameLength,
            MaxNameLength,
            nameof(this.FirstName));

    private void ValidateLastName(string lastName)
        => Guard.ForStringLength<InvalidCustomerException>(
            lastName,
            MinNameLength,
            MaxNameLength,
            nameof(this.LastName));
}