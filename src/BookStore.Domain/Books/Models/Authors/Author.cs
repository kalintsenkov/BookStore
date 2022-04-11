namespace BookStore.Domain.Books.Models.Authors;

using System.Collections.Generic;
using System.Linq;
using Books;
using Common;
using Common.Models;
using Exceptions;

using static ModelConstants.Common;

public class Author : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Book> books;

    internal Author(string name, string description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;

        this.books = new HashSet<Book>();
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<Book> Books => this.books.ToList().AsReadOnly();

    public Author UpdateName(string name)
    {
        this.ValidateName(name);

        this.Name = name;

        return this;
    }

    public Author UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    public Author AddBook(Book book)
    {
        this.books.Add(book);

        return this;
    }

    private void Validate(string name, string description)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidAuthorException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidAuthorException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}