namespace BookStore.Domain.Common.Events.Sales;

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