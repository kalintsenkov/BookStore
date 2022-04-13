namespace BookStore.Domain.Catalog.Models.Books;

using Common;
using Common.Models;
using Exceptions;

using static ModelConstants.Common;
using static ModelConstants.Book;

public class Book : Entity<int>, IAggregateRoot
{
    internal Book(
        string title,
        decimal price,
        Genre genre,
        bool isAvailable)
    {
        this.Validate(title, price);

        this.Title = title;
        this.Price = price;
        this.Genre = genre;
        this.IsAvailable = isAvailable;
    }

    private Book(
        string title,
        decimal price,
        bool isAvailable)
    {
        this.Title = title;
        this.Price = price;
        this.IsAvailable = isAvailable;

        this.Genre = default!;
    }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public Genre Genre { get; private set; }

    public bool IsAvailable { get; private set; }

    public Book UpdateTitle(string title)
    {
        this.ValidateTitle(title);

        this.Title = title;

        return this;
    }

    public Book UpdatePrice(decimal price)
    {
        this.ValidatePrice(price);

        this.Price = price;

        return this;
    }

    public Book UpdateGenre(Genre genre)
    {
        this.Genre = genre;

        return this;
    }

    public Book ChangeAvailability()
    {
        this.IsAvailable = !this.IsAvailable;

        return this;
    }

    private void Validate(string title, decimal price)
    {
        this.ValidateTitle(title);
        this.ValidatePrice(price);
    }

    private void ValidateTitle(string title)
        => Guard.ForStringLength<InvalidBookException>(
            title,
            MinNameLength,
            MaxNameLength,
            nameof(this.Title));

    private void ValidatePrice(decimal price)
        => Guard.AgainstOutOfRange<InvalidBookException>(
            price,
            MinPriceValue,
            MaxPriceValue,
            nameof(this.Price));
}