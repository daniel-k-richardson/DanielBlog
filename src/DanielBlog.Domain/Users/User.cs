using DanielBlog.Domain.Users.ValueObjects;

namespace DanielBlog.Domain.Users;

public sealed class User : Entity
{
    public Username Username { get; init; }
    public Password Password { get; init; }

    // Parameterless constructor for EF Core
    private User() { }
    
    public User(Username username, Password password)
    {
        Username = username;
        Password = password;
    }
}