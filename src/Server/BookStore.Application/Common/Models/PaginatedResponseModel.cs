namespace BookStore.Application.Common.Models;

using System.Collections.Generic;

public abstract class PaginatedResponseModel<TResponseModel>
{
    protected internal PaginatedResponseModel(
        IEnumerable<TResponseModel> models,
        int page,
        int totalPages)
    {
        this.Models = models;
        this.Page = page;
        this.TotalPages = totalPages;
    }

    public IEnumerable<TResponseModel> Models { get; }

    public int Page { get; }

    public int TotalPages { get; }
}