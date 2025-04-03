namespace DanielBlog.Domain.WorkExperiences.ValueObjects;

public record Responsibility
{
    public string Value { get; init; }

    public Responsibility(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Responsibility cannot be empty.", nameof(value));
        }

        this.Value = value;
    }

    public static implicit operator Responsibility(string value) => new(value);
}