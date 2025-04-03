namespace DanielBlog.Domain.blogs.ValueObjects
{
    public record Title
    {
        public string Value { get; init; }

        public Title(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Title cannot be empty", nameof(text));
            }

            if (text.Length > 100)
            {
                throw new ArgumentException("Title cannot be longer than 100 characters", nameof(text));
            }

            this.Value = text;
        }

        public static implicit operator Title(string value) => new(value);
    }
}