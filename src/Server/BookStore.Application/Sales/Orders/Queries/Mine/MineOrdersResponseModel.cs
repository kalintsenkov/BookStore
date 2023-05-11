namespace BookStore.Application.Sales.Orders.Queries.Mine;

using System.Collections.Generic;
using Application.Common.Models;
using Common;
using MediatR;

public class MineOrdersResponseModel : PaginatedResponseModel<OrderResponseModel>, IRequest<Unit>
{
    internal MineOrdersResponseModel(
        IEnumerable<OrderResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}