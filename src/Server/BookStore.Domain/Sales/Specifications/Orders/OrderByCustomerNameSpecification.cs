namespace BookStore.Domain.Sales.Specifications.Orders;

using System;
using System.Linq.Expressions;
using Common;
using Models.Orders;

public class OrderByCustomerNameSpecification : Specification<Order>
{
    private readonly string? customerName;

    public OrderByCustomerNameSpecification(string? customerName) => this.customerName = customerName;

    protected override bool Include => this.customerName != null;

    public override Expression<Func<Order, bool>> ToExpression()
        => order => order.Customer.Name.ToLower()
            .Contains(this.customerName!.ToLower());
}