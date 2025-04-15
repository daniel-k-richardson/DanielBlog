namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class UsernameIsNullOrEmptyException(string message) : ArgumentException(message);
