namespace BookStore.Infrastructure.Sales.Repositories;

using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Sales.Models.Orders;
using Domain.Sales.Repositories;

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
}