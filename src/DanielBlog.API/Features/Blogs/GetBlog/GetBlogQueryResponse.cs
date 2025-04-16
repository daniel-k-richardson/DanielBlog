namespace DanielBlog.API.Features.Blogs.GetBlog;

public record GetBlogQueryResponse(Guid Id, string Title, string Content, DateTime CreatedAt);