namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}