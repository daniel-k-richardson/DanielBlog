namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class TitleIsNullOrWhiteSpaceException(string message) : ArgumentException(message);