using DanielBlog.Domain.Users.ValueObjects;

namespace DanielBlog.Domain.Users;

public sealed class User : Entity
{
    public Username Username { get; init; }
    public Password Password { get; init; }

    public User(Guid id, Username username, Password password)
    {
        Id = id;
        Username = username;
        Password = password;
    }
}