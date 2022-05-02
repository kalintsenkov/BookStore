namespace BookStore.Domain.Catalog.Specifications.Authors;

using System;
using System.Linq.Expressions;
using Common;
using Models.Authors;

public class AuthorByNameSpecification : Specification<Author>
{
    private readonly string? name;

    public AuthorByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Author, bool>> ToExpression()
        => author => author.Name.ToLower()
            .Contains(this.name!.ToLower());
}