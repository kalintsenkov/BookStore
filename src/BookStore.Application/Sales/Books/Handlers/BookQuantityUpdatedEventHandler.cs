namespace BookStore.Application.Sales.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Common.Events.Catalog;
using Domain.Sales.Repositories;

public class BookQuantityUpdatedEventHandler : IEventHandler<BookQuantityUpdatedEvent>
{
    private readonly IBookDomainRepository bookRepository;

    public BookQuantityUpdatedEventHandler(IBookDomainRepository bookRepository)
        => this.bookRepository = bookRepository;

    public async Task Handle(BookQuantityUpdatedEvent domainEvent)
    {
        var book = await this.bookRepository.Find(domainEvent.Id);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), domainEvent.Id);
        }

        book.UpdateQuantity(domainEvent.Quantity);

        await this.bookRepository.Save(book);
    }
}