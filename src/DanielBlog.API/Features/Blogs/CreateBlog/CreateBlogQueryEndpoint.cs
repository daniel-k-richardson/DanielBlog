using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public sealed class CreateBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/blogs",
            async (CreateBlogCommandHandler handler, CreateBlogCommand command, CancellationToken cancellationToken) =>
            {
                try
                {
                    await handler.Handle(command, cancellationToken);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.Problem(type: "Bad Request", title: ex.GetType().Name, detail: ex.Message, statusCode: 400);
                }
            })
            .WithName("CreateBlog")
            .WithTags("Blogs")
            .RequireAuthorization();
    }
}