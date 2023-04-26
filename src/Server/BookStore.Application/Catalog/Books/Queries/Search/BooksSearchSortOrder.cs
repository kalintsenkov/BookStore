namespace BookStore.Application.Catalog.Books.Queries.Search;

using System;
using System.Linq.Expressions;
using Application.Common;
using Domain.Catalog.Models.Books;

public class BooksSearchSortOrder : SortOrder<Book>
{
    public BooksSearchSortOrder(string? sortBy, string? order)
        : base(sortBy, order)
    {
    }

    public override Expression<Func<Book, object>> ToExpression()
        => this.SortBy switch
        {
            "title" => book => book.Title,
            "price" => book => book.Price,
            "author" => book => book.Author.Name,
            _ => book => book.Id
        };
}