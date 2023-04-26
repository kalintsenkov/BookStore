namespace BookStore.Application.Sales.Customers.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class CustomersSearchResponseModel : PaginatedResponseModel<CustomerResponseModel>
{
    internal CustomersSearchResponseModel(
        IEnumerable<CustomerResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}