namespace BookStore.Domain.Catalog.Models.Books;

using Authors;
using Common;
using Common.Events.Catalog;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;
using static ModelConstants.Book;

public class Book : Entity<int>, IAggregateRoot
{
    internal Book(
        string title,
        decimal price,
        int quantity,
        string description,
        Genre genre,
        Author author)
    {
        this.Validate(
            title,
            price,
            quantity,
            description);

        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.Description = description;
        this.Genre = genre;
        this.Author = author;

        this.RaiseEvent(new BookCreatedEvent(
            this.Title,
            this.Price,
            this.Quantity));
    }

    private Book(
        string title,
        decimal price,
        int quantity,
        string description)
    {
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.Description = description;

        this.Genre = default!;
        this.Author = default!;
    }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public string Description { get; private set; }

    public Genre Genre { get; private set; }

    public Author Author { get; private set; }

    public Book UpdateTitle(string title)
    {
        if (this.Title != title)
        {
            this.ValidateTitle(title);

            this.Title = title;

            this.RaiseEvent(new BookTitleUpdatedEvent(
                this.Id,
                this.Title));
        }

        return this;
    }

    public Book UpdatePrice(decimal price)
    {
        if (this.Price != price)
        {
            this.ValidatePrice(price);

            this.Price = price;

            this.RaiseEvent(new BookPriceUpdatedEvent(
                this.Id,
                this.Price));
        }

        return this;
    }

    public Book UpdateQuantity(int quantity)
    {
        if (this.Quantity != quantity)
        {
            this.ValidateQuantity(quantity);

            this.Quantity = quantity;

            this.RaiseEvent(new BookQuantityUpdatedEvent(
                this.Id,
                this.Quantity));
        }

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

    private void Validate(
        string title,
        decimal price,
        int quantity,
        string description)
    {
        this.ValidateTitle(title);
        this.ValidatePrice(price);
        this.ValidateQuantity(quantity);
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

    private void ValidateQuantity(int quantity)
        => Guard.AgainstOutOfRange<InvalidBookException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidBookException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}