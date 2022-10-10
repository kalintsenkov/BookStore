namespace BookStore.Domain.Common.Events.Sales;

public class BookOrderedEvent : IDomainEvent
{
    public BookOrderedEvent(int bookId, int quantity)
    {
        BookId = bookId;
        Quantity = quantity;
    }

    public int BookId { get; }

    public int Quantity { get; }
}