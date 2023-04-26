namespace BookStore.Application.Sales.Customers.Queries.Common;

using Application.Common.Mapping;
using Domain.Sales.Models.Customers;

public class CustomerResponseModel : IMapFrom<Customer>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;
}