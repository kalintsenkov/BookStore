namespace BookStore.Application.Catalog.Books.Queries.Common;

using Application.Common.Mapping;
using Domain.Catalog.Models.Books;

public class BookResponseModel : IMapFrom<Book>
{
    public int Id { get; private set; }

    public string Title { get; private set; } = default!;

    public decimal Price { get; private set; }

    public string Genre { get; private set; } = default!;

    public string AuthorName { get; private set; } = default!;

    public bool IsAvailable { get; private set; }
}