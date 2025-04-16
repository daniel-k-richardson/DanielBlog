namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public record UpdateBlogCommand (Guid Id, string Title, string Content);