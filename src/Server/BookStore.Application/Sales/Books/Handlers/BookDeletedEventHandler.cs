namespace BookStore.Application.Sales.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Common.Events.Catalog;
using Domain.Sales.Repositories;

public class BookDeletedEventHandler : IEventHandler<BookDeletedEvent>
{
    private readonly IDateTime dateTime;
    private readonly IBookDomainRepository bookRepository;

    public BookDeletedEventHandler(
        IDateTime dateTime,
        IBookDomainRepository bookRepository)
    {
        this.dateTime = dateTime;
        this.bookRepository = bookRepository;
    }

    public async Task Handle(BookDeletedEvent domainEvent)
    {
        var id = domainEvent.Id;

        var book = await this.bookRepository.Find(id);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), id);
        }

        book.Delete(this.dateTime.Now);

        await this.bookRepository.Save(book);
    }
}