namespace BookStore.Application.Catalog.Books.Queries.Details;

using AutoMapper;
using Common;
using Domain.Catalog.Models.Books;

public class BookDetailsResponseModel : BookResponseModel
{
    public int Quantity { get; private set; }

    public string Description { get; private set; } = default!;

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Book, BookDetailsResponseModel>()
            .IncludeBase<Book, BookResponseModel>();
}