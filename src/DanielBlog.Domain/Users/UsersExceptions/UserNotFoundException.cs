namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UserNotFoundException(string message) : ArgumentException(message);