namespace BookStore.Domain.Sales.Models.Customers;

using Common.Models;
using Exceptions;

using static ModelConstants.Address;

public class Address : Entity<int>
{
    public Address(
        string city,
        string state,
        string postalCode,
        string description,
        string phoneNumber)
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

    public string City { get; }

    public string State { get; }

    public string PostalCode { get; }

    public string Description { get; }

    public PhoneNumber PhoneNumber { get; }

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