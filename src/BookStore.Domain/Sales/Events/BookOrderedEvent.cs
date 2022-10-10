namespace BookStore.Domain.Sales.Events;

using Common;

public class BookOrderedEvent : IDomainEvent
{
    public BookOrderedEvent(int bookId, int quantity)
    {
        this.BookId = bookId;
        this.Quantity = quantity;
    }

    public int BookId { get; }

    public int Quantity { get; }
}