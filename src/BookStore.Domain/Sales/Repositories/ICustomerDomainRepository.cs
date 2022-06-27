namespace BookStore.Domain.Sales.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Customers;

public interface ICustomerDomainRepository : IDomainRepository<Customer>
{
    Task<Customer?> Find(
        int id,
        CancellationToken cancellationToken = default);
}