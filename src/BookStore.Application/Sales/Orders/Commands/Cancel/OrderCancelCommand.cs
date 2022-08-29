namespace BookStore.Application.Sales.Orders.Commands.Cancel;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class OrderCancelCommand : EntityCommand<int>, IRequest<Result<int>>
{
    public class OrderCancelCommandHandler : IRequestHandler<OrderCancelCommand, Result<int>>
    {
        private readonly IOrderDomainRepository orderRepository;

        public OrderCancelCommandHandler(IOrderDomainRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<Result<int>> Handle(
            OrderCancelCommand request,
            CancellationToken cancellationToken)
        {
            var order = await this.orderRepository.Find(
                request.Id,
                cancellationToken);

            if (order is null)
            {
                throw new NotFoundException(nameof(order), request.Id);
            }

            order.MarkAsCancelled();

            await this.orderRepository.Save(order, cancellationToken);

            return order.Id;
        }
    }
}