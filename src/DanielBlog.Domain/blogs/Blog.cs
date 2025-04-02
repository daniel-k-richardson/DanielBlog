namespace DanielBlog.Domain;

public class Blog : Entity
{
    public Title Title { get; init; }
    public Content Content { get; init; }
    public DateTime CreatedAt { get; init; }

    public Blog(
        Guid id,
        Title title,
        Content content)
    {
        Id = id;
        Title = title;
        Content = content;
    }
}