namespace BookStore.Infrastructure.Catalog.Data;

using Application.Catalog.Books.Queries.Common;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Catalog.Models.Books;

internal class BookData :
    IMapFrom<Domain.Catalog.Models.Books.Book>,
    IMapFrom<Domain.Sales.Models.Books.Book>
{
    public int Id { get; private set; }

    public string Title { get; private set; } = default!;

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public string Description { get; private set; } = default!;

    public Genre Genre { get; private set; } = default!;

    public int AuthorId { get; private set; }

    public AuthorData Author { get; private set; } = default!;

    public void Mapping(Profile mapper)
    {
        mapper
            .CreateMapAndReverseMapWithBaseRules<
                BookData,
                Domain.Catalog.Models.Books.Book>();

        mapper
            .CreateMapAndReverseMapWithBaseRules<
                BookData,
                BookResponseModel>();

        mapper
            .CreateMapAndReverseMapWithBaseRules<
                BookData,
                Domain.Sales.Models.Books.Book>();
    }
}