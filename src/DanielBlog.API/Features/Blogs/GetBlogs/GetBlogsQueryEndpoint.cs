using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/blogs",
                async (GetBlogsQueryHandler handler, CancellationToken cancellationToken) =>
                {
                    var blogs = await handler.Handle(cancellationToken);
                    return Results.Ok(blogs);
                })
            .WithName("GetBlogs")
            .WithTags("Blogs");
    }
}