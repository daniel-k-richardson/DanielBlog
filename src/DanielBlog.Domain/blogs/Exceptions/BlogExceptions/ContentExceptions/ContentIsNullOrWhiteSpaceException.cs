namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.ContentExceptions;

public sealed class ContentIsNullOrWhiteSpaceException(string message) : ArgumentException(message);
