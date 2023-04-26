namespace BookStore.Domain.Common.Events.Catalog;

public class BookImageUrlUpdatedEvent : IDomainEvent
{
    public BookImageUrlUpdatedEvent(int id, string imageUrl)
    {
        this.Id = id;
        this.ImageUrl = imageUrl;
    }

    public int Id { get; }

    public string ImageUrl { get; }
}