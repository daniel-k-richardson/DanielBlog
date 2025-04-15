namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UsernameLengthException(string message) : ArgumentException(message);
