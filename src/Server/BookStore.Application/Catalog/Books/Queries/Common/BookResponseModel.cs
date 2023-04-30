namespace BookStore.Application.Catalog.Books.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Catalog.Models.Books;

public class BookResponseModel : IMapFrom<Book>
{
    public int Id { get; init; }

    public string Title { get; init; } = default!;

    public decimal Price { get; init; }

    public string ImageUrl { get; init; } = default!;

    public string Genre { get; init; } = default!;

    public string AuthorName { get; init; } = default!;

    public bool IsAvailable { get; init; }

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Book, BookResponseModel>()
            .ForMember(m => m.IsAvailable, cfg => cfg
                .MapFrom(m => m.Quantity != 0));
}