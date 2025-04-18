namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class TitleLengthException(string message) : ArgumentException(message);

