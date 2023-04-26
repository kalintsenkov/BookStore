namespace BookStore.Application.Sales.Orders;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Sales.Models.Orders;
using Queries.Details;

public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<OrderDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);
}