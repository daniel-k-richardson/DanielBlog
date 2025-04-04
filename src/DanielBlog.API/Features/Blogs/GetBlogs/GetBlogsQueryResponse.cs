using DanielBlog.API.Features.Blogs.GetBlog;

namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryResponse
{
    public List<GetBlogQueryResponse> Blogs { get; set; }
}