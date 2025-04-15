using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public record UpdateBlogCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}