namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class PasswordNullOrEmpty(string message) : ArgumentException(message);
