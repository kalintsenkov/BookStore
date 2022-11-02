namespace BookStore.Application.Sales.Orders.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Sales.Exceptions;
using Common.Contracts;
using Common.Models;
using Domain.Sales.Factories.Orders;
using Domain.Sales.Repositories;
using MediatR;

public class OrderCreateCommand : IRequest<Result<int>>
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, Result<int>>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartDomainRepository shoppingCartRepository;
        private readonly IOrderFactory orderFactory;
        private readonly IOrderDomainRepository orderRepository;

        public OrderCreateCommandHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartDomainRepository shoppingCartRepository,
            IOrderFactory orderFactory,
            IOrderDomainRepository orderRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
            this.orderFactory = orderFactory;
            this.orderRepository = orderRepository;
        }

        public async Task<Result<int>> Handle(
            OrderCreateCommand request,
            CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            var shoppingCart = await this.shoppingCartRepository.FindByCustomer(
                customer.Id,
                cancellationToken);

            if (shoppingCart is null)
            {
                throw new InvalidShoppingCartException(
                    $"Customer '{customer.Id}' does not have an existing shopping cart.");
            }

            var order = this.orderFactory
                .ForCustomer(customer)
                .Build();

            foreach (var shoppingCartBook in shoppingCart.Books)
            {
                order.OrderBook(shoppingCartBook.Book, shoppingCartBook.Quantity);
            }

            await this.orderRepository.Save(order, cancellationToken);

            await this.shoppingCartRepository.Clear(
                shoppingCart.Id,
                cancellationToken);

            return order.Id;
        }
    }
}