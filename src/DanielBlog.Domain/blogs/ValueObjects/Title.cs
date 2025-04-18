using DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

namespace DanielBlog.Domain.blogs.ValueObjects
{
    public record Title
    {
        public string Value { get; init; }

        public Title(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new TitleNullOrEmptyException("Title cannot be empty");
            }

            if (text.Length > 100)
            {
                throw new TitleLengthException("Title cannot be longer than 100 characters");
            }

            Value = text;
        }

        public static implicit operator Title(string value) => new(value);
    }
}