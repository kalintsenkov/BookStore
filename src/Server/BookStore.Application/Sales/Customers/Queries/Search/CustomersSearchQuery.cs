namespace BookStore.Application.Sales.Customers.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Sales.Models.Customers;
using Domain.Sales.Specifications.Customers;
using MediatR;

public class CustomersSearchQuery : IRequest<CustomersSearchResponseModel>
{
    private const int CustomersPerPage = 10;

    public string Name { get; init; } = default!;

    public int Page { get; init; } = 1;

    public class CustomersSearchQueryHandler : IRequestHandler<CustomersSearchQuery, CustomersSearchResponseModel>
    {
        private readonly ICustomerQueryRepository customerRepository;

        public CustomersSearchQueryHandler(ICustomerQueryRepository customerRepository)
            => this.customerRepository = customerRepository;

        public async Task<CustomersSearchResponseModel> Handle(
            CustomersSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetCustomerSpecification(request);

            var skip = (request.Page - 1) * CustomersPerPage;

            var customersListing = await this.customerRepository.GetCustomersListing(
                specification,
                skip,
                take: CustomersPerPage,
                cancellationToken);

            var totalCustomers = await this.customerRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCustomers / CustomersPerPage);

            return new CustomersSearchResponseModel(customersListing, request.Page, totalPages);
        }

        private Specification<Customer> GetCustomerSpecification(
            CustomersSearchQuery request)
            => new CustomerByNameSpecification(request.Name);
    }
}