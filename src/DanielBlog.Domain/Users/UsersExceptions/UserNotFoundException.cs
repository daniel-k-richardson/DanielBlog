namespace DanielBlog.Domain.Users.UsersExceptions;

public class UserNotFoundException(string message) : ArgumentException(message);