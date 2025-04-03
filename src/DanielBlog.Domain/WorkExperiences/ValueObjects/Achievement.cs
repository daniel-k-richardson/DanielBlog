namespace DanielBlog.Domain.WorkExperiences.ValueObjects;

public record Achievement
{
    public string Value { get; init; }

    public Achievement(string achievement)
    {
        if (string.IsNullOrWhiteSpace(achievement))
        {
            throw new ArgumentException("Achievement cannot be empty.", nameof(achievement));
        }

        this.Value = achievement;
    }

    public static implicit operator Achievement(string value) => new(value);
}