namespace BookStore.Application.Sales.ShoppingCarts.Queries.TotalBooks;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Sales.Repositories;
using MediatR;

public class GetShoppingCartTotalBooksQuery : IRequest<int>
{
    public class GetShoppingCartTotalBooksQueryHandler : IRequestHandler<GetShoppingCartTotalBooksQuery, int>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IShoppingCartQueryRepository shoppingCartRepository;

        public GetShoppingCartTotalBooksQueryHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository,
            IShoppingCartQueryRepository shoppingCartRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<int> Handle(
            GetShoppingCartTotalBooksQuery request, 
            CancellationToken cancellationToken)
        {
            var customerId = await this.customerRepository.GetCustomerId(
                this.currentUser.UserId,
                cancellationToken);

            return await this.shoppingCartRepository.TotalBooks(
                customerId,
                cancellationToken);
        }
    }
}