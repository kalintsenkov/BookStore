namespace BookStore.Domain.Common.Events.Catalog;

public class BookTitleUpdatedEvent : IDomainEvent
{
    public BookTitleUpdatedEvent(int id, string title)
    {
        this.Id = id;
        this.Title = title;
    }

    public int Id { get; }

    public string Title { get; }
}