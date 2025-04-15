namespace DanielBlog.Domain.WorkExperiences.ValueObjects;

public record CompanyName
{
    public string Value { get; init; }

    public CompanyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Company name cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static implicit operator CompanyName(string value) => new(value);
}