namespace BookStore.Application.Common.Contracts;

public interface ICurrentUser
{
    string UserId { get; }
}