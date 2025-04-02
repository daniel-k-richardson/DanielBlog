namespace DanielBlog.Domain;

public record Content
{
    public string text { get; init; }

    public Content(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Content cannot be empty", nameof(text));
        }

        this.text = text;
    }
}