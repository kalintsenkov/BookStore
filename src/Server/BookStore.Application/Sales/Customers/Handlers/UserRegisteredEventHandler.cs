namespace BookStore.Application.Sales.Customers.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Domain.Common.Events.Identity;
using Domain.Sales.Factories.Customers;
using Domain.Sales.Factories.ShoppingCarts;
using Domain.Sales.Repositories;

public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
{
    private readonly ICustomerFactory customerFactory;
    private readonly IShoppingCartFactory shoppingCartFactory;
    private readonly ICustomerDomainRepository customerRepository;
    private readonly IShoppingCartDomainRepository shoppingCartRepository;

    public UserRegisteredEventHandler(
        ICustomerFactory customerFactory,
        IShoppingCartFactory shoppingCartFactory,
        ICustomerDomainRepository customerRepository,
        IShoppingCartDomainRepository shoppingCartRepository)
    {
        this.customerFactory = customerFactory;
        this.customerRepository = customerRepository;
        this.shoppingCartFactory = shoppingCartFactory;
        this.shoppingCartRepository = shoppingCartRepository;
    }

    public async Task Handle(UserRegisteredEvent domainEvent)
    {
        var customer = this.customerFactory
            .WithName(domainEvent.FullName)
            .FromUser(domainEvent.UserId)
            .Build();

        await this.customerRepository.Save(customer);

        var shoppingCart = this.shoppingCartFactory
            .ForCustomer(customer)
            .Build();

        await this.shoppingCartRepository.Save(shoppingCart);
    }
}