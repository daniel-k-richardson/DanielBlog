using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public sealed class CreateBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/blogs",
            async (CreateBlogCommandHandler handler, CreateBlogCommand command, CancellationToken cancellationToken) =>
            {
                await handler.Handle(command, cancellationToken);
                return Results.Ok();
            })
            .WithName("CreateBlog")
            .WithTags("Blogs")
            .RequireAuthorization();
    }
}