namespace BookStore.Application.Catalog.Authors.Queries.Common;

using Application.Common.Mapping;
using Domain.Catalog.Models.Authors;

public class AuthorResponseModel : IMapFrom<Author>
{
    public int Id { get; private set; } = default!;

    public string Name { get; private set; } = default!;
}