namespace DanielBlog.Domain.blogs.ValueObjects
{
    public record Content
    {
        public string Value { get; init; }

        public Content(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Content cannot be empty", nameof(text));
            }

            Value = text;
        }

        public static implicit operator Content(string value) => new(value);
    }
}