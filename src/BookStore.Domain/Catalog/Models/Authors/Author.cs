namespace BookStore.Domain.Catalog.Models.Authors;

using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class Author : Entity<int>, IAggregateRoot
{
    internal Author(string name, string description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Author UpdateName(string name)
    {
        this.ValidateName(name);

        this.Name = name;

        return this;
    }

    public Author UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    private void Validate(string name, string description)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidAuthorException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidAuthorException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}