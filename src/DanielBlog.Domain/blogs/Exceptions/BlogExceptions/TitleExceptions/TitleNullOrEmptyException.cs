namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class TitleNullOrEmptyException(string message) : ArgumentException(message);