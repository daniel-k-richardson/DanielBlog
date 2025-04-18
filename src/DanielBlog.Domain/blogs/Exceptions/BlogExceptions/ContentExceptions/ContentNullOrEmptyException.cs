namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.ContentExceptions;

public sealed class ContentNullOrEmptyException(string message) : ArgumentException(message);
