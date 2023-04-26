namespace BookStore.Application.Sales.Customers.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class CustomerDetailsQuery : IRequest<CustomerDetailsResponseModel?>
{
    public int Id { get; init; }

    public class CustomerDetailsQueryHandler : IRequestHandler<CustomerDetailsQuery, CustomerDetailsResponseModel?>
    {
        private readonly ICustomerQueryRepository customerRepository;

        public CustomerDetailsQueryHandler(ICustomerQueryRepository customerRepository)
            => this.customerRepository = customerRepository;

        public async Task<CustomerDetailsResponseModel?> Handle(
            CustomerDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.customerRepository.Details(
                request.Id,
                cancellationToken);
    }
}