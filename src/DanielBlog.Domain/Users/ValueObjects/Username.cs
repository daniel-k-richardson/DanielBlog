using DanielBlog.Domain.Users.UsersExceptions;

namespace DanielBlog.Domain.Users.ValueObjects;

public record Username
{
    public string Value { get; init; }

    public Username(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new UsernameNullOrEmpty("Username cannot be empty");
        }
        
        if (username.Length is < 5 or > 20)
        {
            throw new InvalidUsernameLength("Username must be between 5 and 20 characters");
        }

        Value = username;
    }

    public static implicit operator Username(string value) => new(value);
}
