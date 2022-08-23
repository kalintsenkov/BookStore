namespace BookStore.Application.Sales.Orders.Commands.Ship;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class OrderShipCommand : EntityCommand<int>, IRequest<Result>
{
    public class OrderShipCommandHandler : IRequestHandler<OrderShipCommand, Result>
    {
        private readonly IOrderDomainRepository orderRepository;

        public OrderShipCommandHandler(IOrderDomainRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<Result> Handle(
            OrderShipCommand request,
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

            order.MarkAsShipped();

            await this.orderRepository.Save(order, cancellationToken);

            return Result.Success;
        }
    }
}