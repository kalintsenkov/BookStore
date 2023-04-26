namespace BookStore.Domain.Common.Events.Identity;

public class UserRegisteredEvent : IDomainEvent
{
    public UserRegisteredEvent(string userId, string fullName)
    {
        this.UserId = userId;
        this.FullName = fullName;
    }

    public string UserId { get; }

    public string FullName { get; }
}