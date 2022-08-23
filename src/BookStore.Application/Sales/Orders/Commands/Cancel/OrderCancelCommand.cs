namespace BookStore.Application.Sales.Orders.Commands.Cancel;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class OrderCancelCommand : EntityCommand<int>, IRequest<Result>
{
    public class OrderCancelCommandHandler : IRequestHandler<OrderCancelCommand, Result>
    {
        private readonly IOrderDomainRepository orderRepository;

        public OrderCancelCommandHandler(IOrderDomainRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<Result> Handle(
            OrderCancelCommand request,
            CancellationToken cancellationToken)
        {
            var order = await this.orderRepository.Find(
                request.Id,
                cancellationToken);

            if (order is null)
            {
                throw new NotFoundException(
                    nameof(order),
                    request.Id);
            }

            order.MarkAsCancelled();

            await this.orderRepository.Save(order, cancellationToken);

            return Result.Success;
        }
    }
}