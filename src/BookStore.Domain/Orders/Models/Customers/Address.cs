namespace BookStore.Domain.Orders.Models.Customers;

using Common.Models;
using Exceptions;

using static ModelConstants.Address;

public class Address : ValueObject
{
    internal Address(string billingAddress, string deliveryAddress)
    {
        this.Validate(billingAddress, deliveryAddress);

        this.BillingAddress = billingAddress;
        this.DeliveryAddress = deliveryAddress;
    }

    public string BillingAddress { get; }

    public string DeliveryAddress { get; }

    private void Validate(string billingAddress, string deliveryAddress)
    {
        this.Validate(billingAddress);
        this.Validate(deliveryAddress);
    }

    private void Validate(string address)
        => Guard.ForStringLength<InvalidAddressException>(
            address,
            MinAddressLength,
            MaxAddressLength,
            nameof(Address));
}