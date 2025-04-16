using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Users.GetUserToken;

public sealed class GetUserTokenQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/Users/token",
                async (GetUserTokenQueryHandler handler, GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken) =>
                {
                    var blog = await handler.Handle(getUserTokenQuery, cancellationToken);
                    return Results.Ok(blog);
                })
            .WithName("GetUserToken")
            .WithTags("Users");
    }
}