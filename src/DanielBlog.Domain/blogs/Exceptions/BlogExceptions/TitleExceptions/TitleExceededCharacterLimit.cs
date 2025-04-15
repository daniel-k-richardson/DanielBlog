namespace DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

public sealed class TitleExceededCharacterLimit(string message) : ArgumentException(message);

