namespace BookStore.Application.Sales.Orders.Commands.Complete;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class OrderCompleteCommand : EntityCommand<int>, IRequest<Result<int>>
{
    public class OrderCompleteCommandHandler : IRequestHandler<OrderCompleteCommand, Result<int>>
    {
        private readonly IOrderDomainRepository orderRepository;

        public OrderCompleteCommandHandler(IOrderDomainRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<Result<int>> Handle(
            OrderCompleteCommand request,
            CancellationToken cancellationToken)
        {
            var order = await this.orderRepository.Find(
                request.Id,
                cancellationToken);

            if (order is null)
            {
                throw new NotFoundException(nameof(order), request.Id);
            }

            order.MarkAsCompleted();

            await this.orderRepository.Save(order, cancellationToken);

            return order.Id;
        }
    }
}