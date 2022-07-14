namespace BookStore.Application.Sales.Customers;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Common;
using Domain.Sales.Models.Customers;
using Queries.Common;

public interface ICustomerQueryRepository : IQueryRepository<Customer>
{
    Task<int> Total(
        Specification<Customer> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CustomerResponseModel>> GetCustomersListing(
        Specification<Customer> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}