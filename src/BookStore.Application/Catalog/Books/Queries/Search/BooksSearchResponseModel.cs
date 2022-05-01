namespace BookStore.Application.Catalog.Books.Queries.Search;

using System.Collections.Generic;
using Common;

public class BooksSearchResponseModel
{
    internal BooksSearchResponseModel(
        IEnumerable<BookResponseModel> books,
        int page,
        int totalPages)
    {
        this.Books = books;
        this.Page = page;
        this.TotalPages = totalPages;
    }

    public IEnumerable<BookResponseModel> Books { get; }

    public int Page { get; }

    public int TotalPages { get; }
}