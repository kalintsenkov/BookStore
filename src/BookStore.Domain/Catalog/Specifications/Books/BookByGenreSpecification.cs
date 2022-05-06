namespace BookStore.Domain.Catalog.Specifications.Books;

using System;
using System.Linq.Expressions;
using Common;
using Models.Books;

public class BookByGenreSpecification : Specification<Book>
{
    private readonly int? genre;

    public BookByGenreSpecification(int? genre) => this.genre = genre;

    protected override bool Include => this.genre != null;

    public override Expression<Func<Book, bool>> ToExpression()
        => book => book.Genre.Value == this.genre;
}