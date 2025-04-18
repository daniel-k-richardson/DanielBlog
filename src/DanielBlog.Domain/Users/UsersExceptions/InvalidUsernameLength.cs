namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class InvalidUsernameLength(string message) : ArgumentException(message);
