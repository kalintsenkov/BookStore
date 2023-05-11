namespace BookStore.Application.Sales.Orders.Queries.Search;

using System.Threading;
using System.Threading.Tasks;
using Common;
using MediatR;

public class OrdersSearchQuery : OrdersQuery, IRequest<OrdersSearchResponseModel>
{
    public class OrdersSearchQueryHandler : OrdersQueryHandler, IRequestHandler<
        OrdersSearchQuery,
        OrdersSearchResponseModel>
    {
        public OrdersSearchQueryHandler(IOrderQueryRepository orderRepository)
            : base(orderRepository)
        {
        }

        public async Task<OrdersSearchResponseModel> Handle(
            OrdersSearchQuery request,
            CancellationToken cancellationToken)
        {
            var ordersListing = await base.GetOrdersListing<OrderResponseModel>(
                request,
                cancellationToken: cancellationToken);

            var totalPages = await base.GetTotalPages(
                request,
                cancellationToken: cancellationToken);

            return new OrdersSearchResponseModel(ordersListing, request.Page, totalPages);
        }
    }
}