namespace DanielBlog.Domain.WorkExperiences.ValueObjects;

public record JobTitle
{
    public string Value { get; init; }

    public JobTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Job title cannot be empty.", nameof(value));
        }

        this.Value = value;
    }

    public static implicit operator JobTitle(string value) => new(value);
}