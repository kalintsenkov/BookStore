namespace BookStore.Application.Sales.Orders.Queries.Mine;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Common;
using Domain.Sales.Repositories;
using MediatR;

public class MineOrdersQuery : OrdersQuery, IRequest<MineOrdersResponseModel>
{
    public class MineOrdersQueryHandler : OrdersQueryHandler, IRequestHandler<
        MineOrdersQuery,
        MineOrdersResponseModel>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICustomerDomainRepository customerRepository;

        public MineOrdersQueryHandler(
            ICurrentUser currentUser,
            IOrderQueryRepository orderRepository,
            ICustomerDomainRepository customerRepository)
            : base(orderRepository)
        {
            this.currentUser = currentUser;
            this.customerRepository = customerRepository;
        }

        public async Task<MineOrdersResponseModel> Handle(
            MineOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var customerId = await this.customerRepository.GetCustomerId(
                this.currentUser.UserId,
                cancellationToken);

            var mineOrdersListing = await base.GetOrdersListing<OrderResponseModel>(
                request,
                customerId,
                cancellationToken);

            var totalPages = await base.GetTotalPages(
                request,
                customerId,
                cancellationToken);

            return new MineOrdersResponseModel(mineOrdersListing, request.Page, totalPages);
        }
    }
}