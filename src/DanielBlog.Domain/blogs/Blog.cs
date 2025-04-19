using DanielBlog.Domain.blogs.ValueObjects;

namespace DanielBlog.Domain.blogs;

public sealed class Blog : Entity
{
    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public DateTime CreatedAt { get; init; }

    public Blog(
        Title title,
        Content content)
    {
        Title = title;
        Content = content;
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
    
    public void Update(
        Title title,
        Content content)
    {
        Title = title;
        Content = content;
    }
}