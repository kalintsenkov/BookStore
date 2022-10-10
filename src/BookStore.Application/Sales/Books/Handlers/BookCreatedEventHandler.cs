namespace BookStore.Application.Sales.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Domain.Common.Events.Catalog;
using Domain.Sales.Factories.Books;
using Domain.Sales.Repositories;

public class BookCreatedEventHandler : IEventHandler<BookCreatedEvent>
{
    private readonly IBookFactory bookFactory;
    private readonly IBookDomainRepository bookRepository;

    public BookCreatedEventHandler(
        IBookFactory bookFactory,
        IBookDomainRepository bookRepository)
    {
        this.bookFactory = bookFactory;
        this.bookRepository = bookRepository;
    }

    public async Task Handle(BookCreatedEvent domainEvent)
    {
        var book = this.bookFactory
            .WithTitle(domainEvent.Title)
            .WithPrice(domainEvent.Price)
            .WithQuantity(domainEvent.Quantity)
            .Build();

        await this.bookRepository.Save(book);
    }
}