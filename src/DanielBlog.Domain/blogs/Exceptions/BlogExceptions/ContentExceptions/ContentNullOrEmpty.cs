namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.ContentExceptions;

public sealed class ContentNullOrEmpty(string message) : ArgumentException(message);
