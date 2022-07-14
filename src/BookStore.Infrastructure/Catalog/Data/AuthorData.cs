namespace BookStore.Infrastructure.Catalog.Data;

using System.Collections.Generic;
using Application.Catalog.Authors.Queries.Common;
using Application.Catalog.Authors.Queries.Details;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Catalog.Models.Authors;

internal class AuthorData : IMapFrom<Author>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public ICollection<BookData> Books { get; } = new HashSet<BookData>();

    public void Mapping(Profile mapper)
    {
        mapper
            .CreateMapAndReverseMapWithBaseRules<
                AuthorData,
                Author>();

        mapper
            .CreateMapWithBaseRules<
                AuthorData,
                AuthorResponseModel>();

        mapper
            .CreateMapWithBaseRules<
                AuthorData,
                AuthorDetailsResponseModel>()
            .IncludeBase<
                AuthorData,
                AuthorResponseModel>();
    }
}