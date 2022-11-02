namespace BookStore.Domain.Sales.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.ShoppingCarts;

public interface IShoppingCartDomainRepository : IDomainRepository<ShoppingCart>
{
    Task<ShoppingCart?> FindByCustomer(
        int customerId,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteBook(
        int bookId,
        CancellationToken cancellationToken = default);

    Task<bool> HasCustomerBook(
        int customerId,
        int bookId,
        CancellationToken cancellationToken = default);

    Task<bool> Clear(
        int id,
        CancellationToken cancellationToken = default);
}