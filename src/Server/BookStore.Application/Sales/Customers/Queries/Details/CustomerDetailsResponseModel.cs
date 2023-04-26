namespace BookStore.Application.Sales.Customers.Queries.Details;

using Common;

public class CustomerDetailsResponseModel : CustomerResponseModel
{
    public string? AddressCity { get; private set; }

    public string? AddressState { get; private set; }

    public string? AddressPostalCode { get; private set; }

    public string? AddressDescription { get; private set; }

    public string? AddressPhoneNumber { get; private set; }
}