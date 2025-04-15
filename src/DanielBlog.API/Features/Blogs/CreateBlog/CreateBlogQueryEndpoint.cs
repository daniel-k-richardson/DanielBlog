using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public sealed class CreateBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/blogs",
            async (Mediator mediator, CreateBlogCommand command, CancellationToken cancellationToken) =>
            {
                await mediator.Send(command, cancellationToken);
                return Results.Ok();
            })
            .WithName("CreateBlog")
            .WithTags("Blogs")
            .RequireAuthorization();
    }
}