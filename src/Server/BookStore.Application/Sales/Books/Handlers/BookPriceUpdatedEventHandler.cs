namespace BookStore.Application.Sales.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Common.Events.Catalog;
using Domain.Sales.Repositories;

public class BookPriceUpdatedEventHandler : IEventHandler<BookPriceUpdatedEvent>
{
    private readonly IBookDomainRepository bookRepository;

    public BookPriceUpdatedEventHandler(IBookDomainRepository bookRepository)
        => this.bookRepository = bookRepository;

    public async Task Handle(BookPriceUpdatedEvent domainEvent)
    {
        var book = await this.bookRepository.Find(domainEvent.Id);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), domainEvent.Id);
        }

        book.UpdatePrice(domainEvent.Price);

        await this.bookRepository.Save(book);
    }
}