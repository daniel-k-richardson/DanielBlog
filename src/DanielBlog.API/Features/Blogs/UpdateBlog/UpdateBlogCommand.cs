namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public record UpdateBlogCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}