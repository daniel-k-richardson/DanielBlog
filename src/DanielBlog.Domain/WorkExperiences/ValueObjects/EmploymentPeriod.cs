namespace DanielBlog.Domain.WorkExperiences.ValueObjects;

public record EmploymentPeriod
{
    public DateOnly Started { get; init; }
    public DateOnly? End { get; init; }

    public EmploymentPeriod(DateOnly started, DateOnly? end)
    {
        if (end.HasValue && end.Value < started)
        {
            throw new ArgumentException("End date cannot be earlier than start date.", nameof(end));
        }

        Started = started;
        End = end;
    }
}