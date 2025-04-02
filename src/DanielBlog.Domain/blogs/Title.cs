namespace DanielBlog.Domain;

public record Title
{
    public string text { get; init; }

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

        this.text = text;
    }
}