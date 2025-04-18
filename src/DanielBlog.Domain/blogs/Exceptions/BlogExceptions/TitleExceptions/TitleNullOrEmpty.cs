namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class TitleNullOrEmpty(string message) : ArgumentException(message);