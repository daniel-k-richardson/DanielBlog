namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions;

public sealed class BlogNotFoundException(string message) : Exception(message);
