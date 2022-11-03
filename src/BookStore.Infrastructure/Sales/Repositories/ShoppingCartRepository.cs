namespace BookStore.Infrastructure.Sales.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.ShoppingCarts;
using Application.Sales.ShoppingCarts.Queries.GetBooks;
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
            .Include(c => c.Books)
            .ThenInclude(sb => sb.Book)
            .SingleOrDefaultAsync(cancellationToken);

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
                .Any(sb => sb.Book.Id == bookId), cancellationToken);

    public async Task<bool> Clear(
        int id,
        CancellationToken cancellationToken = default)
    {
        var shoppingCartBooks = await this.FindBooks(
            id,
            cancellationToken);

        this.Data.ShoppingCartBooks.RemoveRange(shoppingCartBooks);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<int> TotalBooks(
        int customerId,
        CancellationToken cancellationToken = default)
        => await this
            .GetBooksQuery(customerId)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<GetShoppingCartBookResponseModel>> GetBooksListing(
        int customerId,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<GetShoppingCartBookResponseModel>(this
                .GetBooksQuery(customerId))
            .ToListAsync(cancellationToken);

    private async Task<ShoppingCartBook?> FindBook(
        int bookId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .ShoppingCartBooks
            .Where(sb => sb.Book.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);

    private async Task<IEnumerable<ShoppingCartBook>> FindBooks(
        int shoppingCartId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .ShoppingCarts
            .Where(sc => sc.Id == shoppingCartId)
            .SelectMany(sc => sc.Books)
            .ToListAsync(cancellationToken);

    private IQueryable<ShoppingCartBook> GetBooksQuery(
        int customerId)
        => this
            .AllAsNoTracking()
            .Where(sc => sc.Customer.Id == customerId)
            .SelectMany(sc => sc.Books);
}