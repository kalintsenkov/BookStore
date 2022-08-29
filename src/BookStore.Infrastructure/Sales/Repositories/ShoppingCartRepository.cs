namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.ShoppingCarts;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Sales.Models.ShoppingCarts;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class ShoppingCartRepository : DataRepository<ISalesDbContext, ShoppingCart>,
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
        => await this
            .All()
            .Where(c => c.Customer.Id == customerId)
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
            .Where(c => c.Customer.Id == customerId)
            .AnyAsync(c => c.Books
                .Any(sb => sb.BookId == bookId), cancellationToken);

    private async Task<ShoppingCartBook?> FindBook(
        int bookId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .ShoppingCartBooks
            .Where(sb => sb.BookId == bookId)
            .FirstOrDefaultAsync(cancellationToken);
}