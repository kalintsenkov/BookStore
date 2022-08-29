namespace BookStore.Application.Sales.Customers.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Contracts;
using Common.Models;
using Domain.Sales.Repositories;
using MediatR;

public class CustomerEditCommand : EntityCommand<int>, IRequest<Result<int>>
{
    public string Name { get; init; } = default!;

    public string City { get; init; } = default!;

    public string State { get; init; } = default!;

    public string PostalCode { get; init; } = default!;

    public string Description { get; init; } = default!;

    public string PhoneNumber { get; init; } = default!;

    public class CustomerEditCommandHandler : IRequestHandler<CustomerEditCommand, Result<int>>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;

        public CustomerEditCommandHandler(
            ICurrentUser currentUser,
            ICustomerDomainRepository customerRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
        }

        public async Task<Result<int>> Handle(
            CustomerEditCommand request,
            CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            if (request.Id != customer.Id)
            {
                return "You cannot edit this profile.";
            }

            customer
                .UpdateName(request.Name)
                .UpdateAddress(
                    request.City,
                    request.State,
                    request.PostalCode,
                    request.Description,
                    request.PhoneNumber);

            await this.customerRepository.Save(customer, cancellationToken);

            return customer.Id;
        }
    }
}