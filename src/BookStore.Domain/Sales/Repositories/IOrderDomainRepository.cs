namespace BookStore.Domain.Sales.Repositories;

using System.Threading.Tasks;
using System.Threading;
using Common;
using Models.Orders;

public interface IOrderDomainRepository : IDomainRepository<Order>
{
    Task<Order?> Find(
        int id,
        CancellationToken cancellationToken = default);
}