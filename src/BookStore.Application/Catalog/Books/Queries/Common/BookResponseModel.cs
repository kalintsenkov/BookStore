namespace BookStore.Application.Catalog.Books.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Catalog.Models.Books;

public class BookResponseModel : IMapFrom<Book>
{
    public int Id { get; private set; }

    public string Title { get; private set; } = default!;

    public decimal Price { get; private set; }

    public string Genre { get; private set; } = default!;

    public string AuthorName { get; private set; } = default!;

    public bool IsAvailable { get; private set; }

    public void Mapping(Profile mapper)
        => mapper
            .CreateMap<Book, BookResponseModel>()
            .ForMember(m => m.IsAvailable, cfg => cfg
                .MapFrom(m => m.Quantity != 0));
}