using System.Runtime.CompilerServices;
using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public sealed class UpdateBlogCommandEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/blogs/{id:guid}", async (
                Mediator mediator, 
                Guid id, 
                UpdateBlogCommand command, 
                CancellationToken cancellationToken) =>
                {
                    if (id != command.Id)
                    {
                        return Results.BadRequest("Blog ID in the URL does not match the ID in the request body.");
                    }

                    await mediator.Send(command, cancellationToken);
                    return Results.Ok();
                })
            .WithName("UpdateBlog")
            .WithTags("Blogs")
            .RequireAuthorization();
    }
}