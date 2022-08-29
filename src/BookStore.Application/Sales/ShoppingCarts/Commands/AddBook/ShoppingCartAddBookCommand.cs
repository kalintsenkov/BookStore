namespace BookStore.Application.Sales.ShoppingCarts.Commands.AddBook;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Models;
using Domain.Sales.Exceptions;
using Domain.Sales.Repositories;
using MediatR;

public class ShoppingCartAddBookCommand : IRequest<Result>
{
    public int BookId { get; init; }

    public int Quantity { get; init; }

    public class ShoppingCartAddBookCommandHandler : IRequestHandler<ShoppingCartAddBookCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartDomainRepository shoppingCartRepository;

        public ShoppingCartAddBookCommandHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartDomainRepository shoppingCartRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Result> Handle(
            ShoppingCartAddBookCommand request,
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

            shoppingCart.AddBook(request.BookId, request.Quantity);

            await this.shoppingCartRepository.Save(shoppingCart, cancellationToken);

            return Result.Success;
        }
    }
}