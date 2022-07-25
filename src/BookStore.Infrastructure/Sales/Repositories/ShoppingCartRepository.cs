namespace BookStore.Infrastructure.Sales.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Application.Sales.ShoppingCarts;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Sales.Models.ShoppingCarts;
using Domain.Sales.Repositories;

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

    public Task<ShoppingCart> FindByCustomer(
        int customerId,
        CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}