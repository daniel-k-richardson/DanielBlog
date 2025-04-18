namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions;

public sealed class BlogNotFound(string message) : Exception(message);
