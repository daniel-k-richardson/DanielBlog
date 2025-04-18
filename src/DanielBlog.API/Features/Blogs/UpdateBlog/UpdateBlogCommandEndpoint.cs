using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public sealed class UpdateBlogCommandEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("api/blogs/{id:guid}", async (
                UpdateBlogCommandHandler handler, 
                Guid id, 
                UpdateBlogCommand command, 
                CancellationToken cancellationToken) =>
                {
                    if (id != command.Id)
                    {
                        return Results.Problem(type: "Bad Request", title: "Blog ID mismatch", statusCode: 400);
                    }

                    await handler.Handle(command, cancellationToken);
                    return Results.Ok();
                })
            .WithName("UpdateBlog")
            .WithTags("Blogs")
            .RequireAuthorization();
    }
}