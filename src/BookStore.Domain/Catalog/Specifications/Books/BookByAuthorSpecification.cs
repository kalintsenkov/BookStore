namespace BookStore.Domain.Catalog.Specifications.Books;

using System;
using System.Linq.Expressions;
using Common;
using Models.Books;

public class BookByAuthorSpecification : Specification<Book>
{
    private readonly string? author;

    public BookByAuthorSpecification(string? author) => this.author = author;

    protected override bool Include => this.author != null;

    public override Expression<Func<Book, bool>> ToExpression()
        => book => book.Author.Name.ToLower()
            .Contains(this.author!.ToLower());
}