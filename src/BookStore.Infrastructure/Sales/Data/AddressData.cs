namespace BookStore.Infrastructure.Sales.Data;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Sales.Models.Customers;

internal class AddressData : IMapFrom<Address>
{
    public int Id { get; private set; }

    public string City { get; private set; } = default!;

    public string State { get; private set; } = default!;

    public string PostalCode { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public PhoneNumber PhoneNumber { get; private set; } = default!;

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<AddressData, Address>();
}