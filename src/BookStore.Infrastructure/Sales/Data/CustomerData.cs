namespace BookStore.Infrastructure.Sales.Data;

using System.Collections.Generic;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Sales.Models.Customers;

internal class CustomerData : IMapFrom<Customer>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;

    public string UserId { get; private set; } = default!;

    public int? AddressId { get; private set; }

    public AddressData? Address { get; private set; }

    public ICollection<OrderData> Orders { get; } = new HashSet<OrderData>();

    public void Mapping(Profile mapper)
        => mapper
            .CreateMapAndReverseMapWithBaseRules<
                CustomerData,
                Customer>();
}