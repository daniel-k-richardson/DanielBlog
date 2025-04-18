namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UserNotFound(string message) : ArgumentException(message);