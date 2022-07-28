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
                .Where(c => c.CustomerId == customerId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ShoppingCartBook?> FindBook(
        int bookId,
        CancellationToken cancellationToken = default)
        => await this
            .GetShoppingCartBooks()
            .Where(b => b.Book.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);

    private IQueryable<ShoppingCartBook> GetShoppingCartBooks()
        => this.Mapper
            .ProjectTo<ShoppingCartBook>(this
                .Data
                .ShoppingCartBooks
                .AsNoTracking());
}