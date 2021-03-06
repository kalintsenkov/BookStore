namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.ShoppingCarts;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Sales.Models.ShoppingCarts;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class ShoppingCartRepository : DataRepository<ISalesDbContext, ShoppingCart, ShoppingCartData>,
    IShoppingCartDomainRepository,
    IShoppingCartQueryRepository
{
    public ShoppingCartRepository(
        ISalesDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<ShoppingCart?> FindByCustomer(
        int customerId,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<ShoppingCart>(this
                .AllAsNoTracking()
                .Where(c => c.CustomerId == customerId),
                membersToExpand: c => c.Books)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> DeleteBook(
        int bookId,
        CancellationToken cancellationToken = default)
    {
        var shoppingCartBook = await this.FindBook(
            bookId,
            cancellationToken);

        if (shoppingCartBook is null)
        {
            return false;
        }

        this.Data.ShoppingCartBooks.Remove(shoppingCartBook);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> HasCustomerBook(
        int customerId,
        int bookId,
        CancellationToken cancellationToken = default)
        => await this
            .AllAsNoTracking()
            .Where(c => c.CustomerId == customerId)
            .AnyAsync(c => c.Books
                .Any(sb => sb.BookId == bookId), cancellationToken);

    private async Task<ShoppingCartBookData?> FindBook(
        int bookId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .ShoppingCartBooks
            .AsNoTracking()
            .Where(sb => sb.BookId == bookId)
            .FirstOrDefaultAsync(cancellationToken);
}