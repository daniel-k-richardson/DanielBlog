using DanielBlog.Domain.blogs.ValueObjects;

namespace DanielBlog.Domain.blogs;

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
        this.Id = id;
        this.Title = title;
        this.Content = content;
        this.CreatedAt = DateTime.UtcNow;
    }
}