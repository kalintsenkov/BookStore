namespace BookStore.Application.Sales.Customers.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Domain.Identity.Events;
using Domain.Sales.Factories.Customers;
using Domain.Sales.Repositories;

public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
{
    private readonly ICustomerFactory customerFactory;
    private readonly ICustomerDomainRepository customerRepository;

    public UserRegisteredEventHandler(
        ICustomerFactory customerFactory,
        ICustomerDomainRepository customerRepository)
    {
        this.customerFactory = customerFactory;
        this.customerRepository = customerRepository;
    }

    public async Task Handle(UserRegisteredEvent domainEvent)
    {
        var customer = this.customerFactory
            .WithName(domainEvent.FullName)
            .FromUser(domainEvent.UserId)
            .Build();

        await this.customerRepository.Save(customer);
    }
}