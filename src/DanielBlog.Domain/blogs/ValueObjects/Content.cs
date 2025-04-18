using DanielBlog.Domain.blogs.Exceptions.BlogExceptions.ContentExceptions;

namespace DanielBlog.Domain.blogs.ValueObjects
{
    public record Content
    {
        public string Value { get; init; }

        public Content(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ContentNullOrEmptyException("Content cannot be empty");
            }

            Value = text;
        }

        public static implicit operator Content(string value) => new(value);
    }
}