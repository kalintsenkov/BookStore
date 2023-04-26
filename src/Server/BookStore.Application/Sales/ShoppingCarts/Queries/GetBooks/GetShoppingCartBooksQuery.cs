namespace BookStore.Application.Sales.ShoppingCarts.Queries.GetBooks;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Sales.Repositories;
using MediatR;

public class GetShoppingCartBooksQuery : IRequest<IEnumerable<GetShoppingCartBookResponseModel>>
{
    public class GetShoppingCartBooksQueryHandler : IRequestHandler<
        GetShoppingCartBooksQuery,
        IEnumerable<GetShoppingCartBookResponseModel>>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartQueryRepository shoppingCartRepository;

        public GetShoppingCartBooksQueryHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartQueryRepository shoppingCartRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<IEnumerable<GetShoppingCartBookResponseModel>> Handle(
            GetShoppingCartBooksQuery request,
            CancellationToken cancellationToken)
        {
            var customerId = await this.customerRepository.GetCustomerId(
                this.currentUser.UserId,
                cancellationToken);

            return await this.shoppingCartRepository.GetBooksListing(
                customerId,
                cancellationToken);
        }
    }
}