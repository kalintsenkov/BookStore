namespace BookStore.Infrastructure.Sales.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.Orders;
using Application.Sales.Orders.Queries.Common;
using Application.Sales.Orders.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Extensions;
using Common.Repositories;
using Domain.Common;
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

    public async Task<int> Total(
        Specification<Order> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetOrdersQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<TResponseModel>> GetOrdersListing<TResponseModel>(
        Specification<Order> specification,
        OrdersSearchOrder searchOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<TResponseModel>(this
                .GetOrdersQuery(specification)
                .Sort(searchOrder)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Order> GetOrdersQuery(
        Specification<Order> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}