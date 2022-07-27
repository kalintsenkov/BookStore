namespace BookStore.Domain.Catalog.Factories.Books;

using Exceptions;
using Models.Authors;
using Models.Books;

internal class BookFactory : IBookFactory
{
    private string bookTitle = default!;
    private decimal bookPrice = default!;
    private int bookQuantity = default!;
    private string bookDescription = default!;
    private Genre bookGenre = default!;
    private Author bookAuthor = default!;

    private bool isTitleSet = false;
    private bool isPriceSet = false;
    private bool isQuantitySet = false;
    private bool isDescriptionSet = false;
    private bool isGenreSet = false;
    private bool isAuthorSet = false;

    public IBookFactory WithTitle(string title)
    {
        this.bookTitle = title;
        this.isTitleSet = true;

        return this;
    }

    public IBookFactory WithPrice(decimal price)
    {
        this.bookPrice = price;
        this.isPriceSet = true;

        return this;
    }

    public IBookFactory WithQuantity(int quantity)
    {
        this.bookQuantity = quantity;
        this.isQuantitySet = true;

        return this;
    }

    public IBookFactory WithDescription(string description)
    {
        this.bookDescription = description;
        this.isDescriptionSet = true;

        return this;
    }

    public IBookFactory WithGenre(Genre genre)
    {
        this.bookGenre = genre;
        this.isGenreSet = true;

        return this;
    }

    public IBookFactory FromAuthor(Author author)
    {
        this.bookAuthor = author;
        this.isAuthorSet = true;

        return this;
    }

    public Book Build()
    {
        if (!this.isTitleSet ||
            !this.isPriceSet ||
            !this.isQuantitySet ||
            !this.isDescriptionSet ||
            !this.isGenreSet ||
            !this.isAuthorSet)
        {
            throw new InvalidBookException("Title, price, quantity, description, genre and author must have a value.");
        }

        return new Book(
            this.bookTitle,
            this.bookPrice,
            this.bookQuantity,
            this.bookDescription,
            this.bookGenre,
            this.bookAuthor);
    }
}