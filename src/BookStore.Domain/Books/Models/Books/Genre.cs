namespace BookStore.Domain.Books.Models.Books;

using Common.Models;
using Exceptions;

using static ModelConstants.Common;

public class Genre : Entity<int>
{
    public Genre(string name, string description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    private void Validate(string name, string description)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidBookException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidBookException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}