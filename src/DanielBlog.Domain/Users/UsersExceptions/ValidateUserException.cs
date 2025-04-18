namespace DanielBlog.Domain.Users.UsersExceptions;

public sealed class FailedToValidateUser(string message) : ArgumentException(message);