using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/blogs/{id:guid}",
                async (Mediator mediator, Guid id, CancellationToken cancellationToken) =>
                {
                    var blog = await mediator.Send<GetBlogQuery, GetBlogQueryResponse>(new GetBlogQuery(id), cancellationToken);
                    return Results.Ok(blog);
                })
            .WithName("GetBlog")
            .WithTags("Blogs");
    }
}