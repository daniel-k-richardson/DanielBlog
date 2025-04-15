namespace DanielBlog.API.Features.Blogs.CreateBlog;

public record CreateBlogCommand
{
    public string Title { get; set; }
    public string Content { get; set; }
}