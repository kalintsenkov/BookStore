namespace BookStore.Domain.Catalog.Models.Books;

using Authors;
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
        string description,
        Genre genre,
        Author author,
        bool isAvailable)
    {
        this.Validate(title, price, description);

        this.Title = title;
        this.Price = price;
        this.Description = description;
        this.Genre = genre;
        this.Author = author;
        this.IsAvailable = isAvailable;
    }

    private Book(
        string title,
        decimal price,
        string description,
        bool isAvailable)
    {
        this.Title = title;
        this.Price = price;
        this.Description = description;
        this.IsAvailable = isAvailable;

        this.Genre = default!;
        this.Author = default!;
    }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public string Description { get; private set; }

    public Genre Genre { get; private set; }

    public Author Author { get; private set; }

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

    public Book UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    public Book UpdateGenre(Genre genre)
    {
        this.Genre = genre;

        return this;
    }

    public Book UpdateAuthor(Author author)
    {
        this.Author = author;

        return this;
    }

    public Book ChangeAvailability()
    {
        this.IsAvailable = !this.IsAvailable;

        return this;
    }

    private void Validate(
        string title,
        decimal price,
        string description)
    {
        this.ValidateTitle(title);
        this.ValidatePrice(price);
        this.ValidateDescription(description);
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

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidBookException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}