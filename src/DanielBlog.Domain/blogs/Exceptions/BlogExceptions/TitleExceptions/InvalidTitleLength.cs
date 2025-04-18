namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class InvalidTitleLength(string message) : ArgumentException(message);

