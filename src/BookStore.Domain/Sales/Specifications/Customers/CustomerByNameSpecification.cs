namespace BookStore.Domain.Sales.Specifications.Customers;

using System;
using System.Linq.Expressions;
using Common;
using Models.Customers;

public class CustomerByNameSpecification : Specification<Customer>
{
    private readonly string? name;

    public CustomerByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Customer, bool>> ToExpression()
        => customer => customer.Name.ToLower()
            .Contains(this.name!.ToLower());
}