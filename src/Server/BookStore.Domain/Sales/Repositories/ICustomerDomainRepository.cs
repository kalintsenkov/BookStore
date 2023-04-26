namespace BookStore.Domain.Sales.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Customers;

public interface ICustomerDomainRepository : IDomainRepository<Customer>
{
    Task<Customer> FindByUser(
        string userId,
        CancellationToken cancellationToken = default);

    Task<int> GetCustomerId(
        string userId,
        CancellationToken cancellationToken = default);
}