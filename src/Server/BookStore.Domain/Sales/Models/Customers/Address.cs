namespace BookStore.Domain.Sales.Models.Customers;

using Common.Models;
using Exceptions;

using static ModelConstants.Address;

public class Address : Entity<int>
{
    internal Address(
        string city,
        string state,
        string postalCode,
        string description,
        PhoneNumber phoneNumber)
    {
        this.Validate(city, state, postalCode, description);

        this.City = city;
        this.State = state;
        this.PostalCode = postalCode;
        this.Description = description;
        this.PhoneNumber = phoneNumber;
    }

    private Address(
        string city,
        string state,
        string postalCode,
        string description)
    {
        this.City = city;
        this.State = state;
        this.PostalCode = postalCode;
        this.Description = description;

        this.PhoneNumber = default!;
    }

    public string City { get; private set; }

    public string State { get; private set; }

    public string PostalCode { get; private set; }

    public string Description { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public Address UpdateCity(string city)
    {
        this.ValidateCity(city);

        this.City = city;

        return this;
    }

    public Address UpdateState(string state)
    {
        this.ValidateState(state);

        this.State = state;

        return this;
    }

    public Address UpdatePostalCode(string postalCode)
    {
        this.ValidatePostalCode(postalCode);

        this.PostalCode = postalCode;

        return this;
    }

    public Address UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    public Address UpdatePhoneNumber(string phoneNumber)
    {
        this.PhoneNumber = phoneNumber;

        return this;
    }

    private void Validate(
        string city,
        string state,
        string postalCode,
        string description)
    {
        this.ValidateCity(city);
        this.ValidateState(state);
        this.ValidatePostalCode(postalCode);
        this.ValidateDescription(description);
    }

    private void ValidateCity(string city)
        => Guard.ForStringLength<InvalidAddressException>(
            city,
            MinCityLength,
            MaxCityLength,
            nameof(this.City));

    private void ValidateState(string state)
        => Guard.ForStringLength<InvalidAddressException>(
            state,
            MinStateLength,
            MaxStateLength,
            nameof(this.State));

    private void ValidatePostalCode(string postalCode)
        => Guard.ForStringLength<InvalidAddressException>(
            postalCode,
            MinPostalCodeLength,
            MaxPostalCodeLength,
            nameof(this.PostalCode));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidAddressException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}