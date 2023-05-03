namespace BookStore.Application.Catalog.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Catalog.Repositories;
using Domain.Common.Events.Sales;
using static BooksCacheConstants;

public class BookOrderedEventHandler : IEventHandler<BookOrderedEvent>
{
    private readonly IMemoryDatabase memoryDatabase;
    private readonly IBookDomainRepository bookRepository;

    public BookOrderedEventHandler(
        IMemoryDatabase memoryDatabase,
        IBookDomainRepository bookRepository)
    {
        this.memoryDatabase = memoryDatabase;
        this.bookRepository = bookRepository;
    }

    public async Task Handle(BookOrderedEvent domainEvent)
    {
        var book = await this.bookRepository.Find(domainEvent.BookId);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), domainEvent.BookId);
        }

        var quantity = book.Quantity - domainEvent.Quantity;

        book.UpdateQuantity(quantity);

        await this.bookRepository.Save(book);

        await this.memoryDatabase.Remove(BooksListingKey);

        await this.memoryDatabase.Remove(BookDetailsKey + domainEvent.BookId);
    }
}