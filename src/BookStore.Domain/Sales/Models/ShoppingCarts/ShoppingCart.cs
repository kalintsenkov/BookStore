namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using System.Collections.Generic;
using System.Linq;
using Books;
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

    public decimal TotalPrice => this.books.Sum(cb => cb.Quantity * cb.Book.Price);

    public IReadOnlyCollection<ShoppingCartBook> Books => this.books.ToList();

    public ShoppingCart AddBook(Book book, int quantity)
    {
        var existingBook = this.FindBook(book.Id);

        if (existingBook is not null)
        {
            var existingBookQuantity = existingBook.Quantity;

            existingBook.UpdateQuantity(existingBookQuantity + quantity);

            return this;
        }

        this.books.Add(new ShoppingCartBook(book, quantity));

        return this;
    }

    public ShoppingCart RemoveBook(Book book)
    {
        var bookToRemove = this.FindBook(book.Id);

        if (bookToRemove is null)
        {
            throw new InvalidShoppingCartException("This book does not exist in the shopping cart.");
        }

        this.books.Remove(bookToRemove);

        return this;
    }

    private ShoppingCartBook? FindBook(int bookId)
        => this.books.SingleOrDefault(b => b.Book.Id == bookId);
}