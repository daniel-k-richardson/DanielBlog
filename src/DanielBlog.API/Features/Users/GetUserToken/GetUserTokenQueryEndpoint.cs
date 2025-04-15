using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Users.GetUserToken;

public class GetUserTokenQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/Users/token",
                async (Mediator mediator, GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken) =>
                {
                    var blog = await mediator.Send<GetUserTokenQuery, GetUserTokenQueryResponse>(getUserTokenQuery, cancellationToken);
                    return Results.Ok(blog);
                })
            .WithName("GetUserToken")
            .WithTags("Users");
    }
}