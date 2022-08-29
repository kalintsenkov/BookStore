namespace BookStore.Application.Catalog.Books.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Catalog.Repositories;
using Domain.Sales.Events;

public class OrderedBookEventHandler : IEventHandler<OrderedBookEvent>
{
    private readonly IBookDomainRepository bookRepository;

    public OrderedBookEventHandler(IBookDomainRepository bookRepository)
        => this.bookRepository = bookRepository;

    public async Task Handle(OrderedBookEvent domainEvent)
    {
        var book = await this.bookRepository.Find(domainEvent.BookId);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), domainEvent.BookId);
        }

        var quantity = book.Quantity - domainEvent.Quantity;

        book.UpdateQuantity(quantity);

        await this.bookRepository.Save(book);
    }
}