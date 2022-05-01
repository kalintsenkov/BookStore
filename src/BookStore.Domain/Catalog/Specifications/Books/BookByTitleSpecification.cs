namespace BookStore.Domain.Catalog.Specifications.Books;

using System;
using System.Linq.Expressions;
using Common;
using Models.Books;

public class BookByTitleSpecification : Specification<Book>
{
    private readonly string? title;

    public BookByTitleSpecification(string? title) => this.title = title;

    protected override bool Include => this.title != null;

    public override Expression<Func<Book, bool>> ToExpression()
        => book => book.Title.ToLower()
            .Contains(this.title!.ToLower());
}