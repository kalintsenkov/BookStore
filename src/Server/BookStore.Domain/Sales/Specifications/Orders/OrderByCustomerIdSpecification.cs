namespace BookStore.Domain.Sales.Specifications.Orders;

using System;
using System.Linq.Expressions;
using Common;
using Models.Orders;

public class OrderByCustomerIdSpecification : Specification<Order>
{
    private readonly int? customerId;

    public OrderByCustomerIdSpecification(int? customerId) => this.customerId = customerId;

    protected override bool Include => this.customerId != null;

    public override Expression<Func<Order, bool>> ToExpression()
        => order => order.Customer.Id == this.customerId;
}