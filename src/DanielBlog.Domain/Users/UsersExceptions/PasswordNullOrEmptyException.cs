namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class PasswordNullOrEmptyException(string message) : ArgumentException(message);
