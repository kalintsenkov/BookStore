namespace BookStore.Application.Sales.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Common.Events.Catalog;
using Domain.Sales.Repositories;

public class BookImageUrlUpdatedEventHandler: IEventHandler<BookImageUrlUpdatedEvent>
{
    private readonly IBookDomainRepository bookRepository;

    public BookImageUrlUpdatedEventHandler(IBookDomainRepository bookRepository) 
        => this.bookRepository = bookRepository;

    public async Task Handle(BookImageUrlUpdatedEvent domainEvent)
    {
        var book = await this.bookRepository.Find(domainEvent.Id);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), domainEvent.Id);
        }

        book.UpdateImageUrl(domainEvent.ImageUrl);

        await this.bookRepository.Save(book);
    }
}