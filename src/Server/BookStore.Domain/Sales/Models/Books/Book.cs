namespace BookStore.Domain.Sales.Models.Books;

using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Book;
using static Common.Models.ModelConstants.Common;

public class Book : Entity<int>, IAggregateRoot
{
    internal Book(
        string title,
        decimal price,
        int quantity,
        string imageUrl)
    {
        this.Validate(
            title,
            price,
            quantity,
            imageUrl);

        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.ImageUrl = imageUrl;
    }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public string ImageUrl { get; private set; }

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

    public Book UpdateQuantity(int quantity)
    {
        this.ValidateQuantity(quantity);

        this.Quantity = quantity;

        return this;
    }

    public Book UpdateImageUrl(string imageUrl)
    {
        this.ValidateImageUrl(imageUrl);

        this.ImageUrl = imageUrl;

        return this;
    }

    private void Validate(
        string title,
        decimal price,
        int quantity,
        string imageUrl)
    {
        this.ValidateTitle(title);
        this.ValidatePrice(price);
        this.ValidateQuantity(quantity);
        this.ValidateImageUrl(imageUrl);
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

    private void ValidateImageUrl(string imageUrl)
        => Guard.ForValidUrl<InvalidBookException>(
            imageUrl,
            nameof(this.ImageUrl));
}