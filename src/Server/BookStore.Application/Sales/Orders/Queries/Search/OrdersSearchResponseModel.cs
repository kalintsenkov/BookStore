namespace BookStore.Application.Sales.Orders.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class OrdersSearchResponseModel : PaginatedResponseModel<OrderResponseModel>
{
    internal OrdersSearchResponseModel(
        IEnumerable<OrderResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}