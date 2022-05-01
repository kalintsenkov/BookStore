namespace BookStore.Domain.Catalog.Specifications.Books;

using System;
using System.Linq.Expressions;
using Common;
using Models.Books;

public class BookByPriceSpecification : Specification<Book>
{
    private readonly decimal? minPrice;
    private readonly decimal? maxPrice;

    public BookByPriceSpecification(
        decimal? minPrice = default,
        decimal? maxPrice = int.MaxValue)
    {
        this.minPrice = minPrice ?? default;
        this.maxPrice = maxPrice ?? int.MaxValue;
    }

    public override Expression<Func<Book, bool>> ToExpression()
        => book => this.minPrice < book.Price && book.Price < this.maxPrice;
}