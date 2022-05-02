namespace BookStore.Application.Catalog.Books.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class BooksSearchResponseModel : PaginatedResponseModel<BookResponseModel>
{
    internal BooksSearchResponseModel(
        IEnumerable<BookResponseModel> books,
        int page,
        int totalPages)
        : base(books, page, totalPages)
    {
    }
}