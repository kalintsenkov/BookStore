namespace BookStore.Domain.Common.Events.Identity;

public class UserRegisteredEvent : IDomainEvent
{
    public UserRegisteredEvent(string userId, string fullName)
    {
        UserId = userId;
        FullName = fullName;
    }

    public string UserId { get; }

    public string FullName { get; }
}