namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UsernameNullOrEmpty(string message) : ArgumentException(message);
