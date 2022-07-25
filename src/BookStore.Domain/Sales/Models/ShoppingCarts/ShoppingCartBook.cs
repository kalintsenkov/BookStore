namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using Common.Models;
using Exceptions;
using Orders;

using static ModelConstants.OrderedBook;

public class ShoppingCartBook : Entity<int>
{
    internal ShoppingCartBook(Book book, int quantity)
    {
        this.Validate(book, quantity);

        this.Book = book;
        this.Quantity = quantity;
    }

    private ShoppingCartBook(int quantity)
    {
        this.Quantity = quantity;

        this.Book = default!;
    }

    public Book Book { get; private set; }

    public int Quantity { get; private set; }

    public ShoppingCartBook UpdateQuantity(int quantity)
    {
        this.Validate(this.Book, quantity);

        this.Quantity = quantity;

        return this;
    }

    private void Validate(Book book, int quantity)
    {
        if (!book.IsAvailable)
        {
            throw new InvalidShoppingCartException("Book is out of stock.");
        }

        Guard.AgainstOutOfRange<InvalidShoppingCartException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));
    }
}