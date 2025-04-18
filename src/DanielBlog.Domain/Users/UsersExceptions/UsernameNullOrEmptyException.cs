namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UsernameNullOrEmptyException(string message) : ArgumentException(message);
