namespace BookStore.Application.Sales.Orders.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class OrderDetailsQuery : IRequest<OrderDetailsResponseModel?>
{
    public int Id { get; init; }

    public class OrderDetailsQueryHandler : IRequestHandler<OrderDetailsQuery, OrderDetailsResponseModel?>
    {
        private readonly IOrderQueryRepository orderRepository;

        public OrderDetailsQueryHandler(IOrderQueryRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<OrderDetailsResponseModel?> Handle(
            OrderDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.orderRepository.Details(
                request.Id,
                cancellationToken);
    }
}