namespace BookStore.Domain.Sales.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.ShoppingCarts;

public interface IShoppingCartDomainRepository : IDomainRepository<ShoppingCart>
{
    Task<ShoppingCart> FindByCustomer(
        int customerId,
        CancellationToken cancellationToken = default);
}