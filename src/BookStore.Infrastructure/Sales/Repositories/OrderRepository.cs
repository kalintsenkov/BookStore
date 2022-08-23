namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Sales.Models.Orders;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class OrderRepository : DataRepository<ISalesDbContext, Order, OrderData>,
    IOrderDomainRepository
{
    public OrderRepository(
        ISalesDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Order?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<Order>(this
                .AllAsNoTracking()
                .Where(o => o.Id == id))
            .FirstOrDefaultAsync(cancellationToken);
}