using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/blogs",
                async (Mediator mediator, CancellationToken cancellationToken) =>
                {
                    var blogs = await mediator.Send<GetBlogsQuery, GetBlogsQueryResponse>(new GetBlogsQuery(), cancellationToken);
                    return Results.Ok(blogs);
                })
            .WithName("GetBlogs")
            .WithTags("Blogs");
    }
}