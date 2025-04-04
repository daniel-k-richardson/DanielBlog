using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/blogs/{id:guid}",
                async (GetBlogQueryHandler handler, Guid id, CancellationToken cancellationToken) =>
                {
                    var blog = await handler.Handle(id, cancellationToken);
                    return Results.Ok(blog);
                })
            .WithName("GetBlog")
            .WithTags("Blogs");
    }
}