namespace BookStore.Domain.Sales.Models.Books;

using Common;
using Common.Models;
using Exceptions;

using static ModelConstants.Book;

public class Book : Entity<int>, IAggregateRoot
{
    internal Book(
        string title,
        decimal price,
        int quantity,
        string description,
        int authorId)
    {
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.Description = description;
        this.AuthorId = authorId;
    }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public string Description { get; private set; }

    public int AuthorId { get; private set; }

    public bool IsAvailable => this.Quantity is not 0;

    public Book UpdateQuantity(int quantity)
    {
        this.ValidateQuantity(quantity);

        this.Quantity = quantity;

        return this;
    }

    private void ValidateQuantity(int quantity)
        => Guard.AgainstOutOfRange<InvalidBookException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));
}