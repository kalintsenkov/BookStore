namespace BookStore.Application.Sales.ShoppingCarts;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Sales.Models.ShoppingCarts;
using Queries.GetBooks;

public interface IShoppingCartQueryRepository : IQueryRepository<ShoppingCart>
{
    Task<int> TotalBooks(
        int customerId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GetShoppingCartBookResponseModel>> GetBooksListing(
        int customerId,
        CancellationToken cancellationToken = default);
}