using DanielBlog.Domain.blogs.ValueObjects;

namespace DanielBlog.Domain.blogs;

public sealed class Blog : Entity
{
    public Title Title { get; private set; }
    public Content Content { get; private set; }
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
    public void Update(
        Title title,
        Content content)
    {
        this.Title = title;
        this.Content = content;
    }
}