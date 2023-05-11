namespace BookStore.Application.Sales.Orders;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Common;
using Domain.Sales.Models.Orders;
using Queries.Common;
using Queries.Details;

public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<OrderDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Order> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TResponseModel>> GetOrdersListing<TResponseModel>(
        Specification<Order> specification,
        OrdersSearchOrder searchOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}