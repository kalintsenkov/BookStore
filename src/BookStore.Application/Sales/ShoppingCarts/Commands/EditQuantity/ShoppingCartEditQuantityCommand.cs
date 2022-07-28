namespace BookStore.Application.Sales.ShoppingCarts.Commands.EditQuantity;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Common.Models;
using Domain.Sales.Exceptions;
using Domain.Sales.Repositories;
using MediatR;

public class ShoppingCartEditQuantityCommand : IRequest<Result>
{
    public int BookId { get; init; }

    public int Quantity { get; init; }

    public class ShoppingCartEditQuantityCommandHandler : IRequestHandler<ShoppingCartEditQuantityCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartDomainRepository shoppingCartRepository;

        public ShoppingCartEditQuantityCommandHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartDomainRepository shoppingCartRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Result> Handle(
            ShoppingCartEditQuantityCommand request,
            CancellationToken cancellationToken)
        {
            var customerId = await this.customerRepository.GetCustomerId(
                this.currentUser.UserId,
                cancellationToken);

            var shoppingCart = await this.shoppingCartRepository.FindByCustomer(
                customerId,
                cancellationToken);

            if (shoppingCart is null)
            {
                throw new InvalidShoppingCartException(
                    $"Customer '{customerId}' does not have an existing shopping cart.");
            }

            var shoppingCartBook = await this.shoppingCartRepository.FindBook(
                request.BookId,
                cancellationToken);

            if (shoppingCartBook is null)
            {
                throw new NotFoundException(
                    nameof(shoppingCartBook),
                    request.BookId);
            }

            shoppingCartBook.UpdateQuantity(request.Quantity);

            return Result.Success;
        }
    }
}