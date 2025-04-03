using DanielBlog.Domain.WorkExperiences.ValueObjects;

namespace DanielBlog.Domain.WorkExperiences;

public class WorkExperience : Entity
{
    public JobTitle JobTitle { get; init; }
    public CompanyName CompanyName { get; init; }
    public EmploymentPeriod EmploymentPeriod { get; init; }
    public List<Responsibility> Responsibilities  { get; init; }
    public List<Achievement> Achievements { get; init; }

    public WorkExperience(
        JobTitle jobTitle,
        CompanyName companyName,
        EmploymentPeriod employmentPeriod,
        List<Responsibility> responsibilities,
        List<Achievement> achievements)
    {
        JobTitle = jobTitle;
        CompanyName = companyName;
        EmploymentPeriod = employmentPeriod;
        Responsibilities = responsibilities;
        Achievements = achievements;
    }
}