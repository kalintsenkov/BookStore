namespace BookStore.Application.Catalog.Authors.Queries.Books;

using Common.Mapping;
using Domain.Catalog.Models.Books;

public class AuthorBooksResponseModel : IMapFrom<Book>
{
    public int Id { get; private set; }

    public string Title { get; private set; } = default!;

    public decimal Price { get; private set; }

    public string Genre { get; private set; } = default!;
}