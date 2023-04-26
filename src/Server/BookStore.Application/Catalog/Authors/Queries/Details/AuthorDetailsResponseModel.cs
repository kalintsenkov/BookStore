namespace BookStore.Application.Catalog.Authors.Queries.Details;

using Common;

public class AuthorDetailsResponseModel : AuthorResponseModel
{
    public string Description { get; private set; } = default!;
}