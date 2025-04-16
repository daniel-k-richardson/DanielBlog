namespace DanielBlog.API.Features.Blogs.GetBlogs;

public record GetBlogsQueryResponse(Guid Id, string Title, string Content, DateTime CreatedAt);