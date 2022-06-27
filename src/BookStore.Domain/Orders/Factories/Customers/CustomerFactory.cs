namespace BookStore.Domain.Orders.Factories.Customers;

using Exceptions;
using Models.Customers;

internal class CustomerFactory : ICustomerFactory
{
    private string customerFirstName = default!;
    private string customerLastName = default!;
    private string customerBillingAddress = default!;
    private string customerDeliveryAddress = default!;
    private string customerPhoneNumber = default!;
    private string customerUserId = default!;

    private bool isFirstNameSet = false;
    private bool isLastNameSet = false;
    private bool isBillingAddressSet = false;
    private bool isDeliveryAddressSet = false;
    private bool isPhoneNumberSet = false;
    private bool isUserIdSet = false;

    public ICustomerFactory WithFirstName(string firstName)
    {
        this.customerFirstName = firstName;
        this.isFirstNameSet = true;

        return this;
    }

    public ICustomerFactory WithLastName(string lastName)
    {
        this.customerLastName = lastName;
        this.isLastNameSet = true;

        return this;
    }

    public ICustomerFactory WithAddress(string billingAddress, string deliveryAddress)
    {
        this.customerBillingAddress = billingAddress;
        this.customerDeliveryAddress = deliveryAddress;
        this.isBillingAddressSet = true;
        this.isDeliveryAddressSet = true;

        return this;
    }

    public ICustomerFactory WithPhoneNumber(string phoneNumber)
    {
        this.customerPhoneNumber = phoneNumber;
        this.isPhoneNumberSet = true;

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
        if (!this.isFirstNameSet ||
            !this.isLastNameSet ||
            !this.isBillingAddressSet ||
            !this.isDeliveryAddressSet ||
            !this.isPhoneNumberSet ||
            !this.isUserIdSet)
        {
            throw new InvalidCustomerException("Name, address, phone number and user id must have a value.");
        }

        return new Customer(
            this.customerFirstName,
            this.customerLastName,
            this.customerUserId,
            new Address(
                this.customerBillingAddress,
                this.customerDeliveryAddress),
            this.customerPhoneNumber);
    }
}