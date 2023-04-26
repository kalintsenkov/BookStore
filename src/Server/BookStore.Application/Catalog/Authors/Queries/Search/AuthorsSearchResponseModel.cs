namespace BookStore.Application.Catalog.Authors.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class AuthorsSearchResponseModel : PaginatedResponseModel<AuthorResponseModel>
{
    internal AuthorsSearchResponseModel(
        IEnumerable<AuthorResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}