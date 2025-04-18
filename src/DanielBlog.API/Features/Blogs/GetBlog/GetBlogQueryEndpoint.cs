using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/blogs/{id:guid}",
                async (GetBlogQueryHandler handler, Guid id, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        var blog = await handler.Handle(id, cancellationToken);
                        return Results.Ok(blog);
                    }
                    catch (ArgumentException ex)
                    {
                        return Results.Problem(type: "Bad Request", title: ex.GetType().Name, detail: ex.Message, statusCode: 400);
                    }
                })
            .WithName("GetBlog")
            .WithTags("Blogs");
    }
}