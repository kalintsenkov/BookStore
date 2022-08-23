namespace BookStore.Application.Sales.Orders.Commands.Complete;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class OrderCompleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class OrderCompleteCommandHandler : IRequestHandler<OrderCompleteCommand, Result>
    {
        private readonly IOrderDomainRepository orderRepository;

        public OrderCompleteCommandHandler(IOrderDomainRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<Result> Handle(
            OrderCompleteCommand request,
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

            order.MarkAsCompleted();

            await this.orderRepository.Save(order, cancellationToken);

            return Result.Success;
        }
    }
}