namespace BookStore.Domain.Sales.Models.Orders;

using Books;
using Common.Models;
using Exceptions;

using static ModelConstants.OrderedBook;

public class OrderedBook : Entity<int>
{
    internal OrderedBook(Book book, int quantity)
    {
        this.Validate(quantity);

        this.Book = book;
        this.Quantity = quantity;
    }

    private OrderedBook(int quantity)
    {
        this.Book = default!;

        this.Quantity = quantity;
    }

    public Book Book { get; }

    public int Quantity { get; }

    public override int GetHashCode() => (this.Id, this.Book.Id).GetHashCode();

    private void Validate(int quantity)
        => Guard.AgainstOutOfRange<InvalidOrderException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));
}