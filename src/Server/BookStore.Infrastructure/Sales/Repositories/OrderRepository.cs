namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.Orders;
using Application.Sales.Orders.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.Sales.Models.Orders;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class OrderRepository : DataRepository<ISalesDbContext, Order>,
    IOrderDomainRepository,
    IOrderQueryRepository
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
        => await this
            .All()
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<OrderDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<OrderDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(o => o.Id == id))
            .FirstOrDefaultAsync(cancellationToken);
}