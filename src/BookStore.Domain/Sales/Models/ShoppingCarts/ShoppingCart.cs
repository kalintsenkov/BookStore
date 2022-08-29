namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Models;
using Customers;
using Exceptions;

public class ShoppingCart : Entity<int>, IAggregateRoot
{
    private readonly HashSet<ShoppingCartBook> books;

    internal ShoppingCart(Customer customer)
    {
        this.Customer = customer;

        this.books = new HashSet<ShoppingCartBook>();
    }

    private ShoppingCart()
    {
        this.Customer = default!;

        this.books = new HashSet<ShoppingCartBook>();
    }

    public Customer Customer { get; }

    public IReadOnlyCollection<ShoppingCartBook> Books => this.books.ToList().AsReadOnly();

    public ShoppingCart AddBook(int bookId, int quantity)
    {
        var existingBook = this.FindBook(bookId);

        if (existingBook is not null)
        {
            var existingBookQuantity = existingBook.Quantity;

            existingBook.UpdateQuantity(existingBookQuantity + quantity);

            return this;
        }

        this.books.Add(new ShoppingCartBook(bookId, quantity));

        return this;
    }

    public ShoppingCart EditBookQuantity(int bookId, int quantity)
    {
        var existingBook = this.FindBook(bookId);

        this.ValidateBook(existingBook);

        existingBook!.UpdateQuantity(quantity);

        return this;
    }

    private ShoppingCartBook? FindBook(int bookId)
        => this.books.SingleOrDefault(b => b.BookId == bookId);

    private void ValidateBook(ShoppingCartBook? book)
    {
        if (book is null)
        {
            throw new InvalidShoppingCartException("This book does not exist in the shopping cart.");
        }
    }
}