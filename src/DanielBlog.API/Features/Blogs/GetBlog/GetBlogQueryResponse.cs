namespace DanielBlog.API.Features.Blogs.GetBlog;

public record GetBlogQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}