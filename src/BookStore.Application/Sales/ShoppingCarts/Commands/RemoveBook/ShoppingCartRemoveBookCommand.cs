namespace BookStore.Application.Sales.ShoppingCarts.Commands.RemoveBook;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class ShoppingCartRemoveBookCommand : IRequest<Result>
{
    public int BookId { get; init; }

    public class ShoppingCartRemoveBookCommandHandler : IRequestHandler<ShoppingCartRemoveBookCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartDomainRepository shoppingCartRepository;

        public ShoppingCartRemoveBookCommandHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartDomainRepository shoppingCartRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Result> Handle(
            ShoppingCartRemoveBookCommand request,
            CancellationToken cancellationToken)
        {
            var customerId = await this.customerRepository.GetCustomerId(
                this.currentUser.UserId,
                cancellationToken);

            var customerHasBook = await this.shoppingCartRepository.HasCustomerBook(
                customerId,
                request.BookId,
                cancellationToken);

            if (!customerHasBook)
            {
                return "You cannot edit this shopping cart.";
            }

            return await this.shoppingCartRepository.DeleteBook(
                request.BookId,
                cancellationToken);
        }
    }
}