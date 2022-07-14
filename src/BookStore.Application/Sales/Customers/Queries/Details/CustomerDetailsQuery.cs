namespace BookStore.Application.Sales.Customers.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using Common;
using MediatR;

public class CustomerDetailsQuery : IRequest<CustomerResponseModel?>
{
    public int Id { get; init; }

    public class CustomerDetailsQueryHandler : IRequestHandler<CustomerDetailsQuery, CustomerResponseModel?>
    {
        private readonly ICustomerQueryRepository customerRepository;

        public CustomerDetailsQueryHandler(ICustomerQueryRepository customerRepository)
            => this.customerRepository = customerRepository;

        public async Task<CustomerResponseModel?> Handle(
            CustomerDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.customerRepository.Details(
                request.Id,
                cancellationToken);
    }
}