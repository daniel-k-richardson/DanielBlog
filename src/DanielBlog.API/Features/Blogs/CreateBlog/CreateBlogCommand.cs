using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public record CreateBlogCommand : IRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}