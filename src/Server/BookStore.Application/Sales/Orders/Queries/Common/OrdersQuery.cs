namespace BookStore.Application.Sales.Orders.Queries.Common;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Sales.Models.Orders;
using Domain.Sales.Specifications.Orders;

public abstract class OrdersQuery
{
    private const int OrdersPerPage = 10;

    public string? Customer { get; init; }

    public string? SortBy { get; init; }

    public string? Order { get; init; }

    public int Page { get; init; } = 1;

    public abstract class OrdersQueryHandler
    {
        private readonly IOrderQueryRepository orderRepository;

        protected OrdersQueryHandler(IOrderQueryRepository orderRepository)
            => this.orderRepository = orderRepository;

        protected async Task<IEnumerable<TOutputModel>> GetOrdersListing<TOutputModel>(
            OrdersQuery request,
            int? customerId = default,
            CancellationToken cancellationToken = default)
        {
            var specification = this.GetSpecification(request, customerId);

            var searchOrder = new OrdersSearchOrder(request.SortBy, request.Order);

            var skip = (request.Page - 1) * OrdersPerPage;

            return await this.orderRepository.GetOrdersListing<TOutputModel>(
                specification,
                searchOrder,
                skip,
                take: OrdersPerPage,
                cancellationToken);
        }

        protected async Task<int> GetTotalPages(
            OrdersQuery request,
            int? customerId = default,
            CancellationToken cancellationToken = default)
        {
            var specification = this.GetSpecification(request, customerId);

            var totalOrders = await this.orderRepository.Total(
                specification,
                cancellationToken);

            return (int)Math.Ceiling((double)totalOrders / OrdersPerPage);
        }

        private Specification<Order> GetSpecification(
            OrdersQuery request,
            int? customerId)
            => new OrderByCustomerIdSpecification(customerId)
                .And(new OrderByCustomerNameSpecification(request.Customer));
    }
}