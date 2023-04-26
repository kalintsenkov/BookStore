namespace BookStore.Application.Catalog.Authors.Queries.Common;

using Application.Common.Mapping;
using Domain.Catalog.Models.Authors;

public class AuthorResponseModel : IMapFrom<Author>
{
    public string Name { get; private set; } = default!;
}